using bulkyweb_razor_pages.Data;
using bulkyweb_razor_pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bulkyweb_razor_pages.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly BulkyRazorDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(BulkyRazorDbContext db)
        {
            _db = db;
        }

        // Load category for confirmation
        public IActionResult OnGet(int id)
        {
            Category = _db.Categories.Find(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Handle deletion
        public IActionResult OnPost()
        {
            var categoryFromDb = _db.Categories.Find(Category.Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();

            TempData["success"] = "Category deleted successfully!";
            return RedirectToPage("/Categories/Index");
        }
    }
}
