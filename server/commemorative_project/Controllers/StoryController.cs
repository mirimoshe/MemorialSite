using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace commemorative_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController: ControllerBase
    {
        private readonly IService<StoryDetailesDto> service;

        public StoryController(IService<StoryDetailesDto> service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<List<StoryDetailesDto>> Get()
        {
            return await service.getAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<StoryDetailesDto> Get(int id)
        {
            return await service.getAsync(id);
        }


        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] StoryDetailesDto story)
        {
            story.Story = story.Story.Replace("\r\n", "\n\\n");
            return Ok(await service.AddAsync(story));
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] StoryDetailesDto s)
        {
            await service.updateAsync(id, s);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }
    }
}
