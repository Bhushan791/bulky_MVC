using bulkyweb_razor_pages.Data;
using bulkyweb_razor_pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bulkyweb_razor_pages.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly BulkyRazorDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(BulkyRazorDbContext db)
        {
            _db = db;
        }

        // Load the existing category by ID
        public IActionResult OnGet(int id)
        {
            Category = _db.Categories.Find(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Handle the form submission
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var categoryFromDb = _db.Categories.Find(Category.Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            // Update properties
            categoryFromDb.Name = Category.Name;
            categoryFromDb.DisplayOrder = Category.DisplayOrder;

            _db.SaveChanges();

            TempData["success"] = "Category updated successfully!";
            return RedirectToPage("/Categories/Index");
        }
    }
}
