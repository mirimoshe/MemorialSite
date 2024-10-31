using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ResponseRepository : IRepository<ResponseDetails>
    {
        private readonly IContext _context;
        public ResponseRepository(IContext context) {
            this._context = context; 
        }
        public async Task<ResponseDetails> addItemAsync(ResponseDetails item)
        {
            await this._context.Responses.AddAsync(item);
            await this._context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            this._context.Responses.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<ResponseDetails>> getAllAsync()
        {
            return await this._context.Responses.ToListAsync();
        }

        public async Task<ResponseDetails> getAsync(int id)
        {
            return await _context.Responses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Post(ResponseDetails item)
        {
            await _context.Responses.AddAsync(item);
            await _context.save();
        }

        public async Task updateAsync(int id, ResponseDetails item)
        {
            var response = await getAsync(id);
            response.Nickname = item.Nickname;
            response.Reported_number = item.Reported_number;
            response.Identified_number = item.Identified_number;
            await _context.save();
        }
    }
}
