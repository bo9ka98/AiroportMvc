using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airoport.Models
{
    public class Ticket
    {
        [ScaffoldColumn(false)]
        public int? Id { get; set; }

        [DataType(DataType.Text), HiddenInput(DisplayValue = true)]
        public int ClientId { get; set; }

        [Display(Name = "Летим из"), Required(ErrorMessage = "Установите город отправления")]
        public int DepartCityId { get; set; } //set //

        [Display(Name = "Летим в"), Required(ErrorMessage = "Установите город прибытия")]
        public int ArrivalCityId { get; set; } //set

        [DataType(DataType.DateTime), Display (Name = "Дата отправления"), Required(ErrorMessage = "Установите дату")]
        public DateTime DateTravels { get; set; } //set

        [HiddenInput(DisplayValue = true)]
        public DateTime DateBuy { get; set; } //set

        [UIHint("Boolean"), Display(Name = "Регистрация на посадку")]
        public bool Registered { get; set; } // set private


        public Ticket()
        {

        }

        public Ticket(int departCityId, int arrivalCityId, DateTime dateTravels)
        {
            DepartCityId = departCityId;
            ArrivalCityId = arrivalCityId;
            DateTravels = dateTravels;
            DateBuy = DateTime.Now;
        }

        public void RegisteredLanding()
        {
            Registered = true;
        }
    }
}