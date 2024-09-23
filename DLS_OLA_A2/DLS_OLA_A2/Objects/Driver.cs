
namespace DLS_OLA_A2.Objects;

public class Driver
{
    
    public int Id{ get; set; } // Primary key, now a property
    public string Name{ get; set; }
    public int PhoneNumber{ get; set; }
    
    
    public Driver()
    {
    }
    public Driver(int id, string name, int phoneNumber)
    {
        this.Id = id;
        this.Name = name;
        this.PhoneNumber = phoneNumber;
    }
    
    public Driver(string name, int phoneNumber)
    {
        this.Name = name;
        this.PhoneNumber = phoneNumber;
    }
}