List<Student> students = new List<Student>
{
    new Student { StudentId = 1, Name = "Alice", DateOfBirth = new DateTime(2000, 5, 15) },
    new Student { StudentId = 2, Name = "Bob", DateOfBirth = new DateTime(1999, 8, 25) },
    new Student { StudentId = 3, Name = "Charlie", DateOfBirth = new DateTime(2001, 3, 10) }
};


List<Course> courses = new List<Course>
{
    new Course { CourseId = 101, Title = "Mathematics", Credits = 4 },
    new Course { CourseId = 102, Title = "Computer Science", Credits = 3 },
    new Course { CourseId = 103, Title = "Physics", Credits = 4 }
};


List<Enrollment> enrollments = new List<Enrollment>
{
    new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 15) },
    new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 20) },
    new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 18) },
    new Enrollment { EnrollmentId = 4, StudentId = 3, CourseId = 103, EnrollmentDate = new DateTime(2023, 1, 22) },
    new Enrollment { EnrollmentId = 5, StudentId = 3, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 25) },
    new Enrollment { EnrollmentId = 6, StudentId = 3, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 30) }
};


// Task 1: Найдите всех студентов, обучающихся по курсу «Математика».

// var mathStudents = students
//     .Join(enrollments, s => s.StudentId, e => e.StudentId, (s, e) => new { Student = s, e.CourseId })
//     .Join(courses, x => x.CourseId, c => c.CourseId, (x, c) => new { x.Student, CourseTitle = c.Title })
//     .Where(x => x.CourseTitle == "Mathematics")
//     .Select(x => x.Student);

// var mathStudents = from s in students
//                    join e in enrollments on s.StudenttId equals e.StudenttId
//                    join c in courses on e.CourseId equals c.CourseId
//                    where c.Title == "Mathematics"
//                    select s;

// Task 2: курсы, на которые записан "Charlie"
var charlieCourses = students
    .Where(s => s.Name == "Charlie")
    .Join(enrollments, s => s.StudentId, e => e.StudentId, (s, e) => e)
    .Join(courses, e => e.CourseId, c => c.CourseId, (e, c) => c);
// var charlieCourses = from s in students
//                      where s.Name == "Charlie"
//                      join e in enrollments on s.StudenttId equals e.StudenttId
//                      join c in courses on e.CourseId equals c.CourseId
//                      select c;


// Task 3: SelectMany, студенты, записанные больше чем на один курс
var multiCourseStudents = enrollments
    .GroupBy(e => e.StudentId)
    .Where(g => g.Count() > 1)
    .SelectMany(g => students.Where(s => s.StudentId == g.Key));
// var multiCourseStudents = from g in enrollments.GroupBy(e => e.StudenttId)
//                           where g.Count() > 1
//                           from s in students
//                           where s.StudenttId == g.Key
//                           select s;
