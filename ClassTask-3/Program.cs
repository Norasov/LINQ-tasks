
// Task 4:Напишите метод фильтрации простых чисел из массива с помощью PLINQ.
// bool IsPrime(int number)
// {
//     if (number < 2) return false;
//     if (number % 2 == 0) return number == 2;

//     for (int i = 3; (long)i * i <= number; i += 2)
//     {
//         if (number % i == 0) return false;
//     }
//     return true;
// }

// List<int> numbers = new() { 1, 2, 3, 4, 3, 2, 5, 3, 3, 5, 5, 5 };
// var primeNumbers = numbers    
//     .AsParallel()
//     .AsOrdered()
//     .Where(IsPrime)
//     .ToList();

// var primeNumbers = (from n in numbers
//                    .AsParallel()
//                    .AsOrdered()
//                     where IsPrime(n)
//                     select n).ToList();



// Task 5:Напишите метод группировки автомобилей по годам и подсчитайте количество автомобилей в каждой годовой группе с помощью PLINQ.
// List<Car> cars = new List<Car>
// {
//     new Car { Id = 1, Brand = "Toyota", Year = 2020 },
//     new Car { Id = 2, Brand = "Honda",  Year = 2018 },
//     new Car { Id = 3, Brand = "BMW",    Year = 2020 },
//     new Car { Id = 4, Brand = "Audi",   Year = 2019 },
//     new Car { Id = 5, Brand = "Ford",   Year = 2018 },
//     new Car { Id = 7, Brand = "Kia",    Year = 2020 },
// };

// var carsCountByYear = GetCarsCountByYear(cars);
// List<(int Year, int Count)> GetCarsCountByYear(IEnumerable<Car> source)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);
        // return source   
        //     .AsParallel()
        //     .GroupBy(c => c.Year)
        //     .Select(c =>  (Year: c.Key, Count: cars.Count()))
        //     .OrderBy(c => c.Year)
        //     .ToList();

        // return (from c in source.AsParallel()
        // group c by c.Year into g
        // orderby g.Key
        // select (Year: g.Key, Count: g.Count())).ToList();

//     }
//     catch (AggregateException ex)
//     {
//         foreach (var inner in ex.Flatten().InnerExceptions)
//         {
//             System.Console.WriteLine($"Oshibka v potoke: {inner.Message}");
//         }
//             return new List<(int Year, int Count)>();   
//     }
//     catch(ArgumentNullException ex)
//     {
//         System.Console.WriteLine($"spisok ne peredan: {ex.Message}");
//         return new List<(int Year, int Count)>();
//     }
// }
