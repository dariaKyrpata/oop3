namespace BLL;

public class Mountaineer : IDrawable
{
    public string Name { get; set; } = "";

    public string ClimberId { get; set; } = "";

    public string Mountain { get; set; } = "";

    public int ClimbsCompleted { get; set; }

    public void CompleteClimb()
    {
        ClimbsCompleted++;
    }

    public string Draw()
    {
        return
            "       /\\\n" +
            "      /  \\\n" +
            "     / /\\ \\\n" +
            "    / /  \\ \\\n" +
            "   /_/____\\_\\\n" +
            "      ||";
    }

    public override string ToString()
    {
        return $"Mountaineer: {Name}, ID: {ClimberId}, " +
               $"Mountain: {Mountain}, Completed climbs: {ClimbsCompleted}";
    }
}