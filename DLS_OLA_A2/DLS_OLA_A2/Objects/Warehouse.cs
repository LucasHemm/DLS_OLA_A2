
namespace DLS_OLA_A2.Objects;

public class Warehouse
{
    
    public int Id{ get; set; } // Primary key
    public int Capacity{ get; set; }
    public List<ChemicalBarrel> Stock{ get; set; }
    public string Location{ get; set; }
    public Depot Depot{ get; set; }

    
    public Warehouse()
    {
    }
    
    public Warehouse(int id, int capacity, List<ChemicalBarrel> stock, string location)
    {
        this.Id = id;
        this.Capacity = capacity;
        this.Stock = stock ?? new List<ChemicalBarrel>();
        this.Location = location;
    }

    public Warehouse(int capacity, List<ChemicalBarrel> stock, string location)
    {
        this.Capacity = capacity;
        this.Stock = stock ?? new List<ChemicalBarrel>();
        this.Location = location;
    }
    public Warehouse(int capacity, string location, Depot depot)
    {
        this.Capacity = capacity;
        this.Location = location;
        this.Depot = depot;
    }

}