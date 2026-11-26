public interface IProductService
{
    // CRUD
    Product Add(Product product);
    Product? GetById(int id);
    IReadOnlyList<Product> GetAll();
    bool Update(Product product);
    bool Delete(int id);

    // Дополнительные методы
    IReadOnlyList<Product> Search(string? text = null, string? category = null,
                                  decimal? minPrice = null, decimal? maxPrice = null,
                                  int page = 1, int pageSize = 10);
    IReadOnlyList<CategoryStatistics> GetCategoryStatistics();
}
