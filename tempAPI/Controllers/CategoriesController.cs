using Microsoft.AspNetCore.Mvc;
using tempAPI.Models;

namespace tempAPI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetAllCategories();
            return View(categories);
        }

        public IActionResult Edit([FromRoute] int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value : 0);
            return View(category);
        }
        
    }
}
