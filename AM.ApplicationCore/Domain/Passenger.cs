using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        public FullName FullName { get; set; }


        public IList<ReservationTicket> ReservationTickets { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        [Range(0, 8)]
        public int? TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "FirstName: " + FullName.FirstName + " LastName: " + FullName.LastName + " date of Birth: " + BirthDate;
        }

       // poly par signature
        public bool CheckProfile(string firstName, string lastName)
        {
            return FullName.FirstName == firstName && FullName.LastName == lastName;

        }

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
        }

        public bool login(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
            return FullName.FirstName == firstName && FullName.LastName == lastName;
        }

        public bool login1(string firstName, string lastName, string email = null)
        {
            if (email != null)
                return CheckProfile(firstName, lastName, email);
            return FullName.FirstName == firstName && FullName.LastName == lastName;
        }

        //poly par héritage 
        public virtual void PassengerType()
        {

            Console.WriteLine("I'Passenger");
        }

    }
}
