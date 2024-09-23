
namespace DLS_OLA_A2.Objects;

public class Staff
{
  
    public int Id{ get; set; } // Primary key, now a property
    public string Name{ get; set; }
    public int PhoneNumber{ get; set; }
    public string Role{ get; set; }
    
    public Depot Depot{ get; set; }


    public Staff()
    {
    }

    public Staff(int id, string name, int phoneNumber, string role)
    {
        this.Id = id;
        this.Name = name;
        this.PhoneNumber = phoneNumber;
        this.Role = role;
    }
    
    public Staff(string name, int phoneNumber, string role)
    {
        this.Name = name;
        this.PhoneNumber = phoneNumber;
        this.Role = role;
    }
    public Staff(string name, int phoneNumber, string role, Depot depot)
    {
        this.Name = name;
        this.PhoneNumber = phoneNumber;
        this.Role = role;
        this.Depot = depot;
    }
}