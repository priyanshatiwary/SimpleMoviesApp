using System;
using MovieLibrary;
using System.Collections.Generic;
using System.Linq;
using System.CodeDom;

namespace SimpleMoviesApp.Controller
{
    public class MovieController
    {
        // Constructor for MovieController
        public MovieController()
        {
            MainMenu();

        }
        // Main menu for user interaction
        private static void MainMenu()
        {
            int choice;
            do
            {

                ShowMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                // Handle user choices using a switch statement
                switch (choice)
                {
                    case 1:
                        DisplayMovie();
                        break;
                    case 2:
                        DisplayByYear();

                        break;
                    case 3:
                        AddMovie();

                        break;
                    case 4:
                        RemoveMovie();

                        break;
                    case 5:
                        ClearMovies();

                        break;
                    case 6:
                        MovieExit();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option number from menu.");
                        break;
                }

            } while (choice != 6);
        }

        // Method to display the list of movies
        private static void DisplayMovie()
        {
            try
            {

                List<Movie> movies = MovieManager.DisplayMovie();
                foreach (Movie movie in movies)
                {
                    if (movie != null)
                        Console.WriteLine(MovieManager.MovieInformation(movie));
                    else
                        break;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Method to add a movie
        static void AddMovie()
        {

            try
            {
                if (MovieManager.GetMovieCount <= 5)
                {
                    Console.Write("Enter Movie Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Movie Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Movie Genre: ");
                    string genre = Console.ReadLine();

                    Console.Write("Enter Movie Year: ");
                    int year = Convert.ToInt32(Console.ReadLine());

                    // Movie movie = new Movie(id, name, genre, year);
                    // movies.Add(movie);

                    // DataSerializer.BinarySerializer(filePath, movies);
                    MovieManager.Add(id, name, genre, year);
                    Console.WriteLine("Movie has been added successfully.");
                    Console.WriteLine("---------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // Method to clear all movies

        static void ClearMovies()
        {

            try
            {
                // movies.Clear();
                MovieManager.Clear();
                Console.WriteLine("All movies have been cleared. ");
                Console.WriteLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        // Method to exit the program
        static void MovieExit()
        {
            Environment.Exit(0);
        }
        // Method to display the main menu
        static void ShowMenu()
        {
            MovieManager.ShowMenu();
            Console.WriteLine($"Movie Store Status: {MovieManager.GetMovieCount} / 5"); //max 5 movies
            Console.WriteLine("=============Menu===================");
            Console.WriteLine("1. Display movies");
            Console.WriteLine("2. Display Movies by Year");
            Console.WriteLine("3. Add movie");
            Console.WriteLine("4. Remove Movie (by name)");
            Console.WriteLine("5. Clear all movies");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice from 1 to 6: ");
            Console.WriteLine();

        }

        static void RemoveMovie()
        {
            try
            {
                Console.Write("Enter the name of the movie to remove: ");
                string movieName = Console.ReadLine();

                MovieManager.Remove(movieName);
                Console.WriteLine($"The movie '{movieName}' has been removed");
                MovieManager.ShowMenu(); // Update the in-memory list and status
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        // Method to display movies by a specific year       
        public static void DisplayByYear()
        {
            try
            {
                Console.WriteLine("Enter Year");
                int response = Convert.ToInt32(Console.ReadLine());

                List<Movie> findMovie = MovieManager.FindMoviesByYear(response);

                foreach (Movie movie in findMovie)
                {
                    Console.WriteLine(MovieManager.MovieInformation(movie));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}