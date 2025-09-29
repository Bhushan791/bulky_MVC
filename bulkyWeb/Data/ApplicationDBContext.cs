using Microsoft.EntityFrameworkCore;
using bulkyWeb.Models;
namespace bulkyWeb.Data
{
    public class ApplicationDBContext  :DbContext  //root class of the EF core
         
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base (options)
        {    
        }

       public  DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "History", DisplayOrder =2 });
        }


    }
}
