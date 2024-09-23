
namespace DLS_OLA_A2.Objects;

public class Warehouse
{
    
    public int Id{ get; set; } // Primary key
    public int Capacity{ get; set; }
    public List<ChemicalBarrel> Stock{ get; set; }
    public string Location{ get; set; }

    
    public Warehouse()
    {
    }
    
    public Warehouse(int id, int capacity, List<ChemicalBarrel> stock, string location)
    {
        this.Id = id;
        this.Capacity = capacity;
        this.Stock = stock;
        this.Location = location;
    }

    public Warehouse(int capacity, List<ChemicalBarrel> stock, string location)
    {
        this.Capacity = capacity;
        this.Stock = stock;
        this.Location = location;
    }

}