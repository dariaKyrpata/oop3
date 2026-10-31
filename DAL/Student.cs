namespace DAL;

public class Student
{
    public string LastName { get; set; } = "";

    public string FirstName { get; set; } = "";

    public int Course { get; set; }

    public string StudentId { get; set; } = "";

    public bool HasScholarship { get; set; }

    public string PassportSeries { get; set; } = "";

    public string PassportNumber { get; set; } = "";
}