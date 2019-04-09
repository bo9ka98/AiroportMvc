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
            db.Tickets.Add(new Ticket(2,3, DateTime.Now));

            base.Seed(db);
        }
    }
}