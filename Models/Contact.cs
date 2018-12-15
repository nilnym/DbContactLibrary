﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DbContactLibrary.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
