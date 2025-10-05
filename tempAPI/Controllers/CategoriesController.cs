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

        [HttpGet]      //it is http get by default even if dont mention anything
        public IActionResult Edit([FromRoute] int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //since we put required attribute on name property in category model
            //the model state will be invalid if name is not provided
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Category category)  //it is not necessary to mention fromform but i made it explicit
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int categoryId)
        {

        }
    }
}
