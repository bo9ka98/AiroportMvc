using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public City CityStart { get; set; } //set
        public City CityFinish { get; set; } //set
        public DateTime Date { get; set; } //set
        public bool Registered { get; set; } // set private

        public Ticket() { }

        public Ticket(City _start, City _finish, DateTime _date)
        {
            CityStart = _start;
            CityFinish = _finish;
            Date = _date;
        }

        public void RegisteredLanding()
        {
            Registered = true;
        }
    }
}