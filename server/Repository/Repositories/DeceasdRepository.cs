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
    public class DeceasdRepository : IRepository<DeceasdDetails>
    {
        private readonly IContext _context;

        public DeceasdRepository(IContext context) { 
            this._context = context; 
        }
        public async Task<DeceasdDetails> addItemAsync(DeceasdDetails item)
        {
            await this._context.DeceasdsDetails.AddAsync(item);
            await this._context.save();
            return item;
        }

        public async Task deleteAsync(int id)
        {
            this._context.DeceasdsDetails.Remove(await getAsync(id));
           await _context.save();
        }

        public async Task<List<DeceasdDetails>> getAllAsync()
        {
            return await this._context.DeceasdsDetails.ToListAsync();
        }

        public async Task<DeceasdDetails> getAsync(int id)
        {
            return await this._context.DeceasdsDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Post(DeceasdDetails item)
         {
             await _context.DeceasdsDetails.AddAsync(item);
             await _context.save();
         }

        public async Task updateAsync(int id, DeceasdDetails item )
        {
            DeceasdDetails deceasd = await getAsync(id);
            deceasd.First_name=item.First_name;
            deceasd.Last_name=item.Last_name;
            deceasd.Birth_date=item.Birth_date;
            deceasd.Death_date=item.Death_date;
            deceasd.Rank=item.Rank;
            deceasd.Age=item.Age;
            deceasd.Burial_location=item.Burial_location;
            deceasd.Death_detailes=item.Death_detailes;
            deceasd.Hometown=item.Hometown;
            deceasd.Images=item.Images;
            deceasd.ImagesUrl=item.ImagesUrl;
            deceasd.Unit=item.Unit;
            await this._context.save();
        }
    }
}
