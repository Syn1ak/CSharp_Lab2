﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2.Exceptions
{
    class PersonNotFoundException : Exception
    {
        public PersonNotFoundException(string message) : base(message)
        {

        }
    }
}
