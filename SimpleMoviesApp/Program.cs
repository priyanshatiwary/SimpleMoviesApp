using SimpleMoviesApp.Controller;
using System.Net.NetworkInformation;
using System;

namespace SimpleMoviesApp
{

    internal class Program
    {
        
        static void Main(string[] args)
        {
            // Create an instance of the MovieController class to start managing movies
            new MovieController();

        }
    }
}