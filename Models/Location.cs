namespace Compant_System.DAL.Models;

public class Location
{
    public int Id { get; set; }

    public string LocationName { get; set; } = null!;

    public int DNumber { get; set; }

    public Department Department { get; set; } = null!;
}