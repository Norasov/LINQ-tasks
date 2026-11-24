// ClassTask 1

List<Employee> employees = new()
{
    new Employee
    {
        Id = 1,
        FirstName = "Muhammad",
        LastName = "Abdualimzoda",
        Age = 20,
        Salary = 1000,
        Experience = 3
    },
    new Employee
    {
        Id = 2,
        FirstName = "Farrukh",
        LastName = "Alimov",
        Age = 19,
        Salary = 6000,
        Experience = 5
    },
    new Employee
    {
        Id = 3,
        FirstName = "Odil",
        LastName = "Azizov",
        Age = 20,
        Salary = 3000,
        Experience = 2
    }
};

// task 1
// method syntax
// var salaries = employees.Select(s => s.Salary);

// query syntax
// var salaries = from s in employees
//                 select s.Salary;


// Task 2
// method syntax
// var names = employees
//     .Where(n => n.FirstName.Length > 6)
//     .Select(n => n.FirstName);

// query syntax
// var names = from n in employees
//             where n.FirstName.Length > 6
//             select n;

// Task 3
// method syntax
// var names = employees
//     .Where(n => n.Age > employees[0].Age)
//     .Select(n => n.FirstName);

// query syntax
// var names = from n in employees 
//             where n.Age > employees[0].Age
//             select n.FirstName;

// Task 4
// method syntax
// var e = employees
//     .Where(n => n.Experience * 2 == n.Age)
//     .Select(n => n.FirstName);

// query syntax
// var e = from n in employees
//         where n.Experience * 2 == n.Age
//         select n.FirstName;

// Task 5
// method syntax
// var emp = employees
//     .Where(e => e.Salary > 5000)
//     .OrderByDescending(e => e.Experience)
//     .Select(e => new{ e.FirstName, e.Experience, e.Salary});

// query syntax
// var emp = from e in employees
//     where e.Salary > 5000
//     orderby e.Experience descending
//     select new{e.FirstName, e.LastName, e.Salary} ;
