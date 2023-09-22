using Microsoft.JSInterop;

namespace PizzaPlace.BlazorServer.Helpers
{
    public static class MyExtensonMethods
    {
        public static async Task LogAsync(this IJSRuntime runtime, string message) =>
            await runtime.InvokeVoidAsync("console.log", message);

    }
}
