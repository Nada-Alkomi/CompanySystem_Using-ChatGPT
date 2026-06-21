namespace Compant_System.DAL.Models;

public class Dependent
{
    public int Id { get; set; }

    public string DependentName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Relationship { get; set; } = null!;

    public int SSN { get; set; }

    public Employee Employee { get; set; } = null!;
}