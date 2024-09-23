
namespace DLS_OLA_A2.Objects;

public class Depot
{
   
    public int Id{ get; set; } // Primary key, now a property
    public string Name{ get; set; }
    
    public List<Warehouse> Warehouses{ get; set; }
    public List<Staff> Staff{ get; set; }

    public Depot()
    {
    }

    public Depot(int id, List<Warehouse> warehouses, List<Staff> staff)
    {
        this.Id = id;
        this.Warehouses = warehouses;
        this.Staff = staff;
    }
    public Depot(string name)
    {
        this.Name = name;
    }
    
    public Depot(List<Warehouse> warehouses, List<Staff> staff)
    {
        this.Warehouses = warehouses;
        this.Staff = staff;
    }
}