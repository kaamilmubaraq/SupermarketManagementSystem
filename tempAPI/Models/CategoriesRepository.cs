namespace tempAPI.Models
{
    public class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId = 1, Name ="Beverages", Description = "Beverage" },
            new Category { CategoryId = 2, Name ="Bakery", Description = "Bakery" },
            new Category { CategoryId = 3, Name ="Meat", Description = "Meat" }
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(c => c.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }
        public static List<Category> GetAllCategories() => _categories;

        public static Category? GetCategoryById(int categoryID)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryID);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };

            }
            return null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpdate = GetCategoryById(categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
