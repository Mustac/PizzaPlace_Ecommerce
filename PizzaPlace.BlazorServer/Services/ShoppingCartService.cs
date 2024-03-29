﻿namespace PizzaPlace.BlazorServer.Services;

public class ShoppingCartService : IDisposable
{
    private readonly GlobalService _globalService;
    private readonly ILocalStorageService _localStorageService;
    private readonly IJSRuntime _jSRuntime;
    private readonly IMapper _mapper;
    private readonly ProductService _productService;

    public ShoppingCartService(GlobalService globalService, ILocalStorageService localStorageService, IJSRuntime jSRuntime, IMapper mapper, ProductService productService)
    {
        _globalService = globalService;
        _localStorageService = localStorageService;
        _jSRuntime = jSRuntime;
        _mapper = mapper;
        _productService = productService;
        _globalService.Product.OnProductChange += CheckShoppingCartProducts;
    }


    public event Func<Task>? OnShoppingCartChange;
    public event Func<ProductDTO, Task>? OnAddToCartProductExist;

    public ProductOrderDTO ProductOrder { get; set; } = new ProductOrderDTO();

    public List<ProductDTO> Products
    {
        get
        {
            if (ProductOrder is not null && ProductOrder.Products is not null)
                return ProductOrder.Products;

            return new List<ProductDTO>();
        }
    }

    public int NumberOfProducts { get; private set; }

    /// <summary>
    /// Gets the total cart price of the products without discounts.
    /// </summary>
    public float TotalCartPrice => Products.Where(x => !x.ProductNeedsDeletion).Sum(x => x.Amount * x.Price);

    /// <summary>
    /// Gets the total price with discounts applied.
    /// </summary>
    public float TotalPriceWithDiscounts =>
        Products.Where(x => x.DiscountedPrice > 0 && !x.ProductNeedsDeletion)
                .Sum(x => x.DiscountedPrice * x.Amount) +
        Products.Where(x => x.DiscountedPrice == 0 && !x.ProductNeedsDeletion)
               .Sum(x => x.Price * x.Amount);


    /// <summary>
    /// Computes the total amount discounted for the cart.
    /// </summary>
    public float TotalDiscounts => TotalCartPrice - TotalPriceWithDiscounts;



        public async Task CheckShoppingCartProducts(ProductDTO product)
        => await ErrorHanding(async () =>
        {
            var response = await _productService.GetAsync(ProductRange.ALlActive);

            if (response.Result != OperationResult.Ok)
                return;

            var productsDB = response.Data;

            var prodsToDelete = Products.Where(x => !productsDB.Any(y => y.Id == x.Id)).ToList();

            ProductOrder.CanUserOrder = prodsToDelete.Count == 0;

            foreach (var prod in prodsToDelete)
            {
                prod.ProductNeedsDeletion = true;
            }

            await SaveShoppingCartToLocalStorageAsync();

            if (OnShoppingCartChange is not null)
                await OnShoppingCartChange.Invoke();
        });


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
            var productCartDTO = _mapper.Map<ProductDTO>(product);

            if (productsOrderDTO is null || productsOrderDTO.Products is null || productsOrderDTO.Products.Count == 0)
            {
                ProductOrder.Products = new List<ProductDTO>();
                ProductOrder.Products.Add(productCartDTO);
                ProductOrder.CanUserOrder = true;
            }
            else
            {
                var tempProd = productsOrderDTO.Products.FirstOrDefault(x => x.Id == product.Id);

                if (tempProd is not null && ProductOrder.Products.Any(x => x.Id == tempProd.Id))
                {
                    
                    if (OnAddToCartProductExist is not null)
                        await OnAddToCartProductExist.Invoke(product);
                }
                else
                {
                    ProductOrder.Products.Add(productCartDTO);
          
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

            if (ProductOrder == null)
            {
                await DeleteShoppingCartAsync();
                ProductOrder = new ProductOrderDTO();
                return;
            }

            NumberOfProducts = Products.Where(x => !x.ProductNeedsDeletion).Sum(x => x.Amount);


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
    public async Task DeleteShoppingCartAsync()
    {
        await _localStorageService.RemoveItemAsync("cart");
        ProductOrder = new ProductOrderDTO();
        ProductOrder.Products = new List<ProductDTO>();
        if (OnShoppingCartChange is not null)
            await OnShoppingCartChange.Invoke();
    }


    /// <summary>
    /// Deletes a single product from the cart by its ID.
    /// </summary>
    /// <param name="productId">ID of the product to delete.</param>
    public async Task DeleteSingleProduct(int productId)
    => await ErrorHanding(async () =>
    {
        var product = Products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            Products.Remove(product);
            await SaveShoppingCartToLocalStorageAsync();
        }
        await ReloadShoppingCartListAsync();

        ProductOrder.CanUserOrder = Products.Any(x => !x.ProductNeedsDeletion);

        if (OnShoppingCartChange is not null)
            await OnShoppingCartChange.Invoke();

    });


    public void Dispose()
    {
        _globalService.Product.OnProductChange -= CheckShoppingCartProducts;
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
