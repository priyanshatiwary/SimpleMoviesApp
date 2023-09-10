using MovieLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class NoMoviesOfThisNameException: Exception
    {
        public NoMoviesOfThisNameException(string msg) : base(msg) { }
    }
}
