using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class DataSerializer
    {

        // Method for serializing movie data to a binary file
        public static void BinarySerializer(string filepath, List<Movie> movies)
        {
            using (FileStream filestream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filestream, movies);
            }
        }
        // Method for deserializing binary data back into a list of movies
        
        public static List<Movie> BinaryDeserializer(string filepath)
        {
            List<Movie> movies = new List<Movie>();
            using (FileStream filestream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (filestream.Length > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    movies = (List<Movie>)formatter.Deserialize(filestream);
                }

            }
            return movies;
        }
    }
}

