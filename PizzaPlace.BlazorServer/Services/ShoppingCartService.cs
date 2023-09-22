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

        public int NumberOfUnseenItems { get; private set; }

        public event Action ShoppingCartAddProduct;
        public event Action<int> OnAddUnseenProductToCart;

        public ShoppingCartService(IToastService toastService, ILocalStorageService localStorageService)
        {
            _toastService = toastService;
            _localStorageService = localStorageService;
        }

        public async Task<bool> AddToShoppingCartAsync(ProductInfo product)
        {
            var tempJson = "";
            int amount = 0;
            try
            {
                var products = await GetShoppingCartAsync();

                if (products.Count() == 0)
                {
                    products = new List<ProductInfo> { product };

                    tempJson = JsonConvert.SerializeObject(products);
                }
                else
                {

                    // find if the product is already in the cart so we can add the amount on it
                    var prod = products.FirstOrDefault(x => x.Id == product.Id);


                    // if prod is found then we must modify it
                    if (prod is not null)
                    {
                        prod.Amount += product.Amount;
                        prod.Name = product.Name;
                        products.Remove(prod);
                        products.Add(prod);
                    }
                    // if it is not found that we have to add argument object
                    else
                    {
                        products.Add(product);
                    }


                    tempJson = JsonConvert.SerializeObject(products);



                    ShoppingCartAddProduct?.Invoke();
                }

                await _localStorageService.SetItemAsStringAsync("cart", tempJson);
                _toastService.ShowSuccess($"{product.Name} has been added to the order");

                return true;
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("cart");
                ShoppingCartAddProduct?.Invoke();
                return false;
            }
        }

        public async Task<IList<ProductInfo>> GetShoppingCartAsync()
        {
            try
            {
                var jsonProducts = await _localStorageService.GetItemAsStringAsync("cart");

                var products = JsonConvert.DeserializeObject<List<ProductInfo>>(jsonProducts);

                return products;
            }
            catch
            {
                return new List<ProductInfo>();
            }
        }


        public async Task AddToUnseenCartNumber(int amount)
        {
            try
            {
                var tempAmount = await GetUnseenCartNumberAsync();
                NumberOfUnseenItems = amount + tempAmount;
                OnAddUnseenProductToCart?.Invoke(NumberOfUnseenItems);
                await _localStorageService.SetItemAsStringAsync("upn", NumberOfUnseenItems.ToString());
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("upn");
            }
        }

        public async Task<int> GetUnseenCartNumberAsync()
        {
            try
            {
                // unseen product number
                var upn = await _localStorageService.GetItemAsStringAsync("upn");
                return int.Parse(upn);
            }
            catch
            {
                await _localStorageService.RemoveItemAsync("upn");
                return 0;
            }
        }

        public async Task ResetUnseenCartNumberAsync() =>
            await _localStorageService.RemoveItemAsync("upn");
    }
}
