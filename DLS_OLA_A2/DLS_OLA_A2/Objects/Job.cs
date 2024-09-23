namespace DLS_OLA_A2.Objects;

public class Job
{
    public int Id{ get; set; } // Primary key
    public string Status{ get; set; }
    public List<ChemicalBarrel> Shipment{ get; set; }
    public Depot Depot{ get; set; }
    
    
    public Job()
    {
    }
    public Job(int id, string status, List<ChemicalBarrel> shipment, Depot depot)
    {
        this.Id = id;
        this.Status = status;
        this.Shipment = shipment;
        this.Depot = depot;
    }
    
    public Job(string status, List<ChemicalBarrel> shipment, Depot depot)
    {
        this.Status = status;
        this.Shipment = shipment;
        this.Depot = depot;
    }
}