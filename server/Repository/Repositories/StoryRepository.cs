using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StoryRepository : IRepository<StoryDetailes>
    {
        private readonly IContext _context;

        public StoryRepository(IContext context) {
            _context = context; 
        }
        public async Task<StoryDetailes> addItemAsync(StoryDetailes item)
        {
            await _context.Stories.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            _context.Stories.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<StoryDetailes>> getAllAsync()
        {
            return await _context.Stories.ToListAsync();
        }

        public async Task<StoryDetailes> getAsync(int id)
        {
            return await _context.Stories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Post(StoryDetailes item)
        {
            await _context.Stories.AddAsync(item);
            await _context.save();
        }

        public async Task updateAsync(int id, StoryDetailes item)
        {
            var story = await getAsync(id);
            if(story != null)
            {
                story.Nickname = item.Nickname;
                story.Relation_type = item.Relation_type;
                story.Story = item.Story;
                story.Email_for_messages = item.Email_for_messages;
                story.Likes_number = item.Likes_number;
                story.Reported_number = item.Reported_number;
                story.Favorite_number = item.Favorite_number;
                story.Empowering_number = item.Empowering_number;
                story.Exciting_number = item.Exciting_number;
                story.Heroism_number = item.Heroism_number;
                story.Thanksgiving_number = item.Thanksgiving_number;
                await _context.save();
            }
            
        }
    }
}
