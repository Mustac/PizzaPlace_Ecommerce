
using AutoMapper;
using PizzaPlace.BlazorServer.Services.EventServices;

namespace PizzaPlace.BlazorServer.Services
{
    public class AccountService : BaseService
    {
        public AccountService(GlobalService globalEventService, IMapper mapper, IToastService toastService) : base(globalEventService, mapper, toastService)
        {
        }


        public event Action OnUserLogout;
        public event Action OnUserLogin;
    }
}
