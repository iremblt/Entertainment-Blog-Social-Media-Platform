﻿using Entertainment_Blog.DTO.DTOs.UserDTO;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface IUserService
    {
        public Task SignIn(SignInDTO signIn);
        public Task Register(RegisterDTO register);
    }
}