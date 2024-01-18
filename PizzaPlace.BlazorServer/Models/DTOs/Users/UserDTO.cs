namespace PizzaPlace.BlazorServer.Models.DTOs.Users
{
    public class UserDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public IEnumerable<string> Addresses { get; set; } = new List<string>();
        public string Role { get; set; } = string.Empty;
    }
}
