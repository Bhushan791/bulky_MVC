using bulkyWeb.Data;
using bulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace bulkyWeb.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db; 
           
        }
        public IActionResult Index()
        {
           List <Category>objCategoryList = _db.Categories.ToList(); 
            return View(objCategoryList); 
        }

      
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {


            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Cannot exactly match name");
            }
            if (ModelState.IsValid)
            {

            _db.Categories.Add(obj);
            _db.SaveChanges();
                TempData["success"] = "Category added successfully!!";
                return RedirectToAction("Index");
            }
            return View();

        }


        ////edit---started
        ///




        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound(); 
            }
            Category categoryFromDb = _db.Categories.Find(id); 
            if(categoryFromDb ==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == obj.Id);

                if (categoryFromDb == null)
                {
                    return NotFound();
                }

                // Update only the needed properties
                categoryFromDb.Name = obj.Name;
                categoryFromDb.DisplayOrder = obj.DisplayOrder;

                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully!!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(int?  id )
        {
            if(id ==null || id==0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id); 


            if (categoryFromDb ==null)
            {
                return NotFound(); 
            }
            return View(categoryFromDb); 
        }



        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category obj = _db.Categories.Find(id); 
            if (obj == null)
            {
                return NotFound(); 

            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!!";

            return RedirectToAction("Index"); 

            
        }

    }
}
