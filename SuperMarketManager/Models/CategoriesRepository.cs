namespace SuperMarketManager.Models;

public static class CategoriesRepository
{
    private static List<Category> _categories = new List<Category>
    {
        new Category { Id = 1, Name = "Beverages", Description = "Drinks and refreshments" },
        new Category { Id = 2, Name = "Snacks", Description = "Chips, cookies, and other snacks" },
        new Category { Id = 3, Name = "Dairy", Description = "Milk, cheese, and other dairy products" }
    };
    public static IEnumerable<Category> GetCategories() => _categories;
    public static Category? GetCategoryById(int id) => _categories.FirstOrDefault(c => c.Id == id);
    public static void AddCategory(Category category) => _categories.Add(category);
    public static void UpdateCategory(Category category)
    {
        var existingCategory = GetCategoryById(category.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
        }
    }
    public static void DeleteCategory(int id) => _categories.RemoveAll(c => c.Id == id);
}
