namespace Compant_System.DAL.Models;
using System.Collections.Generic;
public class Department
{
    public int DNumber { get; set; }

    public string DName { get; set; } = null!;

    public int? MgrSSN { get; set; }

    public DateTime MgrStartDate { get; set; }

    public Employee? Manager { get; set; }

    public ICollection<Employee> Employees { get; set; }
        = new List<Employee>();

    public ICollection<Project> Projects { get; set; }
        = new List<Project>();

    public ICollection<Location> Locations { get; set; }
        = new List<Location>();
}

