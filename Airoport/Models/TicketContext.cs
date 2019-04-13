using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
    }

    public class TicketDbInitialize : DropCreateDatabaseAlways<TicketContext>
    {
        protected override void Seed(TicketContext db)
        {
            db.Tickets.Add(new Ticket(2, 3, DateTime.MaxValue) { ClientId = 1, DateBuy = DateTime.Now});
            db.Tickets.Add(new Ticket(2, 4, DateTime.MaxValue) { ClientId = 1, DateBuy = DateTime.Now });
            db.Tickets.Add(new Ticket(4, 3, DateTime.MaxValue) { ClientId = 1, DateBuy = DateTime.Now });
            db.Tickets.Add(new Ticket(5, 3, DateTime.MaxValue) { ClientId = 1, DateBuy = DateTime.Now });
            db.Tickets.Add(new Ticket(2, 3, DateTime.MaxValue) { ClientId = 2, DateBuy = DateTime.Now });
            db.Tickets.Add(new Ticket(5, 3, DateTime.MaxValue) { ClientId = 2, DateBuy = DateTime.Now });
            db.Tickets.Add(new Ticket(6, 5, DateTime.MaxValue) { ClientId = 4, DateBuy = DateTime.Now });
            db.Tickets.Add(new Ticket(7, 3, DateTime.MaxValue) { ClientId = 4, DateBuy = DateTime.Now });

            base.Seed(db);
        }
    }
}