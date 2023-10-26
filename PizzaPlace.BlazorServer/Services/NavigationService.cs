using Microsoft.JSInterop;
using PizzaPlace.BlazorServer.Helpers;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace PizzaPlace.BlazorServer.Services
{
    public class NavigationService
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly ILocalStorageService _localStorageService;

        public MobileNavigation MobileNav { get; }

        public NavigationService(IJSRuntime jSRuntime, ILocalStorageService localStorageService)
        {
            MobileNav = new MobileNavigation();
            _jSRuntime = jSRuntime;
            _localStorageService = localStorageService;
        }

        public class MobileNavigation
        {
            public event Action? OnOpened;
            public event Action? OnClosed;

            public bool IsOpen { get; private set; }

            public void NavigationClick(bool state)
            {
                if (IsOpen == state)
                    return; 

                IsOpen = state;
                NotifyStateChanged();
            }

            private void NotifyStateChanged()
            {
                if (IsOpen)
                   OnOpened?.Invoke();
                else
                    OnClosed?.Invoke();
            }
        }
    }
}