namespace Compant_System.DAL.Models;

public class Works_On
{
    public int SSN { get; set; }

    public int PNumber { get; set; }

    public int Hours { get; set; }

    public Employee Employee { get; set; } = null!;

    public Project Project { get; set; } = null!;
}