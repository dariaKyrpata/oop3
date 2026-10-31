namespace BLL;

public class Student : IDrawable
{
    public string LastName { get; set; } = "";

    public string FirstName { get; set; } = "";

    public int Course { get; set; }

    public string StudentId { get; set; } = "";

    public bool HasScholarship { get; set; }

    public string PassportSeries { get; set; } = "";

    public string PassportNumber { get; set; } = "";

    public string Draw()
    {
        return
            "   /\\\n" +
            "  /  \\\n" +
            " /____\\\n" +
            " |    |\n" +
            " |____|";
    }
}