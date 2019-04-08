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
}