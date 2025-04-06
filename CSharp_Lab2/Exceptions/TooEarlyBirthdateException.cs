using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab2.Exceptions
{
    class TooEarlyBirthdateException : PersonValidationException
    {
        public TooEarlyBirthdateException(string message) : base(message)
        {
        }
    }
}
