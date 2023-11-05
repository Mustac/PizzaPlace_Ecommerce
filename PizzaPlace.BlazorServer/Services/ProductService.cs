using Microsoft.EntityFrameworkCore;

namespace PizzaPlace.BlazorServer.Services;

/// <summary>
/// Provides services related to product management.
/// </summary>
public class ProductService : BaseService
{
    private readonly IJSRuntime _jSRuntime;
    private IEnumerable<ProductDTO> _products { get => _globalService.Product.ProductDTOs; }

    /// <summary>
    /// The ProductService provides methods for managing product-related operations in the system, such as 
    /// creating, updating, deleting, and retrieving products from the database. It supports operations like:
    /// - Creating a new product in the database.
    /// - Updating existing product details.
    /// - Retrieving a collection of products based on specified criteria like discounted or archived.
    /// - Archiving a product, making it inaccessible for normal operations.
    /// - Restoring an archived product, making it available again for normal operations.
    /// - Permanently deleting a product from the database.
    /// </summary>
    public ProductService(GlobalService globalService, IMapper mapper, IToastService toastService)
        : base(globalService, mapper, toastService)
    {

    }


    /// <summary>
    /// Asynchronously creates a new product in the database.
    /// Upon successful creation, this method will trigger the "ProductCreated" and "ProductChanged" events.
    /// </summary>
    /// <param name="productDto">The data transfer object containing product details.</param>
    /// <returns>The created product entity or null if the creation fails.</returns>
    public async Task<OperationResponse<ProductDTO>> CreateProductAsync(ProductDTO productDto)
        => await ProcessRequestAsync<ProductDTO>(async (context) =>
        {
            Product product = new Product(productDto.Name, productDto.Price, productDto.Ingredients);

            var response = await context.Products.AddAsync(product);

            var successSave = await context.SaveChangesAsync() > 0;

            if (successSave)
            {
                var productDTO = _mapper.Map<ProductDTO>(response.Entity);
                await UpdateProductsInMemory(context);
                await _globalService.Product.EventTriggers.TriggerProductCreated(productDTO);
                return OperationResponse<ProductDTO>.Ok(productDTO);
            }

            return OperationResponse<ProductDTO>.Fail();
        }, notifications: true);


    /// <summary>
    /// Asynchronously updates a product in the database.
    /// Upon successful update, this method will trigger the "ProductUpdated" and "ProductChanged" events.
    /// </summary>
    /// <param name="productDto">The data transfer object containing updated product details.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the update operation.</returns>
    public async Task<OperationResponse> UpdateProductAsync(ProductDTO productDto)
    => await ProcessRequestAsync(async (context) =>
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == productDto.Id);

        if (product is null) return OperationResponse.NotFound();

        product.IsDeleted = true;

        Product newProd = _mapper.Map<Product>(productDto);
        newProd.Id = 0;
        newProd.IsDeleted = false;

        await context.AddAsync(newProd);

        // Save changes and check success
        var success = await context.SaveChangesAsync() > 0;
        if (success)
        {
            await UpdateProductsInMemory(context);
            await _globalService.Product.EventTriggers.TriggerProductUpdated(productDto);
            return OperationResponse.Ok();
        }

        return OperationResponse.Fail();
    }, notifications: true);



    /// <summary>
    /// Retrieves a collection of products based on a specified criteria.
    /// </summary>
    /// <param name="productRange">The range or category of products to retrieve.</param>
    /// <returns>A collection of products that match the specified criteria.</returns>
    public async Task<OperationResponse<IEnumerable<ProductDTO>>> GetAsync(ProductRange productRange = ProductRange.All)
     => await ProcessRequestAsync<IEnumerable<ProductDTO>>(async (context) =>
     {
         await LoadProductsInMemory(context);

         IEnumerable<ProductDTO>? selectedProducts = new List<ProductDTO>();

         if (_products is null)
             return OperationResponse<IEnumerable<ProductDTO>>.Fail();

         if (productRange == ProductRange.All)
             selectedProducts = _products;
         else if (productRange == ProductRange.FullPrice)
             selectedProducts = _products.Where(x => x.DiscountedPrice == 0 && !x.IsArchived);
         else if (productRange == ProductRange.ALlActive)
             selectedProducts = _products.Where(x => !x.IsArchived);
         else if (productRange == ProductRange.Archived)
             selectedProducts = _products.Where(x => x.IsArchived);
         else if (productRange == ProductRange.Discounted)
             selectedProducts = _products.Where(x => x.DiscountedPrice > 0 && !x.IsArchived);

         selectedProducts = selectedProducts.ToList();

         if (selectedProducts is null)
             return OperationResponse<IEnumerable<ProductDTO>>.NotFound();

         return OperationResponse<IEnumerable<ProductDTO>>.Ok(selectedProducts);

     });





    /// <summary>
    /// Asynchronously retrieves a collection of products based on a specified criteria.
    /// </summary>
    /// <param name="productRange">The range or category of products to retrieve.</param>
    /// <returns>A collection of products that match the specified criteria.</returns>
    public async Task<OperationResponse<ProductDTO>> GetByIdAsync(int Id)
    => await ProcessRequestAsync<ProductDTO>(async (context) =>
    {
        await LoadProductsInMemory(context);

        var product = _products.FirstOrDefault(x => x.Id == Id);

        if (product is null)
            return OperationResponse<ProductDTO>.NotFound();

        return OperationResponse<ProductDTO>.Ok(product);

    });



    /// <summary>
    /// Asynchronously restores a previously archived product.
    /// Upon successful restoration, this method will trigger the "ProductRestored" and "ProductChanged" events.
    /// </summary>
    /// <param name="Id">The unique identifier of the product to be restored.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the restoration.</returns>
    public async Task<OperationResponse> RestoreArchivedAsync(int Id)
 => await ProcessRequestAsync(async (context) =>
 {
     var product = await context.Products.FirstOrDefaultAsync(x => x.Id == Id);

     if (product == null)
         return OperationResponse.NotFound();

     product.IsArchived = false;

     bool success = await context.SaveChangesAsync() > 0;

     if (success)
     {
         var productDTO = _mapper.Map<ProductDTO>(product);
         await UpdateProductsInMemory(context);
         await _globalService.Product.EventTriggers.TriggerProductRestored(productDTO);
         return OperationResponse.Ok();
     }

     return OperationResponse.Fail();
 }, notifications: false);


    /// <summary>
    /// Asynchronously archives a product.
    /// Upon successful archiving, this method will trigger the "ProductArchived" and "ProductChanged" events.
    /// </summary>
    /// <param name="Id">The unique identifier of the product to be archived.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the archiving process.</returns>
    public async Task<OperationResponse> ArchiveAsync(int Id)
     => await ProcessRequestAsync(async (context) =>
     {
         var product = await context.Products.FirstOrDefaultAsync(x => x.Id == Id);

         if (product == null)
             return OperationResponse.NotFound();

         product.IsArchived = true;

         bool success = await context.SaveChangesAsync() > 0;

         if (success)
         {
             var productDTO = _mapper.Map<ProductDTO>(product);
             await UpdateProductsInMemory(context);
             await _globalService.Product.EventTriggers.TriggerProductArchived(productDTO);
             return OperationResponse.Ok();
         }

         return OperationResponse.Fail();
     });


    /// <summary>
    /// Asynchronously deletes a product from the database permanently.
    /// Upon successful deletion, this method will trigger the "ProductDeleted" and "ProductChanged" events.
    /// </summary>
    /// <param name="Id">The unique identifier of the product to be deleted.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the deletion process.</returns>
    public async Task<OperationResponse> DeleteAsync(int Id)
    => await ProcessRequestAsync(async (context) =>
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == Id);

        if (product is null)
            return OperationResponse.NotFound();

        product.IsDeleted = true;

        bool success = await context.SaveChangesAsync() > 0;

        if (success)
        {
            var productDTO = _mapper.Map<ProductDTO>(product);
            await UpdateProductsInMemory(context);
            await _globalService.Product.EventTriggers.TriggerProductDeleted(productDTO);
            return OperationResponse.Ok();
        }

        return OperationResponse.Fail();
    });

    /// <summary>
    /// Checks if the products are loaded into memory, and if not then load them
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task LoadProductsInMemory(DataContext context)
    {
        if (_globalService.Product.ProductDTOs is null)
        {
            var temp = (IEnumerable<Product>)await context.Products.Where(x=>!x.IsDeleted).OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
            _globalService.Product.ProductDTOs = _mapper.Map<IEnumerable<ProductDTO>>(temp);
        }
    }

    // pulls and reloads products that are storred in memory
    private async Task UpdateProductsInMemory(DataContext context)
    {
        var temp = (IEnumerable<Product>)await context.Products.Where(x=>!x.IsDeleted).OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
        _globalService.Product.ProductDTOs = _mapper.Map<IEnumerable<ProductDTO>>(temp);
    }
}
