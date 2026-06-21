namespace Compant_System.DAL.Models;

public class Employee
{
    public int SSN { get; set; }

    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    public DateTime BDate { get; set; }

    public string Address { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public decimal Salary { get; set; }

    public int? SuperSSN { get; set; }

    public int Dno { get; set; }

    public Employee? Supervisor { get; set; }

    public ICollection<Employee> Subordinates { get; set; }
        = new List<Employee>();

    public Department Department { get; set; } = null!;

    public ICollection<Dependent> Dependents { get; set; }
        = new List<Dependent>();

    public ICollection<Works_On> WorksOns { get; set; }
        = new List<Works_On>();
}