using System;
using System.Collections.Generic;
using System.Text;

namespace DbContactLibrary.Models
{
    public class C2A
    {
        public int ID { get; set; }
        public int CID { get; set; }
        public int AID { get; set; }

        public override string ToString()
        {
            return $"Adress {AID} maps to contact {CID}";
        }
    }
}
