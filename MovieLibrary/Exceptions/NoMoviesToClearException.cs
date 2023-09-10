using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Exceptions
{
    internal class NoMoviesToClearException : Exception
    {
        public NoMoviesToClearException(string msg) : base(msg) { }
    }
}
