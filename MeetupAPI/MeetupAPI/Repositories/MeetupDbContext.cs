using MeetupAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Repositories
{
    public class MeetupDbContext : DbContext
    {
        public DbSet<Meetup>? Meetups { get; set; }


        public MeetupDbContext(DbContextOptions<MeetupDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: typeof(Meetup).Assembly);
        }
    }
}
