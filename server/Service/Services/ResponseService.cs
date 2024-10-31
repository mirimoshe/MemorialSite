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
    public class ResponseService : IService<ResponseDetailsDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<ResponseDetails> repository;

        public ResponseService(IRepository<ResponseDetails> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ResponseDetailsDto> AddAsync(ResponseDetailsDto entity)
        {
            return mapper.Map<ResponseDetailsDto>(await repository.addItemAsync(mapper.Map<ResponseDetails>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<ResponseDetailsDto>> getAllAsync()
        {
            return mapper.Map<List<ResponseDetailsDto>>(await repository.getAllAsync());
        }

        public async Task<ResponseDetailsDto> getAsync(int id)
        {
            return mapper.Map<ResponseDetailsDto>(await repository.getAsync(id));   
        }

        public async Task Post(ResponseDetailsDto response)
        {
            await this.repository.Post(mapper.Map<ResponseDetails>(response));
        }

 

        public async Task updateAsync(int id, ResponseDetailsDto entity)
        {
            await repository.updateAsync(id,mapper.Map<ResponseDetails>(entity));    
        }
    }
}
