
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Models
{

    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }


      public DbSet<Book> Books { get; set; }  
      public DbSet<Borrower> borrowers { get; set; }
      public DbSet<BorrowBooks> borrowBooks { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=BookLibrary;integrated security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}


    }




}