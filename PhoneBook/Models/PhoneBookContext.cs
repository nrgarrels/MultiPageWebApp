using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Models
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options){ }
        public DbSet<PhoneBookModel> PhoneBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=PhoneBook",
                    providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBookModel>().HasData(
            new PhoneBookModel {
                PhoneBookId = 1,
                Name = "John Smith",
                PhoneNumber = "555-555-5555",
                Address = "123 Something Lane",
                Note = "Some Random Dude"
            }, 
            new PhoneBookModel
            {
                PhoneBookId = 2,
                Name = "Ryan Renolds",
                PhoneNumber = "444-444-4444",
                Address = "243 This Road",
                Note = "An Actor"
            }, 
            new PhoneBookModel
            {
                PhoneBookId = 3,
                Name = "Larry Something",
                PhoneNumber = "666-666-6666",
                Address = "465 2nd Street",
                Note = "IDK who this is"
            }
            ) ;
        }
    }
}
