namespace DAL;

public class Postman
{
    public string Name { get; set; } = "";

    public string EmployeeId { get; set; } = "";

    public string DeliveryArea { get; set; } = "";

    public int DeliveredLetters { get; set; }

    public void DeliverLetter()
    {
        DeliveredLetters++;
    }

    public override string ToString()
    {
        return $"Postman: {Name}, ID: {EmployeeId}, Area: {DeliveryArea}, Delivered letters: {DeliveredLetters}";
    }
}