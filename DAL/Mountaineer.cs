namespace DAL;

public class Mountaineer
{
    public string Name { get; set; } = "";

    public string ClimberId { get; set; } = "";

    public string Mountain { get; set; } = "";

    public int ClimbsCompleted { get; set; }

    public void CompleteClimb()
    {
        ClimbsCompleted++;
    }

    public override string ToString()
    {
        return $"Mountaineer: {Name}, ID: {ClimberId}, Mountain: {Mountain}, Completed climbs: {ClimbsCompleted}";
    }
}