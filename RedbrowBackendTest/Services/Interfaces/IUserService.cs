﻿using RedbrowBackendTest.DTOs;

namespace RedbrowBackendTest.Services.Interfaces
{
    public interface IUserService
    {
        Task<UsuarioDTO> GetAll();
    }
}
