using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class CityContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
 
    }

    public class CitiesDbInitialize : DropCreateDatabaseAlways<CityContext>
    {
        protected override void Seed(CityContext db)
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