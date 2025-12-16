namespace LibrusMauiApp.Models;

public class Rating : Base
{
    public string Name { get; set; }
    public float Score { get; set; }
    public Person Person { get; set; }    
}
