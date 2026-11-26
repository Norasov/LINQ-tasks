using System.ComponentModel.Design;

List<Person> people = new List<Person>
{
    new Person { Id = 1,  Name = "Alex",     Age = 30, CityId = 1 },
    new Person { Id = 2,  Name = "Bob",      Age = 25, CityId = 2 },
    new Person { Id = 3,  Name = "Irina",    Age = 28, CityId = 3 },
    new Person { Id = 4,  Name = "Anna",     Age = 5,  CityId = 3 },
    new Person { Id = 5,  Name = "Umar",     Age = 7,  CityId = 4 },
    new Person { Id = 6,  Name = "Olga",     Age = 26, CityId = 4 },
    new Person { Id = 7,  Name = "Aziz",     Age = 3,  CityId = 4 },
    new Person { Id = 8,  Name = "Madina",   Age = 22, CityId = 1 },
    new Person { Id = 9,  Name = "Emil",     Age = 2,  CityId = 3 },
    new Person { Id = 10, Name = "Bakhtior", Age = 40, CityId = 2 },
    new Person { Id = 11, Name = "Aisha",    Age = 6,  CityId = 1 },
    new Person { Id = 12, Name = "Zarina",   Age = 25, CityId = 5 },
    new Person { Id = 13, Name = "Ivan",     Age = 35, CityId = 3 },
};

List<City> cities = new List<City>
{
    new City { Id = 1, Name = "Dushanbe" },
    new City { Id = 2, Name = "Khujand" },
    new City { Id = 3, Name = "Astana" },
    new City { Id = 4, Name = "Almaty" },
    new City { Id = 5, Name = "Bishkek" },
};


// Task 1: Найдите всех людей старше 25 лет и спроецируйте их имена и возраст на новый анонимный тип.

// var olderThan25 = people
//     .Where(s => s.Age > 25 )
//     .Select(s=> new{s.Name, s.Age});

// var olderThan25 = from o in people
//                   where o.Age > 25
//                   select new{o.Name, o.Age};


// Task 2: Упорядочите людей по возрасту, а затем по именам в алфавитном порядке в пределах одного возраста.
// var ordered = people
//     .OrderBy(o => o.Age)
//     .ThenBy(o => o.Name);

// var ordered = from o in people
//               orderby o.Age, o.Name
//               select o;


// Task 3:Выберите первую букву имени каждого человека и сгруппируйте людей по этой букве.
// var groupByFirstLetters = people
//     .GroupBy(p => p.Name[0])

// var groupByFirstLetters = from o in people
//                           group o by o.Name[0];

// Task 4: Предположим, что существует еще один список объектов City. Присоединяйтесь к людям с городами на основе общего CityId и спроектируйте новый анонимный тип с именами людей и названиями городов.
// var peopleWithCities = people.join(
//     p => p.CityId,
//     c => c.Id,
//     (p,c) => new {PersonName = p.Name, CityName = c.Name}
// );
// var peopleWithCities = from p in people
//                        join c in cities on p.CityId equals c.Id
//                        select new {PersonName = p.Name, CityName = c.Name};

// Task 5: Вычислите общий возраст всех людей, имена которых начинаются с гласной.
// var totalAgeVowelNames = people
//     .Where(p => "AEIOUaeiou".Contains(p.Name[0]))
//     .Sum(p => p.Age);

// var totalAgeVowelNames = (from n in people
//                          where "AEIOUaeiou".Contains(n.Name[0])
//                          select n.Age).Sum();


// Task 6: Сгруппируйте людей по первой букве имени и посчитайте, сколько человек попадает в каждую группу.
// var countByFirstLetter = people
//     .GroupBy(n => n.Name[0])
//     .Select(g => new {Letter = g.Key, Count = g.Count()});

// var countByFirstLetter = from n in people       
//                          group n by n.Name[0] into g
//                          select new {Letter = g.Key, Count = g.Count()};


// Task 7:Выберите город, в котором максимальное количество людей
// var cityWithMostPeople = people
//     .GroupBy(p => p.CityId)
//     .OrderByDescending(g => g.Count())
//     .Select(g => cities.First(c => c.Id == g.Key))
//     .First();

// var cityWithMostPeople = (from p in people
//                          group p by p.CityId into g
//                          orderby g.Count() descending
//                          select cities.First(c => c.Id == g.Key)).First();


// Task 8
// var allChildren = people
//     .Where(p => p.Age >= 2 && p.Age <=7 &&
//         cities.Any(c => c.Id == p.CityId &&
//             c.Name.StartsWith("a", StringComparison.OrdinalIgnoreCase)));

// var allChildren = from p in people
//                   join c in cities on p.CityId equals c.Id
//                   where p.Age >= 2 && p.Age <= 7 &&
//                     c.Name.StartsWith("a", StringComparison.OrdinalIgnoreCase)
//                   select p;


// Task 1 from ClassTask-3:Напишите метод для фильтрации людей старше 30 лет и проецирования их имен с помощью оптимизированного запроса LINQ.
var names = people.Where(a => a.Age > 30).Select(a => a.Name).ToList();
names.ForEach(a => System.Console.WriteLine(a));

// Task 2 from ClassTask-3:Напишите метод для группировки людей по возрасту и подсчитайте количество людей в каждой возрастной группе с помощью оптимизированного запроса LINQ.
// var groupByAge = people 
//     .GroupBy(p => p.Age)
//     .Select(g => new {Age = g.Key, Count = g.Count()}).ToList();

// var groupByAge = from p in people       
//                  group p by p.Age into g
//                  select new {Age = g.Key, Count = g.Count()};


// Task 3 from ClassTask-3: Напишите метод для сортировки коллекции людей по возрасту и выбора 5 самых старых людей с помощью оптимизированного запроса LINQ.
// var oldest5People = people
//     .OrderByDescending(p => p.Age).Take(5);

// var oldest5People = (from p in people
//                     orderby p.Age descending 
//                     select p).Take(5);