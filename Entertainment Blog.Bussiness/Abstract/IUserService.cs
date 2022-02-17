using Entertainment_Blog.DTO.DTOs.UserDTO;
using Entertainment_Blog.Entity.Concrete;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface IUserService
    {
        public Task SignIn(SignInDTO signIn);
        public Task Register(RegisterDTO register);
        //public UserDetailsDTO ProfileDetails(ApplicationUser user);
        public Task EditUserAsync(EditUserDTO user);
        public Task<UserDetailsDTO> UserProfileAsync(ApplicationUser user);
        public Task<EditUserDTO> FindUserByIdAsync(string id);

    }
}
