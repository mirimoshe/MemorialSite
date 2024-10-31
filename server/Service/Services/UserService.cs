using AutoMapper;
using Common.Entity;
using Repository.Entity;
using Repository.Interface;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : ILoginService
    {
        private readonly IMapper mapper;
        private readonly ILogin repository;

        public UserService(IMapper mapper, ILogin repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<UserDetailesDto> AddAsync(UserDetailesDto entity)
        {
            return mapper.Map<UserDetailesDto>(repository.addItemAsync(mapper.Map<UserDetailes>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<UserDetailesDto>> getAllAsync()
        {
            return mapper.Map<List<UserDetailesDto>>(await repository.getAllAsync());
        }

        public async Task<UserDetailesDto> getAsync(int id)
        {
            return mapper.Map<UserDetailesDto>(await repository.getAsync(id));
        }

        public async Task Post(UserDetailesDto user)
        {
            await this.repository.Post(mapper.Map<UserDetailes>(user));
        }


        public async Task updateAsync(int id, UserDetailesDto entity)
        {
            await repository.updateAsync(id,mapper.Map<UserDetailes>(entity));
        }

        public UserDetailesDto Login(string email, string password)
        {
            return mapper.Map<UserDetailesDto>(repository.getUserByLogin(email, password));
        }
    }
}
