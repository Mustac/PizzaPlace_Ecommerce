using Blazored.Toast.Services;
using Newtonsoft.Json;
using PizzaPlace.BlazorServer.Helpers;
using System.Linq;
using System.Text.Json;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.BlazorServer.Services
{
    public class ShoppingCartService
    {
        private readonly IToastService _toastService;
        private readonly ILocalStorageService _localStorageService;
        private readonly IJSRuntime _jSRuntime;
        public ShoppingCartService(IToastService toastService, ILocalStorageService localStorageService, IJSRuntime jSRuntime)
        {
            _toastService = toastService;
            _localStorageService = localStorageService;
            _jSRuntime = jSRuntime;
        }


        public event Func<Task> OnShoppingCartChange;
        public IList<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public int NumberOfProducts { get; private set; }

        /// <summary>
        /// Gets the total cart price of the products without discounts.
        /// </summary>
        public float TotalCartPrice => Products.Sum(x => x.Amount * x.Price);

        /// <summary>
        /// Gets the total price with discounts applied.
        /// </summary>
        public float TotalPriceWithDiscounts =>
            Products.Where(x => x.DiscountedPrice > 0).Sum(x => x.DiscountedPrice * x.Amount) +
            Products.Where(x => x.DiscountedPrice == 0).Sum(x => x.Price * x.Amount);

        /// <summary>
        /// Computes the total amount discounted for the cart.
        /// </summary>
        public float TotalDiscounts => TotalCartPrice - TotalPriceWithDiscounts;


        /// <summary>
        /// Adds a product to the shopping cart. If the product already exists in the cart, its quantity is updated.
        /// Notifies the user of the addition. Also, triggers an update of the cart.
        /// </summary>
        /// <param name="product">The product to add to the cart.</param>
        /// <returns>True if the operation succeeded, otherwise false.</returns>
        public async Task<bool> AddToShoppingCartAsync(ProductDTO product)
        {
            var tempJson = "";

            try
            {
                var productsJson = await _localStorageService.GetItemAsStringAsync("cart");
                var products = string.IsNullOrEmpty(productsJson)
                    ? new List<ProductDTO> { product }
                    : JsonConvert.DeserializeObject<List<ProductDTO>>(productsJson);

                // Check if the product is already in the cart
                var prod = products.FirstOrDefault(x => x.Id == product.Id);
                if (prod is not null)
                {
                    // Update the quantity if the product is already present
                    products.Remove(prod);
                    product.Amount += prod.Amount;
                }
                products.Add(product);

                tempJson = JsonConvert.SerializeObject(products);

                NumberOfProducts = products.Sum(x => x.Amount);
                Products = products;

                await _localStorageService.SetItemAsStringAsync("cart", tempJson);
                await RefreshShoppingCartAsync();
                _toastService.ShowSuccess($"{product.Name} has been added to the order");

                return true;
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("cart");
                OnShoppingCartChange?.Invoke();
                return false;
            }
        }


        /// <summary>
        /// Updates the shopping cart properties and notifies any listeners of the change.
        /// </summary>
        public async Task RefreshShoppingCartAsync()
        {
            try
            {
                var jsonProducts = await _localStorageService.GetItemAsStringAsync("cart");
                Products = JsonConvert.DeserializeObject<List<ProductDTO>>(jsonProducts);
                NumberOfProducts = Products.Sum(x => x.Amount);

                await OnShoppingCartChange.Invoke();
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("cart");
            }
        }


        /// <summary>
        /// Persists the current state of the shopping cart to local storage.
        /// </summary>
        public async Task SaveShoppingCartAsync()
        {
            try
            {
                var jsonProducts = JsonConvert.SerializeObject(Products);

                await _localStorageService.SetItemAsStringAsync("cart", jsonProducts);
                await _jSRuntime.InvokeVoidAsync("console.log", "Saving Shopping Cart");
                await RefreshShoppingCartAsync();
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("cart");
            }
        }


        /// <summary>
        /// Deletes the entire shopping cart from local storage.
        /// </summary>
        public async Task DeleteShoppingCartAsync() =>
            await _localStorageService.RemoveItemAsync("cart");


        /// <summary>
        /// Deletes a single product from the cart by its ID.
        /// </summary>
        /// <param name="productId">ID of the product to delete.</param>
        public async Task DeleteSingleProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Products.Remove(product);
                await SaveShoppingCartAsync();
            }
        }
    }
}
