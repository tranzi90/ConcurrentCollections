using System;
using System.Collections.Concurrent;

namespace ConcurrentCollections
{
    internal class Program
    {
        private static void Main()
        {
            ConcurrentDictionary<string, double> movieRating = new ConcurrentDictionary<string, double>();
            movieRating.TryAdd("Avengers: Endgame", 8.8);
            movieRating.TryAdd("The Departed", 8.5);
            movieRating.TryAdd("Santa Barbara", 2.5);
            movieRating.TryAdd("The Shawshank Redemption", 9.3);

            movieRating.TryAdd("The Dark Knight", 8.5);

            Console.WriteLine($"Количество фильмов в коллекции - {movieRating.Count}");
            EnumerateMovies(movieRating);

            movieRating.TryAdd("Fight Club", 8.8);

            //double santaBarbaraValue = movieRating["Santa Barbara"];
            //bool isSuccess = movieRating.TryUpdate("Santa Barbara", santaBarbaraValue * 2, santaBarbaraValue);

            double santaBarbaraValue = movieRating.AddOrUpdate("Santa Barbara", 1.0, (key, oldValue) => oldValue * 2);

            Console.WriteLine($"У сериала Santa Barbara рейтинг - {santaBarbaraValue} \n");

            //bool isSuccess = movieRating.TryGetValue("The Dark Knight", out double theDarkKnightValue);

            //if (isSuccess == true)
            //{
            //    Console.WriteLine($"У фильма The Dark Knight рейтинг - {theDarkKnightValue} \n");
            //}

            Console.WriteLine($"У фильма The Dark Knight рейтинг - {movieRating.GetOrAdd("The Dark Knight", 0)} \n");


            bool isSuccess = movieRating.TryRemove("Santa Barbara", out double _);
            Console.WriteLine($"Удаление успешно - {isSuccess}");
            Console.WriteLine($"Количество фильмов в рейтинге - {movieRating.Count}");

            EnumerateMovies(movieRating);
            Console.ReadKey();
        }

        private static void EnumerateMovies(ConcurrentDictionary<string, double> movieRating)
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
