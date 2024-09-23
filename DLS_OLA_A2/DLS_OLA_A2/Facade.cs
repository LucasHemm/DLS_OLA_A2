using DLS_OLA_A2.Objects;

namespace DLS_OLA_A2;

public class Facade
{
    
    private ApplicationDbContext context;
    
    public Facade(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    public  void CreateDepot(string location)
    {
        var depot = new Depot(location);
        context.Depots.Add(depot);
        context.SaveChanges();
    }
    
    //create a warehouse and add to db
    public void CreateWarehouse(int capacity, string location, int depotID)
    {
        var depot = context.Depots.Find(depotID);
        var warehouse = new Warehouse(capacity, location, depot);
        context.Warehouses.Add(warehouse);
        context.SaveChanges();
    }
    
    //get all depots
    public List<Depot> GetAllDepots()
    {
        return context.Depots.ToList();
    }
    
    //create a staff and save to db
    public void CreateStaff(string name, int phoneNumber, string role, Depot depot)
    {
        var staff = new Staff(name, phoneNumber, role, depot);
        context.Staff.Add(staff);
        context.SaveChanges();
    }
    
    //create driver and save to db
    public void CreateDriver(string name, int phoneNumber)
    {
        var driver = new Driver(name, phoneNumber);
        context.Drivers.Add(driver);
        context.SaveChanges();
    }
    
    
}