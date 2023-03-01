using FrontToBack2.DAL;
using FrontToBack2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack2.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Categories.ToList());
        }
        public IActionResult Detail(int id)
        {
           
            {
                if (id == null) return NotFound();
                Category category= _appDbContext.Categories.SingleOrDefault(c => c.Id==id);
                if (category ==null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }




        public IActionResult Delete(int id)
        {
            if(id==null) return NotFound();

            Category category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Create(Category category)
        {
            return Content($"{category.Name} {category.Description}");
        }





    }
}

