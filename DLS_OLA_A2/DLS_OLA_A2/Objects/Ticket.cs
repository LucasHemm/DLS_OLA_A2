using System.ComponentModel.DataAnnotations;

namespace DLS_OLA_A2.Objects;

public class Ticket
{
    [Key]
    public int Id{ get; set; } // Primary key
    public Driver Driver{ get; set; }
    public Job Job{ get; set; }
    public Staff GateStaff{ get; set; }
    
    public Ticket()
    {
    }
    public Ticket(int id, Driver driver, Job job, Staff gateStaff)
    {
        this.Id = id;
        this.Driver = driver;
        this.Job = job;
        this.GateStaff = gateStaff;
    }
    
    public Ticket(Driver driver, Job job, Staff gateStaff)
    {
        this.Driver = driver;
        this.Job = job;
        this.GateStaff = gateStaff;
    }
    
    
}