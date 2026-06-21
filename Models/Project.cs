namespace Compant_System.DAL.Models;

public class Project
{
    public int PNumber { get; set; }

    public string PName { get; set; } = null!;

    public string PLocation { get; set; } = null!;

    public int DNumber { get; set; }

    public Department Department { get; set; } = null!;

    public ICollection<Works_On> WorksOns { get; set; }
        = new List<Works_On>();
}