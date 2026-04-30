using library.Models;
using Microsoft.EntityFrameworkCore;


namespace library.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();//
        }

        public DbSet<ElectronicAudioBook> ElectronicAudioBook { get; set; }
        public DbSet<Readers> Readers { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
