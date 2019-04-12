using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class Man
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Man() { }

        public Man(string _name, string _surname)
        {
            Surname = _surname;
            Name = _name;
        }
    }

    public class Client : Man
    {
        [ScaffoldColumn(false)]
        public int? Id { get; set; }
        public List<Ticket> TicketListId { get; set; }

        [ScaffoldColumn(false)]
        public static int countClients;

        public Client()
        {
            countClients++;
        }

        public Client(string _name, string _surname) :
            base(_name, _surname)
        {
            countClients++;
        }

        public void AddTicket(Ticket _ticket)
        {
            TicketListId.Add(_ticket);
        }

    }
}