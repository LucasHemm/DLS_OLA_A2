using System;
using System.Collections.Generic;
using DLS_OLA_A2.Objects;

namespace DLS_OLA_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Facade facade = new Facade(context);
            AuditHandler auditHandler = new AuditHandler(context);
            TicketHandler ticketHandler = new TicketHandler(context);

            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create Depot");
                Console.WriteLine("2. Create Warehouse");
                Console.WriteLine("3. View All Depots");
                Console.WriteLine("4. Create Staff");
                Console.WriteLine("5. Create Driver");
                Console.WriteLine("6. View All Audits");
                Console.WriteLine("7. Receive Barrels");
                Console.WriteLine("8. Exit");
                
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        CreateDepot(facade);
                        break;
                    case "2":
                        CreateWarehouse(facade);
                        break;
                    case "3":
                        ViewAllDepots(facade);
                        break;
                    case "4":
                        CreateStaff(facade);
                        break;
                    case "5":
                        CreateDriver(facade);
                        break;
                    case "6":
                        ViewAllAudits(auditHandler);
                        break;
                    case "7":
                        ReceiveBarrels(ticketHandler);
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                
                Console.WriteLine();
            }
        }

        static void CreateDepot(Facade facade)
        {
            Console.Write("Enter depot Name: ");
            string Name = Console.ReadLine();
            facade.CreateDepot(Name);
            Console.WriteLine("Depot created.");
        }

        static void CreateWarehouse(Facade facade)
        {
            // Display all depots before creating a warehouse
            Console.WriteLine("Available Depots:");
            var depots = facade.GetAllDepots();
            foreach (var depot in depots)
            {
                Console.WriteLine($"Depot ID: {depot.Id}, Name: {depot.Name}");
            }

            Console.Write("Enter depot ID to assign warehouse: ");
            int depotId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter warehouse capacity: ");
            int capacity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter warehouse location: ");
            string location = Console.ReadLine();

            facade.CreateWarehouse(capacity, location, depotId);
            Console.WriteLine("Warehouse created.");
        }

        static void ViewAllDepots(Facade facade)
        {
            var depots = facade.GetAllDepots();
            foreach (var depot in depots)
            {
                Console.WriteLine($"Depot ID: {depot.Id}, Name: {depot.Name}");
            }
        }

        static void CreateStaff(Facade facade)
        {
            Console.Write("Enter staff name: ");
            string name = Console.ReadLine();
            Console.Write("Enter staff phone number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter staff role: ");
            string role = Console.ReadLine();

            Console.WriteLine("Available Depots:");
            var depots = facade.GetAllDepots();
            foreach (var depot in depots)
            {
                Console.WriteLine($"Depot ID: {depot.Id}, Name: {depot.Name}");
            }

            Console.Write("Enter depot ID: ");
            int depotId = Convert.ToInt32(Console.ReadLine());
            Depot selectedDepot = depots.Find(d => d.Id == depotId);

            facade.CreateStaff(name, phoneNumber, role, selectedDepot);
            Console.WriteLine("Staff created.");
        }

        static void CreateDriver(Facade facade)
        {
            Console.Write("Enter driver name: ");
            string name = Console.ReadLine();
            Console.Write("Enter driver phone number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());

            facade.CreateDriver(name, phoneNumber);
            Console.WriteLine("Driver created.");
        }

        static void ViewAllAudits(AuditHandler auditHandler)
        {
            auditHandler.GetAllAudits();
        }

        static void ReceiveBarrels(TicketHandler ticketHandler)
        {
            ticketHandler.RecieveBarrels();
        }
    }
}
