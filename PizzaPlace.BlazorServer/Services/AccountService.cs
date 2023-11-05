namespace PizzaPlace.BlazorServer.Services
{
    public class AccountService
    {
        public Func<Task>? OnLogoutAsync;
        public Func<Task>? OnLoginAsync;
    }
}
