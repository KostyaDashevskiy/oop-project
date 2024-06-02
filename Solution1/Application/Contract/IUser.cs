﻿using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);

        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserDTO deleteUserDTO);
    }
}
