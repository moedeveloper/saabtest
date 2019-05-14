using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Payload
    {
        public string DateOfBirth { get; set; }
        public int CarCategory { get; set; }
        public double NumberOfKm { get; set; }
        public DateTime ReturnedDateTime { get; set; }
        public long BookingNumber { get; set; }
    }
}
