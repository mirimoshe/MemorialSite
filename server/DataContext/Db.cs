using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;
using System.Diagnostics.Metrics;

namespace DataContext
{
    public class Db : DbContext, IContext
    {
        public DbSet<DeceasdDetails> DeceasdsDetails { get; set; }
        public DbSet<ResponseDetails> Responses { get; set; }
        public DbSet<StoryDetailes> Stories { get; set; }
        public DbSet<UserDetailes> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeceasdDetails>()
                .Property(e => e.Images)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            base.OnModelCreating(modelBuilder);
        }

       

        public async Task save()
        {
            await SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseNpgsql("Host=autorack.proxy.rlwy.net;Port=14697;Database=railway;Username=postgres;Password=VLLGyUoXWdsgJeEBwehhkBvQffbeGIQS;");
        }
    }
}
