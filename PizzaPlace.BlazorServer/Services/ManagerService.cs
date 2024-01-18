
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.BlazorServer.Helpers;
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

        public async Task<OperationResponse<IEnumerable<UserDTO>>> GetUsersInRoleAsync(string role)
            => await ProcessRequestAsync(async context =>
            {
                
                var identityRole = await _roleManager.FindByNameAsync(role);

                if (identityRole is null)
                    return OperationResponse<IEnumerable<UserDTO>>.Fail();
                
                var userIds = await context.UserRoles.Where(x=>x.RoleId.Equals(identityRole.Id)).Select(x=>x.UserId).ToListAsync();

                if(userIds is null)
                    return OperationResponse<IEnumerable<UserDTO>>.Fail();

                if (!userIds.Any())
                    return OperationResponse<IEnumerable<UserDTO>>.CreateDataResponse(new List<UserDTO>());

                var users = await context.Users.Include(x=>x.Addresses).Where(x => userIds.Contains(x.Id))
                    .Select(x=> new UserDTO
                    {
                        Addresses = x.Addresses.Select(add => $"{add.Street}, {add.Zip} {add.City}"),
                        Email = x.Email,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Phone = x.PhoneNumber,
                        Role = role
                    }).ToListAsync();

                if(users is null)
                    return OperationResponse<IEnumerable<UserDTO>>.Fail();

                return OperationResponse<IEnumerable<UserDTO>>.CreateDataResponse(users);

            });
    }
}
