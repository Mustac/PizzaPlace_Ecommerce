
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PizzaPlace.BlazorServer.Services
{
    public class OrderService : BaseService
    {
        public OrderService(GlobalService globalEventService, IMapper mapper, IToastService toastService) : base(globalEventService, mapper, toastService)
        {
        }


        public async Task<OperationResponse> OrderProductsAsnyc(ProductOrderDTO productOrder)
        => await ProcessRequestAsync(async (context) =>
        {

            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == productOrder.UserId);

            if (user is null)
                return OperationResponse.NotFound("User is invalid, please log in again");

            Address? address;
            IEnumerable<Product>? products;

            if (productOrder.Address is null || productOrder.Address.Id <= 0)
                return OperationResponse.Fail("Fail to select the address");


            address = await context.Addresses.FirstOrDefaultAsync(x => x.Id == productOrder.Address.Id);

            if (address is null)
                return OperationResponse.NotFound("Failed to find the address");

            if (productOrder.Products is null || !productOrder.Products.Any())
                return OperationResponse.Fail("Cart is empty");

            if (productOrder.TotalPrice <= 0 && productOrder.DiscountedPrice > productOrder.TotalPrice)
                return OperationResponse.Fail("Discounted price can't be higher than total price");

            products = await context.Products.Where(x => productOrder.Products.Select(y => y.Id).Contains(x.Id)).ToListAsync();

            Order order = new Order
            {
                DiscountedPrice = productOrder.DiscountedPrice,
                OrderStatus = OrderStatus.Pending,
                TimeOrdered = DateTime.UtcNow,
                TotalPrice = productOrder.TotalPrice,
                UserId = user.Id,
                FullAddress = $"{address.Street}, {address.Zip} {address.City}"
            };

            await context.Orders.AddAsync(order);

            List<OrderProduct> orderProduct = new List<OrderProduct>();

            foreach (var prod in productOrder.Products)
            {
                orderProduct.Add(new OrderProduct
                {
                    ProductId = prod.Id,
                    Quantity = prod.Amount,
                    Order = order,
                    Price = prod.DiscountedPrice == 0 ? prod.Price : prod.DiscountedPrice
                });
            }

            await context.OrderProducts.AddRangeAsync(orderProduct);

            return await context.SaveChangesAsync() > 0 ?
                OperationResponse.Ok("Order was paid and it is on its way") :
                OperationResponse.Fail();

        }, notifications: false);

        [Authorize(Roles = "Chef,Manager")]
        public async Task<OperationResponse<IEnumerable<Order>>> GetProcessingOrders()
            => await ProcessRequestAsync<IEnumerable<Order>>(async context =>
            {
                var orders = await context.Orders.Include(x=>x.OrderProducts).ThenInclude(x=>x.Product).Where(x => x.OrderStatus == OrderStatus.Cooking || x.OrderStatus == OrderStatus.Pending).ToListAsync();

                if (orders is null)
                    return OperationResponse<IEnumerable<Order>>.Fail();

                return OperationResponse<IEnumerable<Order>>.CreateDataResponse(orders);

            });
    }
}
