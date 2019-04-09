using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public List<Ticket> TicketListId { get; set; }

        public Client()
        {

        }

        public Client(string _name, string _surname) :
            base(_name, _surname)
        {
        }

        public void AddTicket(Ticket _ticket)
        {
            TicketListId.Add(_ticket);
        }

    }
}