

namespace DLS_OLA_A2.Objects
{
    public class Audit
    {
        public int Id { get; set; } // Primary key

        public DateTime Date { get; set; }

        public Ticket Ticket { get; set; }

        public Audit()
        {
        }

        public Audit(int id, DateTime date, Ticket ticket)
        {
            this.Id = id;
            this.Date = date;
            this.Ticket = ticket;
        }

        public Audit(DateTime date, Ticket ticket)
        {
            this.Date = date;
            this.Ticket = ticket;
        }
        
        
    }
}