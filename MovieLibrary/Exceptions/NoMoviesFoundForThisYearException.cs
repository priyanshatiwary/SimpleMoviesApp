using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Exceptions
{
    internal class NoMoviesFoundForThisYearException : Exception
    {
        public NoMoviesFoundForThisYearException(string msg) : base(msg) { }

    }
}
