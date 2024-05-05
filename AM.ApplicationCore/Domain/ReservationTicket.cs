using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    {
        public double Prix { get; set; }
        public DateTime DateReservation { get; set; }
        public int TicketFk { get; set; }
        public string PassengerFk { get; set; }

        [ForeignKey("TicketFk")]
        public Ticket Ticket { get; set; }

        [ForeignKey("PassengerFk")]
        public Passenger Passenger { get; set; }

    }
}
