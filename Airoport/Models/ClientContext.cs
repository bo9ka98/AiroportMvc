using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }

    public class ClientsDbInitialize : DropCreateDatabaseAlways<ClientContext>
    {
        protected override void Seed(ClientContext db)
        {
            db.Clients.Add(new Client("Иван", "Пупкин"));
            db.Clients.Add(new Client("Евгений", "Пупкин"));
            db.Clients.Add(new Client("Василий", "Пупкин"));
            db.Clients.Add(new Client("Еватерина", "Соколова"));
            db.Clients.Add(new Client("Ксения", "Соколова"));
            db.Clients.Add(new Client("Иван", "Соколова"));

            base.Seed(db);
        }
    }
}