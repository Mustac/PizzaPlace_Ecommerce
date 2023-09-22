namespace PizzaPlace.BlazorServer.Services
{
    public class MyStorageService
    {
        private readonly ILocalStorageService _localStorageService;

        public MyStorageService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

      
    }
}
