public static class Validater
{

    public static void Validate(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Название товара не может быть пустым");
        if (string.IsNullOrWhiteSpace(product.Category))
            throw new ArgumentException("Категория не может быть пустой");
        if (product.Price < 0)
            throw new ArgumentException("Цена не может быть отрицательной");
        if (product.Quantity < 0)
            throw new ArgumentException("Количество не может быть отрицательным");
    }
}
