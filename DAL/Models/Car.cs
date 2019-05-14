using System;

namespace DAL.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public double Milage { get; set; }
    }
}
