using MentorMate.Zoo.Data.EntityConfiguration;
using MentorMate.Zoo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Zoo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
