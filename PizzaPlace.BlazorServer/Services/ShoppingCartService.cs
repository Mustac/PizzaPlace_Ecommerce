using Blazored.Toast.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaPlace.BlazorServer.Helpers;
using System.Text.Json;

namespace PizzaPlace.BlazorServer.Services
{
    public class ShoppingCartService
    {
        private readonly IToastService _toastService;
        private readonly ILocalStorageService _localStorageService;

        public int NumberOfItems { get; private set; }
        public IList<ProductInfo> Products { get; private set; } = new List<ProductInfo>();

        public event Action OnReloadShoppingCart;

        public ShoppingCartService(IToastService toastService, ILocalStorageService localStorageService)
        {
            _toastService = toastService;
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// Add productinfo to current products, sum it up if same product, save it and call UpdateShoppingCartAsync that will also trigger OnReloadShoppingCart
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> AddToShoppingCartAsync(ProductInfo product)
        {
            var tempJson = "";
            
            try
            {
                var productsJson = await _localStorageService.GetItemAsStringAsync("cart");
                var products = new List<ProductInfo>();

                if (string.IsNullOrEmpty(productsJson))
                {
                    products = new List<ProductInfo> { product };

                    tempJson = JsonConvert.SerializeObject(products);
                }
                else
                {
                    products = JsonConvert.DeserializeObject<List<ProductInfo>>(productsJson);

                    // find if the product is already in the cart so we can add the amount on it
                    var prod = products.FirstOrDefault(x => x.Id == product.Id);


                    // if prod is found then we must modify it
                    if (prod is not null)
                    {
                        products.Remove(prod);
                        product.Amount+= prod.Amount;
                        products.Add(product);
                    }
                    // if it is not found that we have to add argument object
                    else
                    {
                        products.Add(product);
                    }

                    tempJson = JsonConvert.SerializeObject(products);
                }

                NumberOfItems = products.Select(x => x.Amount).Sum();
                Products = products;


                await _localStorageService.SetItemAsStringAsync("cart", tempJson);
                await UpdateShoppingCartAsync();
                _toastService.ShowSuccess($"{product.Name} has been added to the order");

                return true;
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("cart");
                OnReloadShoppingCart?.Invoke();
                return false;
            }
        }

        /// <summary>
        /// Update/Refreshes parameters, also call OnReloadShoppingCart
        /// </summary>
        /// <returns></returns>
        public async Task UpdateShoppingCartAsync()
        {
            try
            {
                var jsonProducts = await _localStorageService.GetItemAsStringAsync("cart");

                Products = JsonConvert.DeserializeObject<List<ProductInfo>>(jsonProducts);

                NumberOfItems = Products.Select(x => x.Amount).Sum();

                OnReloadShoppingCart.Invoke();
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("cart");
            }
        }


    }
}
