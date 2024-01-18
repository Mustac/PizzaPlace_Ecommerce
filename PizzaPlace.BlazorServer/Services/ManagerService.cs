
using Microsoft.AspNetCore.Identity;
using System.Configuration;

namespace PizzaPlace.BlazorServer.Services
{
    public class ManagerService : BaseService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public ManagerService(GlobalService globalEventService, IMapper mapper, IToastService toastService
            , UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
            : base(globalEventService, mapper, toastService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<OperationResponse<IEnumerable<ApplicationUser>>> GetEmployeesAsync()
            => await ProcessRequestAsync<IEnumerable<ApplicationUser>>(async context =>
            {
                var deliveryUsers = await _userManager.GetUsersInRoleAsync(Role.Delivery);
                var chefUser = await _userManager.GetUsersInRoleAsync(Role.Chef);
                var managerUser = await _userManager.GetUsersInRoleAsync(Role.Manager);

                if (deliveryUsers is null && chefUser is null)
                    return OperationResponse<IEnumerable<ApplicationUser>>.Fail();

                return OperationResponse<IEnumerable<ApplicationUser>>.CreateDataResponse(deliveryUsers.Concat(chefUser).Concat(managerUser));

            });
    }
}
