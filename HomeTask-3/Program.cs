// Task 1:RU: Дана коллекция целых чисел. Найдите медиану. При чётном числе элементов верните среднее двух средних значений.
// int[] medianInput = { 3, 1, 4, 1, 5, 9, 2, 6 };

// var median = GetMedian(medianInput);
// Console.WriteLine(median);

// double GetMedian(IEnumerable<int> source)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         var sorted = source.OrderBy(n => n).ToList();
//         int count = sorted.Count;

//         if (count == 0)
//             throw new InvalidOperationException("Коллекция пуста, медиану найти нельзя");

//         if (count % 2 == 1)
//             return sorted.ElementAt(count / 2);

//         return new[] { sorted.ElementAt(count / 2 - 1), sorted.ElementAt(count / 2) }.Average();
//     }
//     catch (InvalidOperationException ex)
//     {
//         Console.WriteLine($"Ошибка: {ex.Message}");
//         return double.NaN;
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Коллекция не передана: {ex.Message}");
//         return double.NaN;
//     }
// }

// Task 2:RU: Найдите элементы, присутствующие во всех трёх коллекциях одновременно.
// List<int> listA = new List<int> { 1, 2, 3, 4 };
// List<int> listB = new List<int> { 2, 3, 5, 6 };
// List<int> listC = new List<int> { 2, 3, 7, 8 };

// var commonElements = GetCommonElements(listA, listB, listC);

// foreach (var item in commonElements)
//     Console.WriteLine(item); // 2, 3

// List<int> GetCommonElements(IEnumerable<int> first, IEnumerable<int> second, IEnumerable<int> third)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(first);
//         ArgumentNullException.ThrowIfNull(second);
//         ArgumentNullException.ThrowIfNull(third);

//         return first
//             .Intersect(second)
//             .Intersect(third)
//             .ToList();
// return (from x in first.Intersect(second)
//         where third.Contains(x)
//         select x).ToList();
// }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Коллекция не передана: {ex.Message}");
//         return new List<int>();
//     }
// }

// Task 3:RU: Найдите наибольшую строго возрастающую непрерывную подпоследовательность и вычислите её сумму.
// int[] runInput = { 1, 2, 3, 1, 2, 5, 6 };

// var longestRunSum = GetLongestIncreasingRunSum(runInput);
// Console.WriteLine(longestRunSum);

// int GetLongestIncreasingRunSum(IEnumerable<int> source)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         var runs = source.Aggregate(new List<List<int>>(), (acc, number) =>
//         {
//             if (acc.Count > 0 && acc[^1][^1] < number)
//                 acc[^1].Add(number);
//             else
//                 acc.Add(new List<int> { number });
//             return acc;
//         });

//         return runs
//             .OrderByDescending(run => run.Count)
//             .First() 
//             .Sum();

//         return (from run in runs
//                 orderby run.Count descending
//                 select run).First().Sum();

//     }
//     catch (InvalidOperationException ex)
//     {
//         Console.WriteLine($"Ошибка: коллекция пуста ({ex.Message})");
//         return 0;
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Коллекция не передана: {ex.Message}");
//         return 0;
//     }
// }

// Task 4:RU: Верните N элементов, встречающихся чаще всего. Сортировка по убыванию частоты.
// string[] letters = { "a", "b", "a", "c", "b", "a" };

// var topFrequent = GetTopFrequent(letters, 2);

// foreach (var (value, count) in topFrequent)
//     Console.WriteLine($"{value} (x{count})"); // a (x3), b (x2)

// List<(string Value, int Count)> GetTopFrequent(IEnumerable<string> source, int topCount)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);
//         ArgumentOutOfRangeException.ThrowIfNegative(topCount);

//         return source
//             .AsParallel()
//             .GroupBy(item => item)
//             .Select(g => (Value: g.Key, Count: g.Count()))
//             .OrderByDescending(x => x.Count)
//             .ThenBy(x => x.Value, StringComparer.Ordinal) // при равной частоте сортируем по значению
//             .Take(topCount)
//             .ToList();
//         return (from item in source.AsParallel()
//                 group item by item into g
//                 let count = g.Count()
//                 orderby count descending, g.Key
//                 select (Value: g.Key, Count: count)).Take(topCount).ToList();
//     }
//     catch (AggregateException ex)
//     {
//         foreach (var inner in ex.Flatten().InnerExceptions)
//             Console.WriteLine($"Ошибка в потоке: {inner.Message}");
//         return new List<(string Value, int Count)>();
//     }
//     catch (InvalidOperationException ex)
//     {
//         Console.WriteLine($"Ошибка: {ex.Message}");
//         return new List<(string Value, int Count)>();
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Коллекция не передана: {ex.Message}");
//         return new List<(string Value, int Count)>();
//     }
//     catch (ArgumentOutOfRangeException ex)
//     {
//         Console.WriteLine($"Неверное значение N: {ex.Message}");
//         return new List<(string Value, int Count)>();
//     }
// }


// Task 5:RU: Книга имеет поля Title и Author. Удалите дубликаты — книги одинаковы, если совпадают оба поля.
// List<Book> books = new List<Book>
// {
//     new Book { Title = "C#",   Author = "Albahari" },
//     new Book { Title = "C#",   Author = "Albahari" },
//     new Book { Title = "LINQ", Author = "Rattz" },
// };

// var uniqueBooks = RemoveDuplicateBooks(books);

// foreach (var book in uniqueBooks)
//     Console.WriteLine($"({book.Title}, {book.Author})"); // (C#, Albahari), (LINQ, Rattz)

// List<Book> RemoveDuplicateBooks(IEnumerable<Book> source)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         return source
//             .GroupBy(b => new { b.Title, b.Author })
//             .Select(g => g.First())
//             .ToList();
//         return (from b in source
//                 group b by new { b.Title, b.Author } into g
//                 select g.First()).ToList();
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Список не передан: {ex.Message}");
//         return new List<Book>();
//     }
// }

// Task 6:RU: Отфильтруйте список, оставив только числа в диапазоне [min, max] включительно.
// int[] rangeInput = { 1, 5, 12, 7, 3, 9 };

// var numbersInRange = GetNumbersInRange(rangeInput, 4, 10);

// foreach (var number in numbersInRange)
//     Console.WriteLine(number);

// List<int> GetNumbersInRange(IEnumerable<int> source, int min, int max)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         if (min > max)
//             throw new ArgumentException("min не может быть больше max");

//         return source
//             .Where(x => x >= min && x <= max)
//             .ToList();
//         return (from x in source
//                 where x >= min && x <= max
//                 select x).ToList();
//     }
//     catch (ArgumentException ex) 
//     {
//         Console.WriteLine($"Неверные аргументы: {ex.Message}");
//         return new List<int>();
//     }
// }

// Task 7:RU: Разделите список студентов (Name, Age) на две группы: строго старше порога и меньше или равно ему.
// List<Student> ageSplitStudents = new List<Student>
// {
//     new Student { Id = 1, Name = "Alice", Age = 22 },
//     new Student { Id = 2, Name = "Bob",   Age = 19 },
//     new Student { Id = 3, Name = "Carol", Age = 20 },
// };

// var studentsByAge = SplitByAge(ageSplitStudents, 20);

// Console.WriteLine("Older: [" + string.Join(", ", studentsByAge.Older.Select(s => s.Name)) + "]");
// Console.WriteLine("<= 20: [" + string.Join(", ", studentsByAge.NotOlder.Select(s => s.Name)) + "]");

// (List<Student> Older, List<Student> NotOlder) SplitByAge(IEnumerable<Student> source, int threshold)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         var lookup = source.ToLookup(s => s.Age > threshold);

//         return (lookup[true].ToList(), lookup[false].ToList());

//          var groups = source.GroupBy(s => s.Age > threshold).ToList();
//          return (groups.FirstOrDefault(g => g.Key)?.ToList() ?? new List<Student>(),
//                  groups.FirstOrDefault(g => !g.Key)?.ToList() ?? new List<Student>());
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Список не передан: {ex.Message}");
//         return (new List<Student>(), new List<Student>());
//     }
// }

// Task 8:RU: Верните только элементы, количество вхождений которых равно ровно N.
// int[] repeatInput = { 1, 2, 2, 3, 3, 3, 4 };

// var numbersAppearingTwice = GetElementsAppearingExactly(repeatInput, 2);

// foreach (var number in numbersAppearingTwice)
//     Console.WriteLine(number); // 2

// List<int> GetElementsAppearingExactly(IEnumerable<int> source, int exactCount)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         return source
//             .GroupBy(x => x)
//             .Where(g => g.Count() == exactCount)
//             .Select(g => g.Key)
//             .ToList();
//         return (from x in source
//                 group x by x into g
//                 where g.Count() == exactCount
//                 select g.Key).ToList();
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Коллекция не передана: {ex.Message}");
//         return new List<int>();
//     }
// }

// Task 9:RU: Найдите строку с максимальной длиной. Использовать не более 3 методов LINQ. Нельзя использовать foreach, for, SelectMany.
// string[] wordList = { "cat", "elephant", "ox", "dog" };

// var longestWord = GetLongestWord(wordList);
// Console.WriteLine(longestWord); // elephant

// string? GetLongestWord(IEnumerable<string> source)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         return source.MaxBy(w => w.Length)
//                ?? throw new InvalidOperationException("Коллекция пуста");
//         return source.OrderByDescending(w => w.Length).First();
//     }
//     catch (InvalidOperationException ex)
//     {
//         Console.WriteLine($"Ошибка: {ex.Message}");
//         return null;
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Коллекция не передана: {ex.Message}");
//         return null;
//     }
// }

// Task 10:RU: Найдите число с наибольшей суммой цифр. Например, 199 → сумма 19, что больше суммы 200 (= 2).
// int[] digitInput = { 199, 200, 155, 1999 };

// var maxDigitSumNumber = GetMaxDigitSumNumber(digitInput);
// Console.WriteLine(maxDigitSumNumber); // 1999

// int? GetMaxDigitSumNumber(IEnumerable<int> source)
// {
//     try
//     {
//         ArgumentNullException.ThrowIfNull(source);

//         return source
//             .AsParallel()
//             .Select(x => (Number: x, DigitSum: GetDigitSum(x)))
//             .OrderByDescending(x => x.DigitSum)
//             .ThenBy(x => x.Number) 
//             .First() 
//             .Number;
//         return (from x in source.AsParallel()
//                 let digitSum = GetDigitSum(x)
//                 orderby digitSum descending, x
//                 select x).First();
//     }
//     catch (AggregateException ex)
//     {
//         foreach (var inner in ex.Flatten().InnerExceptions)
//             Console.WriteLine($"Ошибка в потоке: {inner.Message}");
//         return null;
//     }
//     catch (InvalidOperationException ex)
//     {
//         Console.WriteLine($"Ошибка: коллекция пуста ({ex.Message})");
//         return null;
//     }
//     catch (ArgumentNullException ex)
//     {
//         Console.WriteLine($"Коллекция не передана: {ex.Message}");
//         return null;
//     }
// }

// int GetDigitSum(int number)
// {
//     int sum = 0;
//     for (int i = number; i > 0; i/=10)
//     {
//         sum+=i%10;
//     }
//     return sum;
// }