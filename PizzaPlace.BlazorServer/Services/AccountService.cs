

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PizzaPlace.BlazorServer.Pages.Manager;
using System.Configuration;

namespace PizzaPlace.BlazorServer.Services;

public class AccountService : BaseService
{
    public Func<Task>? OnLogoutAsync;
    public Func<Task>? OnLoginAsync;

    public AccountService(GlobalService globalEventService, IMapper mapper, IToastService toastService) : base(globalEventService, mapper, toastService)
    {
    }

    public async Task<OperationResponse<IEnumerable<AddressDTO>>> GetAddressAsync(string userId)
        => await ProcessRequestAsync(async (context) =>
        {
            List<AddressDTO> addresses = await context.Addresses.Where(x => x.UserId == userId).Select(x => new AddressDTO
            {
                City = x.City,
                Id = x.Id,
                Street = x.Street,
                Zip = x.Zip
            }).ToListAsync();

            return OperationResponse<IEnumerable<AddressDTO>>.CreateDataResponse(addresses);
        });

    public async Task<OperationResponse> AddAddressToUserAsync(string userId, AddressDTO addressDTO)
    => await ProcessRequestAsync(async context =>
    {
        var user = await context.Users.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == userId);

        if (user is null)
            return OperationResponse.NotFound();

        var addressCount = user.Addresses?.Count();

        if (addressCount is null || addressCount <= 5)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            address.UserId = userId;
            await context.Addresses.AddAsync(address);
            bool success = await context.SaveChangesAsync() > 0;

            if (success)
            {
                return OperationResponse.Ok("Address added");
            }
            else
            {
                _toastService.ShowError("Address could not be added");
               return OperationResponse.Fail();
            }



        }
        _toastService.ShowInfo("Too many adresses");
        return OperationResponse.Fail("too many addresses");

    }, notifications: true);

    public async Task<OperationResponse> DeleteAddressAsync(string userId, int addressId)
        => await ProcessRequestAsync(async context =>
    {
        var user = await context.Users.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == userId);

        if (user is null || user.Addresses is null)
            return OperationResponse.NotFound();

        var address = user.Addresses.First(x => x.Id == addressId);

        context.Addresses.Remove(address);

        return await context.SaveChangesAsync() > 0 ? OperationResponse.Ok() : OperationResponse.Fail();

    }, notifications:true);

    public async Task<OperationResponse<ApplicationUser>> GetUserAsync(string userId)
        => await ProcessRequestAsync(async context =>
        {
            var user = await context.Users.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == userId);

            if(user is null)
                return OperationResponse<ApplicationUser>.NotFound();

            return OperationResponse<ApplicationUser>.CreateDataResponse(user);
        });

    public async Task<OperationResponse<IEnumerable<Order>>> GetUserOrders(string userId, int fromRecord, int amount)
        => await ProcessRequestAsync(async context =>
        {
            IEnumerable<Order> orders = await context.Orders.Include(x=>x.OrderProducts).ThenInclude(x=>x.Product).Where(x=>x.UserId == userId).Skip(fromRecord).Take(amount).ToListAsync() as IEnumerable<Order>;

            return OperationResponse<IEnumerable<Order>>.CreateDataResponse(orders);
        });
}
