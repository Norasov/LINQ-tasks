public class Employee
{
    public int Id {get;set;}
    public required string Name {get;set;}
    public string Department {get;set;}=null!;
    public decimal Salary {get;set;}
}