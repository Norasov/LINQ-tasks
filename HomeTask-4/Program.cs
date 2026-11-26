IProductService service = new ProductService();

var laptop = service.Add(new Product { Name = "Laptop", Category = "Electronics", Price = 1200, Quantity = 5 });
var phone  = service.Add(new Product { Name = "Phone",  Category = "Electronics", Price = 800,  Quantity = 10 });
var desk   = service.Add(new Product { Name = "Desk",   Category = "Furniture",   Price = 300,  Quantity = 4 });
var chair  = service.Add(new Product { Name = "Chair",  Category = "Furniture",   Price = 150,  Quantity = 12 });
var pen    = service.Add(new Product { Name = "Pen",    Category = "Stationery",  Price = 2,    Quantity = 200 });
var book   = service.Add(new Product { Name = "Book",   Category = "Stationery",  Price = 25,   Quantity = 40 });

Console.WriteLine("--- Все товары ---");
foreach (var p in service.GetAll())
    Console.WriteLine(p);

var found = service.GetById(2);
Console.WriteLine($"\nПо Id = 2: {found}");

bool updated = service.Update(new Product { Id = 2, Name = "Phone Pro", Category = "Electronics", Price = 950, Quantity = 8 });
Console.WriteLine($"\nОбновлён: {updated}, теперь: {service.GetById(2)}");

bool deleted = service.Delete(5);
Console.WriteLine($"Удалён Id = 5: {deleted}");
Console.WriteLine($"Повторное удаление Id = 5: {service.Delete(5)}");

Console.WriteLine("\n--- Поиск: Electronics и Furniture, цена от 100, страница 1 по 2 ---");
foreach (var p in service.Search(minPrice: 100, page: 1, pageSize: 2))
    Console.WriteLine(p);

Console.WriteLine("\n--- Статистика по категориям ---");
foreach (var s in service.GetCategoryStatistics())
    Console.WriteLine($"{s.Category}: товаров {s.Count}, стоимость склада {s.TotalValue}, средняя цена {s.AveragePrice:F2}");
