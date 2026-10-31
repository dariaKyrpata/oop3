namespace BLL;

public class Postman : IDrawable
{
    public string Name { get; set; } = "";

    public string EmployeeId { get; set; } = "";

    public string DeliveryArea { get; set; } = "";

    public int DeliveredLetters { get; set; }

    public void DeliverLetter()
    {
        DeliveredLetters++;
    }

    public string Draw()
    {
        return
            "  _________\n" +
            " |         |\n" +
            " |  MAIL   |\n" +
            " |_________|\n" +
            "     ||\n" +
            "     ||";
    }

    public override string ToString()
    {
        return $"Postman: {Name}, ID: {EmployeeId}, " +
               $"Area: {DeliveryArea}, Delivered letters: {DeliveredLetters}";
    }
}