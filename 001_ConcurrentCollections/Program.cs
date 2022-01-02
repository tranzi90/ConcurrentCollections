using System;
using System.Collections.Generic;

namespace ConcurrentCollections
{
    internal class Program
    {
        private static void Main()
        {
            Dictionary<string, double> movieRating = new Dictionary<string, double>()
            {
                { "Avengers: Endgame", 8.8},
                { "The Departed", 8.5},
                { "Santa Barbara", 5.7 },
                { "The Shawshank Redemption", 9.3}
            };

            movieRating.Add("The Dark Knight", 8.5);

            Console.WriteLine($"Количество фильмов в коллекции - {movieRating.Count}");
            EnumerateMovies(movieRating);

            movieRating["Fight Club"] = 8.8;
            movieRating["Santa Barbara"] = movieRating["Santa Barbara"] * 2;

            Console.WriteLine($"У сериала Santa Barbara рейтинг - {movieRating["Santa Barbara"]} \n");
            Console.WriteLine($"У фильма The Dark Knight рейтинг - {movieRating["The Dark Knight"]} \n");

            movieRating.Remove("Santa Barbara");
            Console.WriteLine($"Количество фильмов в коллекции после удаления - {movieRating.Count}");

            EnumerateMovies(movieRating);
            Console.ReadKey();
        }

        private static void EnumerateMovies(Dictionary<string, double> movieRating)
        {
            Console.WriteLine("Список фильмов:");
            foreach (var movie in movieRating)
            {
                Console.WriteLine($"Фильм \"{movie.Key}\" имеет рейтинг - [{movie.Value}]");
            }

            Console.WriteLine(new string('-', 80));
        }
    }
}
