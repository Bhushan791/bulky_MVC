using bulkyweb_razor_pages.Data;
using bulkyweb_razor_pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bulkyweb_razor_pages.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly BulkyRazorDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(BulkyRazorDbContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {

            CategoryList = _db.Categories.ToList(); 
        }

    }
}
