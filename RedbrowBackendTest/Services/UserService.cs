﻿using AutoMapper;
using RedbrowBackendTest.DTOs;
using RedbrowBackendTest.Entities;
using RedbrowBackendTest.Models;
using RedbrowBackendTest.Repository.Interfaces;
using RedbrowBackendTest.Services.Interfaces;

namespace RedbrowBackendTest.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Usuario> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<Usuario> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PagedUsersDTO> GetAll(int pageNumber, int pageSize)
        {
            PagedResult<Usuario> pagedResult = await _userRepository.GetAllAsync(pageNumber, pageSize);

            return new PagedUsersDTO()
            {
                Items = _mapper.Map<List<UsuarioDTO>>(pagedResult.Items),
                TotalCount = pagedResult.TotalCount,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
        }
    }
}
