
List<Student> students = new List<Student>
{
    new Student { Id = 1, FirstName = "Alex",   LastName = "Adams",    Age = 21, Gender = Gender.Male,
                  DateOfBirth = new DateTime(2005, 3, 15),
                  Status = Status.Active,   DateOfStart = new DateTime(2023, 9, 1), DateOfFinish = new DateTime(2027, 6, 30) },
    new Student { Id = 2, FirstName = "Irina",  LastName = "Petrova",  Age = 23, Gender = Gender.Female,
                  DateOfBirth = new DateTime(2003, 7, 10),
                  Status = Status.Active,   DateOfStart = new DateTime(2021, 9, 1), DateOfFinish = new DateTime(2027, 6, 30) },
    new Student { Id = 3, FirstName = "Bob",    LastName = "Brown",    Age = 27, Gender = Gender.Male,
                  DateOfBirth = new DateTime(1999, 1, 20),
                  Status = Status.InActive, DateOfStart = new DateTime(2015, 9, 1), DateOfFinish = new DateTime(2019, 6, 30) },
    new Student { Id = 4, FirstName = "Rustam", LastName = "Saidov",   Age = 15, Gender = Gender.Male,
                  DateOfBirth = new DateTime(2011, 5, 5),
                  Status = Status.Active,   DateOfStart = new DateTime(2023, 9, 1), DateOfFinish = new DateTime(2027, 6, 30) },
    new Student { Id = 5, FirstName = "Aziz",   LastName = "Azimov",   Age = 23, Gender = Gender.Male,
                  DateOfBirth = new DateTime(2003, 2, 14),
                  Status = Status.Active,   DateOfStart = new DateTime(2018, 9, 1), DateOfFinish = new DateTime(2027, 6, 30) },
    new Student { Id = 6, FirstName = "Madina", LastName = "Mirzoeva", Age = 26, Gender = Gender.Female,
                  DateOfBirth = new DateTime(2000, 9, 30),
                  Status = Status.InActive, DateOfStart = new DateTime(2016, 9, 1), DateOfFinish = new DateTime(2020, 6, 30) },
    new Student { Id = 7, FirstName = "Ivan",   LastName = "Ivanov",   Age = 22, Gender = Gender.Male,
                  DateOfBirth = new DateTime(2004, 11, 2),
                  Status = Status.Active,   DateOfStart = new DateTime(2020, 9, 1), DateOfFinish = new DateTime(2027, 6, 30) },
    new Student { Id = 8, FirstName = "Sara",   LastName = "Smirnova", Age = 17, Gender = Gender.Female,
                  DateOfBirth = new DateTime(2009, 8, 18),
                  Status = Status.Active,   DateOfStart = new DateTime(2025, 9, 1), DateOfFinish = new DateTime(2029, 6, 30) }
};
// Task 1 
// var males = students
//     .Where(s => s.Gender == Gender.Male);

// var males = from m in students
//             where m.Gender == Gender.Male
//             select m.FirstName;

// Task 2
// var InActive = students
//     .Where(s => s.Status == Status.InActive);

// var InActive = from s in students
//                 where s.Status == Status.InActive
//                 select s.FirstName;

// Возраст человека на определённую дату



// Task 3: Используя список объектов Student, напишите запрос LINQ, чтобы выбрать студентов, дата рождения которых больше 2000 года. Распечатайте результат в операторе foreach.

int GetAgeOn(DateTime dateOfBirth, DateTime date)
{
    int age = date.Year - dateOfBirth.Year;
    if (dateOfBirth.Date > date.AddYears(-age)) age--;
    return age;
}

// var bornAfter2000 = students.Where(s => s.DateOfBirth.Year > 2000);

// var bornAfter2000 = from s in students
//                     where s.DateOfBirth.Year > 2000
//                     select s;

// Task 4: сейчас учатся и старше 20 лет
// var activeOver20 = students.Where(s => s.Status == Status.Active && s.Age > 20);

// var activeOver20 = from s in students
//                    where s.Status == Status.Active && s.Age > 20
//                    select s;


// Task 5: начали учиться в 16 лет
// var startedAt16 = students.Where(s => GetAgeOn(s.DateOfBirth, s.DateOfStart) == 16);

// var startedAt16 = from s in students
//                   where GetAgeOn(s.DateOfBirth, s.DateOfStart) == 16
//                   select s;


// Task 6: начали учиться в 18+ лет
// var startedAsAdults = students.Where(s => GetAgeOn(s.DateOfBirth, s.DateOfStart) >= 18);

// var startedAsAdults = from s in students
//                       where GetAgeOn(s.DateOfBirth, s.DateOfStart) >= 18
//                       select s;


// Task 9: стали совершеннолетними во время учёбы
// var becameAdultWhileStudying = students.Where(s =>
//     GetAgeOn(s.DateOfBirth, s.DateOfStart) < 18 &&
//     GetAgeOn(s.DateOfBirth, s.DateOfFinish) >= 18);

// var becameAdultWhileStudying = from s in students
//                                where GetAgeOn(s.DateOfBirth, s.DateOfStart) < 18 &&
//                                      GetAgeOn(s.DateOfBirth, s.DateOfFinish) >= 18
//                                select s;


// Task 7
// var names = students
//     .Where(n => n.FirstName.StartsWith('A') || n.FirstName.StartsWith('I'));

// var names = from n in students
//             where n.FirstName.StartsWith('A') || n.FirstName.StartsWith('I')
//             select n;

// Task 8
// var same = students
//     .Where(s => s.FirstName[0] == s.LastName[0]);

// var same = from s in students
//             where s.FirstName[0] == s.LastName[0]
//             select s;
