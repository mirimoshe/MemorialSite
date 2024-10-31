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
    public class UserRepository : ILogin
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }
        public async Task<UserDetailes> addItemAsync(UserDetailes item)
        {
            await _context.Users.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            _context.Users.Remove(await getAsync(id));
            await _context.save();
        }

        public async Task<List<UserDetailes>> getAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserDetailes> getAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Post(UserDetailes item)
        {
            await _context.Users.AddAsync(item);
            await _context.save();
        }

        public async Task updateAsync(int id, UserDetailes item)
        {
            var user = await getAsync(id);
            if (user != null)
            {
                user.Amount_stories = user.Amount_stories+1;
                await _context.save();
            }
            
        }

        public UserDetailes getUserByLogin(string email, string password)
        {
            UserDetailes u = this._context.Users.FirstOrDefault(x => x.Email == email && x.Id_person == password);
            if (u != null)
                return u;
            return null;
        }
    }
}
