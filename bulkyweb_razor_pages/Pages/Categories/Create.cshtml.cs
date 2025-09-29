using bulkyweb_razor_pages.Data;
using bulkyweb_razor_pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bulkyweb_razor_pages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly BulkyRazorDbContext _db;

        // BindProperty allows the form to bind automatically to this property
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(BulkyRazorDbContext db)
        {
            _db = db;
        }

        // Display the Create page
        public void OnGet()
        {
        }

        // Handle POST request when form is submitted
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, stay on the page and show errors
                return Page();
            }

            // Add category to the database
            _db.Categories.Add(Category);
            _db.SaveChanges();

            // TempData can be used to show a success message on redirect
            TempData["success"] = "Category created successfully!";

            // Redirect to Index page after creation
            return RedirectToPage("/Categories/Index");
        }
    }
}
