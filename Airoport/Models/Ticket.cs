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
        public DateTime DateTravels { get; set; } //set
        public DateTime DateBy { get; set; } //set
        public bool Registered { get; set; } // set private

        public Ticket()
        {

        }

        public void Tickett(City _start, City _finish, DateTime _date)
        {
            CityStart = _start;
            CityFinish = _finish;
            DateTravels = _date;
            DateBy = DateTime.Now;
        }

        public void RegisteredLanding()
        {
            Registered = true;
        }
    }
}