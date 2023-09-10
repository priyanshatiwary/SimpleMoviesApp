using MovieLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieManager
    {
        // Static fields and properties to manage movie data

        //specifies the path to a file where movie data is serialized.
        public static string filePath = @"D:\Aurionpro\Day 12\SimpleMoviesApp\MovieFile.txt";
        public static List<Movie> movies = new List<Movie>();


        public static int GetMovieCount { get { return movies.Count; } }

        // Constructor to initialize movie data from a file
        public MovieManager()
        {
            //it loads existing movie data when the MovieManager object is created.
            movies = DataSerializer.BinaryDeserializer(filePath);//populate list      
        }
        // Method to add a new movie to the collection
        public static void Add(int id, string name, string genre, int year)
        {
            if (GetMovieCount >= 5)
            {

                throw new MovieStorageFullException("Cannot add more movies. Movie storage is full.");
                //return;            
            }
            else
            {
                Movie movie = new Movie(id, name, genre, year);
                movies.Add(movie);
                DataSerializer.BinarySerializer(filePath, movies);
            }

        }

        // Method to clear all movies from the collection
        public static void Clear()
        {
            if (GetMovieCount == 0)
            {
                throw new NoMoviesToClearException("There are no movies to clear."
                    + "\n---------------------------------------------");
            }
            else
            {
                movies.Clear();
                DataSerializer.BinarySerializer(filePath, movies);

            }
        }
        // Method to update in-memory movie data from a file
        public static void ShowMenu()
        {
            //Updates the in-memory movies list by deserializing movie data from the file.
            movies = DataSerializer.BinaryDeserializer(filePath); //populate list
        }

        // Method to remove a movie by its name
        public static void Remove(string name)
        {
            int numberOfMoviesRemoved = movies.RemoveAll(movie => movie.Name.Equals(name));

            if (numberOfMoviesRemoved > 0)
            {
                DataSerializer.BinarySerializer(filePath, movies); // Update the file
            }
            else
            {
                throw new NoMoviesOfThisNameException("There are no movies of this name in the movie list");
            }
        }

        // Method to filter and display movies by a specific year     
        public static List<Movie> DisplayMovie()
        {
            if (GetMovieCount == 0)
            {
                throw new NoMoviesFoundException("There are no movies to Display ");

            }
            else
            {
                return movies;
            }
        }
        public static string MovieInformation(Movie movie)
        {
            return $"Movie Name : {movie.Name}\n" +
                $"Movie ID : {movie.Id}\n" +
                $"Genre : {movie.Genre}\n" +
                $"Year : {movie.Year}\n" +
                $"-----------------------------------";
        }

        public static List<Movie> FindMoviesByYear(int response)
        {
            if (GetMovieCount == 0)
            {
                throw new NoMoviesFoundException("No Movies Found");

            }
            List<Movie> foundMovies = movies.FindAll(Movie => Movie.Year == response);
            if (foundMovies.Count == 0)
            {
                throw new NoMoviesFoundForThisYearException("There are no movies for year : " + response);
            }
            return foundMovies;
        }
    }

}


    


