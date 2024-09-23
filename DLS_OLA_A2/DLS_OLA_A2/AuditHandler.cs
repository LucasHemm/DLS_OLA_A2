using DLS_OLA_A2.Objects;
using Microsoft.EntityFrameworkCore;

namespace DLS_OLA_A2;

public class AuditHandler
{
    private ApplicationDbContext context;
    
    public AuditHandler(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    //Gets all audits and log them to the console
    private void PrintAllWarehousesStockAndCapacity()
    {
        // Retrieve all data in one query
        var warehouses = context.Warehouses
            .Include(w => w.Stock) // Eagerly load Stock
            .ToList();

        Console.WriteLine("Warehouses: ");
        foreach (var warehouse in warehouses)
        {
            Console.WriteLine("Warehouse Location: " + warehouse.Location);
            Console.WriteLine("Warehouse Capacity: " + warehouse.Capacity);
            Console.WriteLine("Warehouse Stock " + "(" + warehouse.Stock.Count+  ")"+ ": ");
                
            foreach (var barrel in warehouse.Stock)
            {
                Console.WriteLine(" - " + barrel.Chemical); // Assuming 'Chemical' is a string property
            }
        }
    }
    
    //Gets all audits and log them to the console
    public void GetAllAudits()
{
    using (var db = new ApplicationDbContext())
    {
        // Retrieve all data in one query
        var audits = from a in db.Audits
                     join t in db.Tickets on a.Ticket.Id equals t.Id
                     join d in db.Drivers on t.Driver.Id equals d.Id into drivers
                     from d in drivers.DefaultIfEmpty() // Left join for Drivers
                     join j in db.Jobs on t.Job.Id equals j.Id into jobs
                     from j in jobs.DefaultIfEmpty() // Left join for Jobs
                     join s in db.Staff on t.GateStaff.Id equals s.Id into staff
                     from s in staff.DefaultIfEmpty() // Left join for Staff
                     join dep in db.Depots on j.Depot.Id equals dep.Id into depots
                     from dep in depots.DefaultIfEmpty() // Left join for Depots
                     select new 
                     { 
                         a, 
                         t, 
                         d, 
                         j, 
                         s, 
                         dep, 
                         ChemicalBarrels = j.Shipment// Include ChemicalBarrels if it's a navigation property
                     };

        foreach (var audit in audits)
        {
            // Null checks
            if (audit.t == null || audit.j == null || audit.s == null || audit.dep == null)
            {
                Console.WriteLine("Some related data is missing.");
                continue;
            }

            var chemicalBarrels = audit.ChemicalBarrels ?? new List<ChemicalBarrel>();

            Console.WriteLine($"Audit ID: {audit.a.Id}");
            Console.WriteLine($"Audit Date: {audit.a.Date}");

            if (audit.d != null)
            {
                Console.WriteLine($"Driver Name: {audit.d.Name}");
            }
            else
            {
                Console.WriteLine("Driver information is missing.");
            }

            Console.WriteLine($"Job Status: {audit.j.Status}");

            if (audit.s != null)
            {
                Console.WriteLine($"Gate Staff Name: {audit.s.Name}");
            }
            else
            {
                Console.WriteLine("Gate Staff information is missing.");
            }

            Console.WriteLine($"Amount of barrels ({chemicalBarrels.Count}): ");

            foreach (var shipment in chemicalBarrels)
            {
                
                Console.WriteLine($"Shipment Chemical: {shipment.Chemical}");
            }

            Console.WriteLine();
            PrintAllWarehousesStockAndCapacity();
            Console.WriteLine();
        }
    }
}


}