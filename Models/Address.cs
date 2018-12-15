using System;
using System.Collections.Generic;
using System.Text;

namespace DbContactLibrary.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"{Street}\r\n{Zip}, {City}";
        }
    }
}
