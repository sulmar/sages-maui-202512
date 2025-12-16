namespace LibrusMauiApp.Models;

public class Person : Base
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] Photo { get; set; }
        
    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
