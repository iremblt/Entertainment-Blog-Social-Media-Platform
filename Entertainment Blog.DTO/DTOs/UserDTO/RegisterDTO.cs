using Entertainment_Blog.Entity.Enums;
using System;

namespace Entertainment_Blog.DTO.DTOs.UserDTO
{
    public class RegisterDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmPassword { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderTypes Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
    }
}
