using bulkyweb_razor_pages.Models;
using Microsoft.EntityFrameworkCore;
namespace bulkyweb_razor_pages.Data

{
    public class BulkyRazorDbContext  : DbContext
    {


  

        public BulkyRazorDbContext(DbContextOptions<BulkyRazorDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food", DisplayOrder = 67 },
                new Category { Id = 2, Name = "Clothes", DisplayOrder = 68 },
                new Category { Id = 3, Name = "Electronics", DisplayOrder = 69 }
            );
        }


    }






}
