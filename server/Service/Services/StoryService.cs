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
    public class StoryService : IService<StoryDetailesDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<StoryDetailes> repository;

        public StoryService(IRepository<StoryDetailes> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<StoryDetailesDto> AddAsync(StoryDetailesDto entity)
        {
            return mapper.Map<StoryDetailesDto>(await repository.addItemAsync(mapper.Map<StoryDetailes>(entity)));
        }

        public async Task deleteAsync(int id)
        {
            await repository.deleteAsync(id);
        }

        public async Task<List<StoryDetailesDto>> getAllAsync()
        {
           return mapper.Map<List<StoryDetailesDto>>(await repository.getAllAsync());
        }

        public async Task<StoryDetailesDto> getAsync(int id)
        {
            return mapper.Map<StoryDetailesDto>(await repository.getAsync(id));
        }

        public async Task Post(StoryDetailesDto story)
        {
            await this.repository.Post(mapper.Map<StoryDetailes>(story));
        }


        public async Task updateAsync(int id, StoryDetailesDto entity)
        {
            await repository.updateAsync(id,mapper.Map<StoryDetailes>(entity));
        }
    }
}
