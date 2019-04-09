using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DepartCityId { get; set; } //set
        public int ArrivalCityId { get; set; } //set
        public DateTime DateTravels { get; set; } //set
        public DateTime DateBuy { get; set; } //set
        public bool Registered { get; set; } // set private

        public Ticket()
        {

        }

        public void Tickett(int departCityId, int arrivalCityId, DateTime _date)
        {
            DepartCityId = departCityId;
            ArrivalCityId = arrivalCityId;
            DateTravels = _date;
            DateBuy = DateTime.Now;
        }

        public void RegisteredLanding()
        {
            Registered = true;
        }
    }
}