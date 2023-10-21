using AutoMapper;
using PizzaPlace.BlazorServer.Models;
using PizzaPlace.BlazorServer.Services.EventServices;

namespace PizzaPlace.BlazorServer.Services;

public class ShoppingCartService : IDisposable
{
    private readonly GlobalService _globalService;
    private readonly ILocalStorageService _localStorageService;
    private readonly IJSRuntime _jSRuntime;
    private readonly IMapper _mapper;

    public ShoppingCartService(GlobalService globalService, ILocalStorageService localStorageService, IJSRuntime jSRuntime, IMapper mapper)
    {
        _globalService = globalService;
        _localStorageService = localStorageService;
        _jSRuntime = jSRuntime;
        _mapper = mapper;
        _globalService.Product.OnProductUpdated += ProductUpdateChanged;
        _globalService.Product.OnProductArchived += ProductDeleteChanged;
        _globalService.Product.OnProductRestored += ProductRestoreChanged;
    }


    public event Func<Task>? OnShoppingCartChange;
    public event Func<ProductDTO, Task>? OnAddToCartProductExist;

    public ProductOrderDTO ProductOrder { get; set; } = new ProductOrderDTO();

    public List<ProductCartDTO> ProductCart { get => ProductOrder.ProductCart; }

    public int NumberOfProducts { get; private set; }

    /// <summary>
    /// Gets the total cart price of the products without discounts.
    /// </summary>
    public float TotalCartPrice => ProductCart.Where(x=>!x.ProductNeedsDeletion && !x.ProductNeedsUpdate).Sum(x => x.Amount * x.Price);

    /// <summary>
    /// Gets the total price with discounts applied.
    /// </summary>
    public float TotalPriceWithDiscounts =>
        ProductCart.Where(x => x.DiscountedPrice > 0 && !x.ProductNeedsDeletion && !x.ProductNeedsUpdate)
                .Sum(x => x.DiscountedPrice * x.Amount) +
        ProductCart.Where(x => x.DiscountedPrice == 0 && !x.ProductNeedsDeletion && !x.ProductNeedsUpdate)
               .Sum(x => x.Price * x.Amount);

 
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
        => await ErrorHanding(async () =>
        {
            if (product is null)
                return false;

            var productsOrderDTO = await _localStorageService.GetItemAsync<ProductOrderDTO>("cart");
            var productCartDTO = _mapper.Map<ProductCartDTO>(product);


            if (productsOrderDTO is null || productsOrderDTO.ProductCart is null || productsOrderDTO.ProductCart.Count == 0)
            {
                ProductOrder.ProductCart.Add(productCartDTO);
            }
            else
            {
                var tempProd = productsOrderDTO.ProductCart.FirstOrDefault(x => x.Id == product.Id);

                if (tempProd is not null && ProductOrder.ProductCart.Any(x => x.Id == tempProd.Id))
                {
                    if (OnAddToCartProductExist is not null)
                        await OnAddToCartProductExist.Invoke(product);
                }
                else
                {
                    ProductOrder.ProductCart.Add(productCartDTO);
                }

            }

            await SaveShoppingCartToLocalStorageAsync();
            return true;
        });


    /// <summary>
    /// Updates the shopping cart properties and notifies any listeners of the change.
    /// </summary>
    public async Task ReloadShoppingCartListAsync()
        => await ErrorHanding(async () =>
        {
            ProductOrder = await _localStorageService.GetItemAsync<ProductOrderDTO>("cart");
            NumberOfProducts = ProductCart.Where(x => !x.ProductNeedsUpdate && !x.ProductNeedsDeletion).Sum(x => x.Amount);
        });



    /// <summary>
    /// Persists the current state of the shopping cart to local storage.
    /// </summary>
    public async Task SaveShoppingCartToLocalStorageAsync()
         => await ErrorHanding(async () =>
            {
                await _localStorageService.SetItemAsync("cart", ProductOrder);

                await ReloadShoppingCartListAsync();

                if (OnShoppingCartChange is not null)
                    await OnShoppingCartChange.Invoke();
            });



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
    => await ErrorHanding(async () =>
    {
        var product = ProductCart.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            ProductCart.Remove(product);
            await SaveShoppingCartToLocalStorageAsync();
        }
        await ReloadShoppingCartListAsync();

        ProductOrder.CanUserOrder = ProductCart.Any(x => !x.ProductNeedsUpdate && !x.ProductNeedsDeletion);

        if (OnShoppingCartChange is not null)
            await OnShoppingCartChange.Invoke();

    });


    async Task ProductUpdateChanged(ProductDTO productDTO)
        => await ErrorHanding(async () =>
    {
        var productCartDTO = ProductCart.FirstOrDefault(x => x.Id == productDTO.Id);

        if (productCartDTO == null)
            return;

        productCartDTO = _mapper.Map<ProductCartDTO>(productCartDTO);
        productCartDTO.ProductNeedsUpdate = true;
        ProductOrder.CanUserOrder = false;

        await SaveShoppingCartToLocalStorageAsync();

        if (OnShoppingCartChange is not null)
            await OnShoppingCartChange.Invoke();
    });



    async Task ProductDeleteChanged(ProductDTO productDTO)
     => await ErrorHanding(async () =>
     {
         var productCartDTO = ProductCart.FirstOrDefault(x => x.Id == productDTO.Id);

         if (productCartDTO == null)
             return;

         productCartDTO = _mapper.Map<ProductCartDTO>(productCartDTO);
         productCartDTO.ProductNeedsDeletion = true;

         ProductOrder.CanUserOrder = false;

         await SaveShoppingCartToLocalStorageAsync();

         if (OnShoppingCartChange is not null)
             await OnShoppingCartChange.Invoke();
     });

    async Task ProductRestoreChanged(ProductDTO productDTO)
     => await ErrorHanding(async () =>
     {
         var productCartDTO = ProductCart.FirstOrDefault(x => x.Id == productDTO.Id);

         if (productCartDTO == null)
             return;

         productCartDTO = _mapper.Map<ProductCartDTO>(productCartDTO);
         productCartDTO.ProductNeedsDeletion = false;

         ProductOrder.CanUserOrder = ProductCart.Any(x => !x.ProductNeedsUpdate && !x.ProductNeedsDeletion);

         await SaveShoppingCartToLocalStorageAsync();

         if (OnShoppingCartChange is not null)
             await OnShoppingCartChange.Invoke();
     });


    public async Task ClickUpdateProductAsync(ProductDTO product)
        => await ErrorHanding(async () =>
    {
        var productCartDTO = ProductCart.FirstOrDefault(x => x.Id == product.Id);

        if (productCartDTO == null)
            return;

        productCartDTO.Name = product.Name;
        productCartDTO.Ingredients = product.Ingredients;
        productCartDTO.DiscountedPrice = product.DiscountedPrice;
        productCartDTO.Price = product.Price;
        productCartDTO.ProductNeedsUpdate = false;

        ProductOrder.CanUserOrder = ProductCart.Any(x => !x.ProductNeedsUpdate && !x.ProductNeedsDeletion);

        await SaveShoppingCartToLocalStorageAsync();

        if (OnShoppingCartChange is not null)
            await OnShoppingCartChange.Invoke();
    });

    public void Dispose()
    {
        _globalService.Product.OnProductArchived -= ProductUpdateChanged;
        _globalService.Product.OnProductDeleted -= ProductDeleteChanged;
    }
    private async Task ErrorHanding(Func<Task> func)
    {
        try
        {
            await func.Invoke();
        }
        catch
        {
            await _localStorageService.RemoveItemAsync("cart");
            ProductOrder = new ProductOrderDTO();
        }
        finally
        {
            if (OnShoppingCartChange != null) await OnShoppingCartChange.Invoke();
        }
    }

    private async Task<bool> ErrorHanding(Func<Task<bool>> func)
    {
        try
        {
           return await func.Invoke();
        }
        catch
        {
            await _localStorageService.RemoveItemAsync("cart");
            ProductOrder = new ProductOrderDTO();
            if (OnShoppingCartChange != null) await OnShoppingCartChange.Invoke();
            return false;
        }
    
    }
}
