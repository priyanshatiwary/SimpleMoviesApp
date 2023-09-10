using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    [Serializable]
    public class Movie
    {
        

            // Properties to store movie information
            public int Id { get; set; }
            public string Name { get; set; }
            public string Genre { get; set; }
            public int Year { get; set; }

            // Constructor to create a Movie object with all properties
            public Movie(int id, string name, string genre, int year)
            {
                Id = id;
                Name = name;
                Genre = genre;
                Year = year;
            }

            // Constructor to create a Movie object with just the year
            public Movie(int year)
            {
                Year = year;
            }

            // Constructor to create a Movie object with just the name
            public Movie(string name)
            {
                Name = name;
            }
        }
    }

