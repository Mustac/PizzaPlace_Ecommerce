using AutoMapper;
using Blazored.Toast.Services;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.BlazorServer.Helpers;
using PizzaPlace.BlazorServer.Helpers.Enums;
using PizzaPlace.BlazorServer.Models.DTOs;
using PizzaPlace.BlazorServer.Models.DTOs.Products;
using PizzaPlace.BlazorServer.Services.BaseServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.BlazorServer.Services;

/// <summary>
/// Provides services related to product management.
/// </summary>
public class ProductService : BaseService
{

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
    public ProductService(DataContext context, GlobalEventService globalEventService, IMapper mapper, IToastService toastService)
        : base(context, globalEventService, mapper, toastService)
    {
    }


    /// <summary>
    /// Asynchronously creates a new product in the database.
    /// </summary>
    /// <param name="productDto">The data transfer object containing product details.</param>
    /// <returns>The created product entity or null if the creation fails.</returns>
    public async Task<OperationResponse> CreateProductAsync(ProductDTO productDto)
        => await ProcessRequestAsync(async () =>
        {
            Product product = new Product(productDto.Name, productDto.Price, productDto.Ingredients);

            _context.Products.Add(product);

            var successSave = await _context.SaveChangesAsync() > 0;

            if (successSave)
            {
                if (_globalEventService.OnProductChange is not null) await _globalEventService.OnProductChange.Invoke();
                return OperationResponse.Ok();
            }

            return OperationResponse.Fail();
        }, notifications: true);


    /// <summary>
    /// Asynchronously updates a product in the database.
    /// </summary>
    /// <param name="productDto">The data transfer object containing updated product details.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the update operation.</returns>
    public async Task<OperationResponse> UpdateProductAsync(ProductDTO productDto)
     => await ProcessRequestAsync(async () =>
     {
         var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productDto.Id);

         if (product is null) return OperationResponse.NotFound();

         product = _mapper.Map<Product>(productDto);

         var success = await _context.SaveChangesAsync() > 0;

         if (success)
         {
             if (_globalEventService.OnProductChange is not null)
                 await _globalEventService.OnProductChange.Invoke();
         }

         return OperationResponse.Fail();

     }, notifications: true);


    /// <summary>
    /// Asynchronously retrieves a collection of products based on a specified criteria.
    /// </summary>
    /// <param name="productRange">The range or category of products to retrieve.</param>
    /// <returns>A collection of products that match the specified criteria.</returns>
    public async Task<OperationResponse<IEnumerable<ProductDTO>>> GetAsync(ProductRange productRange = ProductRange.Discounted)
     => await ProcessRequestAsync<IEnumerable<ProductDTO>>(async () =>
     {
         IEnumerable<Product> products = new List<Product>();

         if (productRange == ProductRange.All)
             products = await _context.Products.OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
         else if (productRange == ProductRange.Active)
             products = await _context.Products.Where(x => !x.IsArchived).OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
         else if (productRange == ProductRange.Archived)
             products = await _context.Products.Where(x => x.IsArchived).OrderBy(x => x.DiscountedPrice == 0).ThenBy(x => x.Name).ToListAsync();
         else if(productRange == ProductRange.Discounted)
             products = await _context.Products.Where(x => !x.IsArchived).OrderBy(x => x.DiscountedPrice > 0).ThenBy(x => x.Name).ToListAsync();

         var dto = _mapper.Map<IEnumerable<ProductDTO>>(products);

         var response = OperationResponse<IEnumerable<ProductDTO>>.CreateDataResponse(dto);

         return response;
     });


    /// <summary>
    /// Asynchronously restores a previously archived product.
    /// </summary>
    /// <param name="Id">The unique identifier of the product to be restored.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the restoration.</returns>
    public async Task<OperationResponse> RestoreArchivedAsync(int Id)
     => await ProcessRequestAsync(async () =>
     {
         var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);

         if (product == null)
             return OperationResponse.NotFound();

         product.IsArchived = false;

         bool success = await _context.SaveChangesAsync() > 0;

         if (success)
         {
             if (_globalEventService.OnProductChange is not null)
                 await _globalEventService.OnProductChange.Invoke();

             return OperationResponse.Ok();
         }

         return OperationResponse.Fail();
     }, notifications:true);


    /// <summary>
    /// Asynchronously archives a product.
    /// </summary>
    /// <param name="Id">The unique identifier of the product to be archived.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the archiving process.</returns>
    public async Task<OperationResponse> ArchiveAsync(int Id)
     =>await ProcessRequestAsync(async () =>
     {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (product == null)
                return OperationResponse.NotFound();

            product.IsArchived = true;

            bool success = await _context.SaveChangesAsync() > 0;

            if (success)
            {
                if (_globalEventService.OnProductChange is not null)
                    await _globalEventService.OnProductChange.Invoke();
                return OperationResponse.Ok();
            }

            return OperationResponse.Fail();
     });


    /// <summary>
    /// Asynchronously deletes a product from the database permanently.
    /// </summary>
    /// <param name="Id">The unique identifier of the product to be deleted.</param>
    /// <returns>An <see cref="OperationResponse"/> indicating the result of the deletion process.</returns>
    public async Task<OperationResponse> HardDeleteAsync(int Id)
     => await ProcessRequestAsync(async () =>
     {
         var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);

         if (product == null)
             return OperationResponse.NotFound();

         _context.Products.Remove(product);

         bool success = await _context.SaveChangesAsync() > 0;

         if (success)
         {
             if (_globalEventService.OnProductChange is not null)
                 await _globalEventService.OnProductChange.Invoke();
             return OperationResponse.Ok();
         }

         return OperationResponse.Fail();
     });
}
