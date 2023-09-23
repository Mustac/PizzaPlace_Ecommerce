using Microsoft.JSInterop;
using PizzaPlace.BlazorServer.Helpers;

namespace PizzaPlace.BlazorServer.Services
{
    public class NavMenuService
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly ILocalStorageService _localStorageService;

        public event Action OnNavShowChanged;
        public event Action OnShoppingCartClicked;
        public bool NavShow { get; private set; }
        public bool CartShow { get; private set; }

        public NavMenuService(IJSRuntime jSRuntime, ILocalStorageService localStorageService)
        {
            _jSRuntime = jSRuntime;
            _localStorageService = localStorageService;
        }

        public void SetNavState(bool state)
        {
            NavShow = state;
            OnNavShowChanged?.Invoke();
        }

        public void SetCartState(bool state)
        {
            CartShow = state;
            OnShoppingCartClicked?.Invoke();
        }




    }
}
