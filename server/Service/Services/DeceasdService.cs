using AutoMapper;
using Common.Entity;
using Microsoft.AspNetCore.Mvc;
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
    public class DeceasdService : IService<DeceasdDetailesDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<DeceasdDetails> repository;

        public DeceasdService(IRepository<DeceasdDetails> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<DeceasdDetailesDto> AddAsync(DeceasdDetailesDto entity)
         {
            return mapper.Map<DeceasdDetailesDto>(await repository.addItemAsync(mapper.Map<DeceasdDetails>(entity)));
        }


        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<DeceasdDetailesDto>> getAllAsync()
        {
            return mapper.Map<List<DeceasdDetailesDto>>(await repository.getAllAsync());
        }

        public async Task<DeceasdDetailesDto> getAsync(int id)
        {
            return mapper.Map<DeceasdDetailesDto>(await repository.getAsync(id));
        }

        public async Task Post(DeceasdDetailesDto deceasd)
        {
            await this.repository.Post(mapper.Map<DeceasdDetails>(deceasd));
        }

        public async Task updateAsync(int id, DeceasdDetailesDto entity)
        {
            await repository.updateAsync(id,mapper.Map<DeceasdDetails>(entity));
        }
    }
}
