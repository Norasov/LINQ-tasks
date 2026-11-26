List<Employee> employees = new List<Employee>
{
    new Employee { Id = 1,  Name = "Alex",     Department = "Engineering", Salary = 5000 },
    new Employee { Id = 2,  Name = "Bob",      Department = "Engineering", Salary = 4500 },
    new Employee { Id = 3,  Name = "Irina",    Department = "Engineering", Salary = 6000 },
    new Employee { Id = 4,  Name = "Anna",     Department = "HR",          Salary = 3000 },
    new Employee { Id = 5,  Name = "Umar",     Department = "HR",          Salary = 3200 },
    new Employee { Id = 6,  Name = "Olga",     Department = "Marketing",   Salary = 3800 },
    new Employee { Id = 7,  Name = "Aziz",     Department = "Marketing",   Salary = 4200 },
    new Employee { Id = 8,  Name = "Madina",   Department = "Finance",     Salary = 5500 },
    new Employee { Id = 9,  Name = "Emil",     Department = "Finance",     Salary = 5800 },
    new Employee { Id = 10, Name = "Bakhtior", Department = "Engineering", Salary = 5200 },
};

List<Customer> customers = new List<Customer>
{
    new Customer { CustomerId = 1, Name = "Alex" },
    new Customer { CustomerId = 2, Name = "Bob" },
    new Customer { CustomerId = 3, Name = "Irina" },
    new Customer { CustomerId = 4, Name = "Anna" },
    new Customer { CustomerId = 5, Name = "Umar" },
    new Customer { CustomerId = 6, Name = "Olga" },
    new Customer { CustomerId = 7, Name = "Aziz" },
};


// Task 1
var engineeringEmployees = employees
    .Where(e => e.Department == "Engineering").ToList();

var averageSalaryByDepartment = employees
    .GroupBy(d => d.Department)
    .Select(a => new {Department = a.Key, AverageSalary = a.Average(e => e.Salary)});

var departmentWithMostAverage = averageSalaryByDepartment
    .MaxBy(s => s.AverageSalary);


// Task 2?
// Task 3
List<Order> orders = new List<Order>
{
    new Order { OrderId = 1,  CustomerId = 1, OrderDate = new DateTime(2026, 1, 10), TotalAmount = 250 },
    new Order { OrderId = 2,  CustomerId = 2, OrderDate = new DateTime(2026, 1, 15), TotalAmount = 400 },
    new Order { OrderId = 3,  CustomerId = 1, OrderDate = new DateTime(2026, 2, 3),  TotalAmount = 150 },
    new Order { OrderId = 4,  CustomerId = 3, OrderDate = new DateTime(2026, 2, 10), TotalAmount = 900 },
    new Order { OrderId = 5,  CustomerId = 4, OrderDate = new DateTime(2026, 2, 18), TotalAmount = 120 },
    new Order { OrderId = 6,  CustomerId = 2, OrderDate = new DateTime(2026, 3, 1),  TotalAmount = 300 },
    new Order { OrderId = 7,  CustomerId = 5, OrderDate = new DateTime(2026, 3, 5),  TotalAmount = 700 },
    new Order { OrderId = 8,  CustomerId = 3, OrderDate = new DateTime(2026, 3, 12), TotalAmount = 100 },
    new Order { OrderId = 9,  CustomerId = 6, OrderDate = new DateTime(2026, 3, 20), TotalAmount = 80 },
    new Order { OrderId = 10, CustomerId = 7, OrderDate = new DateTime(2026, 4, 2),  TotalAmount = 500 },
    new Order { OrderId = 11, CustomerId = 5, OrderDate = new DateTime(2026, 4, 10), TotalAmount = 200 },
    new Order { OrderId = 12, CustomerId = 4, OrderDate = new DateTime(2026, 4, 15), TotalAmount = 60 },
    new Order { OrderId = 13, CustomerId = 1, OrderDate = new DateTime(2026, 5, 1),  TotalAmount = 350 },
};


var topFive = orders
    .OrderByDescending(t => t.TotalAmount).Take(5)
    .Select(c => new{c.CustomerId, c.TotalAmount});



// HomeTask 4
// 1. Топ-3 клиента по сумме заказов
// GroupBy, Sum, OrderByDescending, ThenBy, Take
var top3Customers = orders
    .GroupBy(o => o.CustomerId)
    .Select(g => new { CustomerId = g.Key, Total = g.Sum(o => o.TotalAmount) })
    .OrderByDescending(x => x.Total)
    .ThenBy(x => x.CustomerId)
    .Take(3);
// 3: 1000, 5: 900, 1: 750


// 2. Заказы с именами клиентов, от дорогих к дешёвым (query syntax)
// join, orderby
var ordersWithNames = from o in orders
                      join c in customers on o.CustomerId equals c.CustomerId
                      orderby o.TotalAmount descending
                      select new { c.Name, o.OrderId, o.TotalAmount };
// Irina 900, Umar 700, Aziz 500, ...


// 3. Клиенты с количеством и суммой их заказов (query syntax)
// join ... into (GroupJoin), let, orderby
var customerStats = from c in customers
                    join o in orders on c.CustomerId equals o.CustomerId into customerOrders
                    let total = customerOrders.Sum(o => o.TotalAmount)
                    orderby total descending
                    select new { c.Name, OrdersCount = customerOrders.Count(), Total = total };
// Irina 2 / 1000, Umar 2 / 900, Alex 3 / 750, ...


// 4. Самый дорогой заказ и имя клиента
// MaxBy, First
var biggestOrder = orders.MaxBy(o => o.TotalAmount)!;
var biggestOrderCustomer = customers.First(c => c.CustomerId == biggestOrder.CustomerId);
// заказ 4, 900, Irina


// 5. Проверки условий
// Any, All
bool hasOrderOver800 = orders.Any(o => o.TotalAmount > 800);                                  // true
bool everyCustomerHasOrder = customers.All(c => orders.Any(o => o.CustomerId == c.CustomerId)); // true


// 6. Номера месяцев, в которых были заказы
// Distinct, OrderBy
var activeMonths = orders
    .Select(o => o.OrderDate.Month)
    .Distinct()
    .OrderBy(m => m);
// 1, 2, 3, 4, 5


// 7. Клиенты, у которых нет ни одного заказа дороже 300 (query syntax)
// Except, OrderBy
var bigOrderCustomerIds = from o in orders
                          where o.TotalAmount > 300
                          select o.CustomerId;

var smallOrderCustomers = customers
    .Select(c => c.CustomerId)
    .Except(bigOrderCustomerIds)
    .OrderBy(id => id);
// 4, 6


// 8. Заказы, сгруппированные по клиенту, и сумма для клиента 1
// ToLookup, Sum
var ordersByCustomer = orders.ToLookup(o => o.CustomerId);
decimal customer1Total = ordersByCustomer[1].Sum(o => o.TotalAmount);
// 750


// 9. Вторая страница (по 5 записей) заказов от дорогих к дешёвым
// OrderByDescending, Skip, Take
var secondPage = orders
    .OrderByDescending(o => o.TotalAmount)
    .Skip(5)
    .Take(5);
// 300, 250, 200, 150, 120


// 10. Статистика по месяцам
// GroupBy, Sum, Average, OrderBy
var monthlyStats = orders
    .GroupBy(o => o.OrderDate.Month)
    .OrderBy(g => g.Key)
    .Select(g => new { Month = g.Key, Total = g.Sum(o => o.TotalAmount), Average = g.Average(o => o.TotalAmount) });
// 1: 650 / 325, 2: 1170 / 390, 3: 1180 / 295, 4: 760 / 253.33, 5: 350 / 350


// 11. Сумма заказов по пачкам из 5 штук
// OrderBy, Chunk, Sum
var sumsPerChunk = orders
    .OrderBy(o => o.OrderId)
    .Chunk(5)
    .Select(chunk => chunk.Sum(o => o.TotalAmount));
// 1820, 1680, 610