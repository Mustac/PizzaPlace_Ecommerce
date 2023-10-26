using AutoMapper;
using Blazored.Toast.Services;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.BlazorServer.Helpers;
using PizzaPlace.BlazorServer.Helpers.Enums;
using PizzaPlace.BlazorServer.Models.DTOs;
using PizzaPlace.BlazorServer.Models.DTOs.Products;
using PizzaPlace.BlazorServer.Services.BaseServices;
using PizzaPlace.BlazorServer.Services.EventServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.BlazorServer.Services;

/// <summary>
/// Provides services related to product management.
/// </summary>
public class ProductService : BaseService
{

        private readonly IJSRuntime _jSRuntime;

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

         _mapper.Map(productDto, product);

         var success = await context.SaveChangesAsync() > 0;

         if (success)
         {
             await _globalService.Product.EventTriggers.TriggerProductUpdated(productDto);
             return OperationResponse.Ok();
         }

         return OperationResponse.Fail();

     }, notifications: true);


    /// <summary>
    /// Asynchronously retrieves a collection of products based on a specified criteria.
    /// </summary>
    /// <param name="productRange">The range or category of products to retrieve.</param>
    /// <returns>A collection of products that match the specified criteria.</returns>
    public async Task<OperationResponse<IEnumerable<ProductDTO>>> GetAsync(ProductRange productRange = ProductRange.Discounted)
     => await ProcessRequestAsync<IEnumerable<ProductDTO>>(async (context) =>
     {
         IEnumerable<Product> products = new List<Product>();

         if (productRange == ProductRange.All)
             products = await context.Products.OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
         else if (productRange == ProductRange.FullPrice)
             products = await context.Products.Where(x => !x.IsArchived && x.DiscountedPrice == 0).OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
         else if (productRange == ProductRange.ALlActive)
             products = await context.Products.Where(x => !x.IsArchived).OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
         else if (productRange == ProductRange.Archived)
             products = await context.Products.Where(x => x.IsArchived).OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
         else if (productRange == ProductRange.Discounted)
             products = await context.Products.Where(x => !x.IsArchived && x.DiscountedPrice > 0).OrderBy(x => x.DiscountedPrice > 0).ThenBy(x => x.Name).ToListAsync();

         var dto = _mapper.Map<IEnumerable<ProductDTO>>(products);

         var response = OperationResponse<IEnumerable<ProductDTO>>.CreateDataResponse(dto);

         return response;
     });

    /// <summary>
    /// Asynchronously retrieves a collection of products based on a specified criteria.
    /// </summary>
    /// <param name="productRange">The range or category of products to retrieve.</param>
    /// <returns>A collection of products that match the specified criteria.</returns>
    public async Task<OperationResponse<ProductDTO>> GetByIdAsync(int Id)
    => await ProcessRequestAsync<ProductDTO>(async (context) =>
    {
        var product = await context.Products.FirstOrDefaultAsync(x=>x.Id == Id);

        if (product is null)
            return OperationResponse<ProductDTO>.NotFound();

        var productDTO = _mapper.Map<ProductDTO>(product);

        return OperationResponse<ProductDTO>.Ok(productDTO);

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
    public async Task<OperationResponse> HardDeleteAsync(int Id)
     => await ProcessRequestAsync(async (context) =>
     {
         var product = await context.Products.FirstOrDefaultAsync(x => x.Id == Id);

         if (product == null)
             return OperationResponse.NotFound();

         context.Products.Remove(product);

         bool success = await context.SaveChangesAsync() > 0;

         if (success)
         {
             var productDTO = _mapper.Map<ProductDTO>(product);
             await _globalService.Product.EventTriggers.TriggerProductDeleted(productDTO);
             return OperationResponse.Ok();
         }

         return OperationResponse.Fail();
     });
}
