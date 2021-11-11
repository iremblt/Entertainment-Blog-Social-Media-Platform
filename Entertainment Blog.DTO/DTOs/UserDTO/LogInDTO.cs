
namespace Entertainment_Blog.DTO.DTOs.UserDTO
{
    public class LogInDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPasword { get; set; }
        public bool RememberMe { get; set; }
    }
}
