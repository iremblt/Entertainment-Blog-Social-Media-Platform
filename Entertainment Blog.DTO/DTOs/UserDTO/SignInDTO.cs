
namespace Entertainment_Blog.DTO.DTOs.UserDTO
{
    public class SignInDTO
    {
        public string EmailOrUserName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
    }
}
