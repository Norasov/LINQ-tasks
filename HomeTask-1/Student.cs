public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth {get;set;}
    public int Age { get; set; }
    public Gender Gender {get;set;}
    public Status Status {get;set;}
    public DateTime DateOfStart {get;set;}
    public DateTime DateOfFinish{get;set;}
}