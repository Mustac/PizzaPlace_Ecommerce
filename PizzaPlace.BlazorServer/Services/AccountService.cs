

using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PizzaPlace.BlazorServer.Services
{
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
                List<AddressDTO> addresses = await context.Addresses.Where(x=>x.UserId == userId).Select(x=> new AddressDTO
                {
                    City = x.City,
                    Id = x.Id,
                    Street = x.Street,
                    Zip = x.Zip
                }).ToListAsync();

                return OperationResponse<IEnumerable<AddressDTO>>.CreateDataResponse(addresses);
            });
    }
}
