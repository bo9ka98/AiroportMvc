using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } // set временный

        public City() //из-за DB
        {

        }

        public City(string _name)
        {
            Name = _name;
        }
    }
}