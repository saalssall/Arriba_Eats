

namespace A2;

public class Customer: User 
{
    private Location location;
    public Location Location
    {
        get
        {
            return location;
        }
    }
    
    public Customer(string name, int age, string email,string phoneNumber, string password, Location location,
        string UserType) :
        base(name, age, email, phoneNumber, password, UserType)
    {
        this.location = location;
    }
}