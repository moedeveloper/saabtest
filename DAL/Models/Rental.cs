using System;
using BLL.Models;

namespace DAL.Models
{
    public class Rental
    {
        public Guid Id { get; set; }

        public long BookingNumber { get; set; }
        public DateTime RentalDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public double Price { get; set; }
        public  Car Car { get; set; }
        public Customer Customer { get; set; }
    }
}
