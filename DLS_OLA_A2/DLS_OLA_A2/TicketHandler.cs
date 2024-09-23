using DLS_OLA_A2.Objects;
using Microsoft.EntityFrameworkCore;

namespace DLS_OLA_A2;

public class TicketHandler
{
     private ApplicationDbContext context;
    
    public TicketHandler(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    
    public void RecieveBarrels()
    {
        List<ChemicalBarrel> chemicalBarrelsToAdd = new List<ChemicalBarrel>();
        
        
        //Asks for the amount of barrels to recieve
        Console.WriteLine("How many different chemical barrels are we recieving?");
        int amount = Convert.ToInt32(Console.ReadLine());
        
        for(int i = 0; amount > i; i++)
        {
            //Asks for the chemical name
            Console.WriteLine("What is the name of the chemical?");
            string chemical = Console.ReadLine();
            
            //Asks for the amount of barrels
            Console.WriteLine("How many barrels of that type of chemical?");
            int barrelAmount = Convert.ToInt32(Console.ReadLine());
            
            //Creates the barrels
            ChemicalBarrel[] chemicalBarrels = new ChemicalBarrel[barrelAmount];
            for(int j = 0; barrelAmount > j; j++)
            {
                chemicalBarrels[j] = new ChemicalBarrel(chemical);
                
                //Adds the barrels to the database and List
                context.ChemicalBarrels.Add(chemicalBarrels[j]);
                chemicalBarrelsToAdd.Add(chemicalBarrels[j]);
            }
            
        }
        
        //Asks for which warehouse the barrels are being stored in
        Console.WriteLine("Which warehouse are the barrels being stored in?");
        //prints out all the warehouses
        foreach(Warehouse warehouse in context.Warehouses)
        {
            Console.WriteLine(warehouse.Id + " " + warehouse.Location);
        }
        
        //Asks for the warehouse id
        int warehouseId = Convert.ToInt32(Console.ReadLine());
        
        //Gets the warehouse object from the database and joins it stock to the warehouse object
        
        Warehouse warehouse2 = context.Warehouses
            .Include(w => w.Stock) // Eagerly load Stock
            .FirstOrDefault(w => w.Id == warehouseId);
        
        
        // Checks if the warehouse has enough capacity
        if(CheckWarehouseHasCapacity(warehouse2, chemicalBarrelsToAdd))
        {
            //Adds the barrels to the warehouse
            foreach(ChemicalBarrel barrel in chemicalBarrelsToAdd)
            {
                warehouse2.Stock.Add(barrel);
            }
            
            //Asks for driver and gate staff id after printing out all the drivers and gate staff
            Console.WriteLine("Which driver is delivering the barrels?");
            foreach(Driver driver in context.Drivers)
            {
                Console.WriteLine(driver.Id + " " + driver.Name);
            }
            int driverId = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Which gate staff is recieving the barrels?");
            foreach(Staff staff in context.Staff)
            {
                Console.WriteLine(staff.Id + " " + staff.Name);
            }
            int staffId = Convert.ToInt32(Console.ReadLine());
            
            Depot depot = GetDepotFromWarehouseId(warehouseId);
            //Creates a new Job
            Job job = new Job("Recieving", chemicalBarrelsToAdd, depot);
            
            //Creates a new ticket
            Ticket ticket = new Ticket(context.Drivers.Find(driverId), job, context.Staff.Find(staffId));
            
            //Creates a new audit
            Audit audit = new Audit(DateTime.Now, ticket);
            
            //Adds job, ticket and audit to the database
            context.Audits.Add(audit);
            context.SaveChanges();
            
        }
        else
        {
            Console.WriteLine("The warehouse does not have enough capacity for the barrels");
        }
        
        
        
        
    }
    
    
    private bool CheckWarehouseHasCapacity(Warehouse warehouse, List<ChemicalBarrel> chemicalBarrels)
    {
        if(warehouse.Capacity >= chemicalBarrels.Count + warehouse.Stock.Count)
        {
            return true;
        }
       return false;
    }
    
   
    private Depot GetDepotFromWarehouseId(int warehouseId)
    {
        // Use eager loading to ensure the Depot is loaded with the Warehouse
        Warehouse warehouse = context.Warehouses
            .Include(w => w.Depot) // Include the Depot explicitly
            .FirstOrDefault(w => w.Id == warehouseId);

        // If warehouse or its depot is null, handle accordingly
        if (warehouse == null || warehouse.Depot == null)
        {
            throw new Exception("Warehouse or associated Depot not found");
        }

        return warehouse.Depot;
    }
}