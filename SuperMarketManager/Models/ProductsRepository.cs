namespace SuperMarketManager.Models;

public static class ProductsRepository
{
    private static List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
            new Product { Id = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
            new Product { Id = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
            new Product { Id = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
        };

    public static void AddProduct(Product product)
    {
        var maxId = _products.Count > 0 ? _products.Max(x => x.Id) : 0;
        product.Id = maxId + 1;
        _products.Add(product);
    }

    public static List<Product> GetProducts(bool loadCategory = false)
    {
        if (loadCategory)
        {
            _products.ForEach(product =>
            {
                product.Category = CategoriesRepository.GetCategoryById(product.CategoryId ?? 0);
            });
        }

        return _products ?? new List<Product>();
    }

    public static Product? GetProductById(int productId)
    {
        var product = _products.FirstOrDefault(x => x.Id == productId);
        if (product != null)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }

        return null;
    }

    public static void UpdateProduct(int productId, Product product)
    {
        if (productId != product.Id) return;

        var productToUpdate = _products.FirstOrDefault(x => x.Id == productId);
        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }

    public static void DeleteProduct(int productId)
    {
        var product = _products.FirstOrDefault(x => x.Id == productId);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}
