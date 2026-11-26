public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public Product Add(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        Validater.Validate(product);

        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public Product? GetById(int id) =>
        _products.FirstOrDefault(p => p.Id == id);

    public IReadOnlyList<Product> GetAll() =>
        _products.OrderBy(p => p.Id).ToList();

    public bool Update(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        Validater.Validate(product);

        var existing = GetById(product.Id);
        if (existing is null)
            return false;

        existing.Name = product.Name;
        existing.Category = product.Category;
        existing.Price = product.Price;
        existing.Quantity = product.Quantity;
        return true;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing is null)
            return false;

        return _products.Remove(existing);
    }

    public IReadOnlyList<Product> Search(string? text = null, string? category = null,
                                         decimal? minPrice = null, decimal? maxPrice = null,
                                         int page = 1, int pageSize = 10)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(page, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);

        if (minPrice > maxPrice)
            throw new ArgumentException("minPrice не может быть больше maxPrice");

        return _products
            .Where(p => string.IsNullOrWhiteSpace(text) ||
                        p.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
            .Where(p => string.IsNullOrWhiteSpace(category) ||
                        p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .Where(p => minPrice is null || p.Price >= minPrice)
            .Where(p => maxPrice is null || p.Price <= maxPrice)
            .OrderBy(p => p.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public IReadOnlyList<CategoryStatistics> GetCategoryStatistics() =>
        _products
            .GroupBy(p => p.Category)
            .Select(g => new CategoryStatistics(
                g.Key,
                g.Count(),
                g.Sum(p => p.Price * p.Quantity),
                g.Average(p => p.Price)))
            .OrderByDescending(s => s.TotalValue)
            .ToList();

}