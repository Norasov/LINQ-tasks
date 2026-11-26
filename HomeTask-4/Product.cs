public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public override string ToString() =>
        $"{Id}. {Name} ({Category}) - {Price}, на складе: {Quantity}";
}
