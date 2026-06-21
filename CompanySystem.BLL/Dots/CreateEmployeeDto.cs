namespace Compant_System.BLL.Dots;

public class CreateEmployeeDto
{
    public string FName { get; set; }

    public string LName { get; set; }

    public DateTime BDate { get; set; }

    public string Address { get; set; }

    public string Gender { get; set; }

    public decimal Salary { get; set; }

    public int Dno { get; set; }

    public int? SuperSSN { get; set; }
}