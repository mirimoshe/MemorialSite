using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IContext
    {
        public DbSet<DeceasdDetails> DeceasdsDetails { get; set; }
        public DbSet<ResponseDetails> Responses { get; set; }
        public DbSet<StoryDetailes> Stories { get; set; }
        public DbSet<UserDetailes> Users { get; set; }

        public Task save();

    }
}
