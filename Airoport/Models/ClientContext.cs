using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class ClientContext : DbContext
    {
        private static ClientContext instance;

        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        private ClientContext() { }

        public static ClientContext getInstance()
        {
            if (instance == null)
                instance = new ClientContext();
            return instance;
        }

    }

    public class CitiesDbInitialize : DropCreateDatabaseAlways<ClientContext>
    {
        protected override void Seed(ClientContext db)
        {
            string[] cities = { "Бобруйск", "Барановичи", "Борисов", "Барань", "Белоозерск", "Береза",
                    "Березино", "Березовка","Браслав","Брест","Буда-Кошелево","Быхов","Минск", };
            //Источник: http://obzorurokov.ru/belarus/goroda-belorussii-spisok.html}
            foreach (string city in cities)
            {
                db.Cities.Add(new City(city));
            }
            base.Seed(db);
        }
    }
}