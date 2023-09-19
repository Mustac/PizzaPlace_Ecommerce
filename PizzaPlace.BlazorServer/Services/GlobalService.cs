using Microsoft.JSInterop;

namespace PizzaPlace.BlazorServer.Services
{
    public class GlobalService
    {
        private readonly IJSRuntime _jSRuntime;

        public event Action OnNavShowChanged;

        public bool NavShow { get; private set; }

        public GlobalService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }



        public void SetNavState(bool state)
        {
            NavShow = state;
            OnNavShowChanged?.Invoke();
        }
    }
}
