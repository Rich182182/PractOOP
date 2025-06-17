using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractOOP
{
    public class MovieManager
    {
        public MovieNode Head { get; set; }
        public MovieNode Tail { get; set; }
        public MovieManager(Movie movie)
        {
            Head = new MovieNode(movie);
            Tail = Head;
        }
        public void AddMovie(Movie movie)
        {
            var movieNode = new MovieNode(movie);
            var node = Head;
            while (node != null)
            {
                if (CompareMoviesByTitle(movie, node.Movie) == node.Movie)
                {

                    if (node.Prev != null)
                    {
                        movieNode.Prev = node.Prev;
                        node.Prev.Next = movieNode;
                    }
                    if (node.Prev == null) Head = movieNode;
                    movieNode.Next = node;
                    node.Prev = movieNode;

                    return;
                }
                node = node.Next;
            }

            movieNode.Prev = Tail;
            Tail.Next = movieNode;
            Tail = movieNode;

        }
        public Movie CompareMoviesByTitle(Movie movie1, Movie movie2)
        {
            int i = 0;
            var title1 = movie1.Title.ToLower();
            var title2 = movie2.Title.ToLower();
            while (movie1.Title.Length >= i + 1 && movie2.Title.Length >= i + 1)
            {
                if (title1[i] > title2[i]) return movie1;

                else if (title1[i] < title2[i]) return movie2;
                i++;
            }

            return (movie1.Title.Length >= movie2.Title.Length) ? movie1 : movie2;
        }
        public void RemoveMovieByTitle(string title)
        {
            var node = Head;
            while (node.Movie.Title.ToLower() != title.ToLower() && node !=null)
            {
                node = node.Next;
            }
            if (node == null)
            {
                Console.WriteLine($"Фільму {title} немає в списку");
            }
            else
            {
                if (node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }
                else Tail = node.Prev;
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }
                else Head = node.Next;
            }

        }
        public int countMovies()
        {
            var count = 0;
            var node = Head;
            while (node != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }
        public void FindMovieByTitle(string title)
        {
            var node = Head;
            while (node.Movie.Title.ToLower() != title.ToLower() && node != null)
            {
                node = node.Next;
            }
            if (node == null)
            {
                Console.WriteLine($"Фільму {title} немає в списку");
            }
            node.Movie.DisplayMovie();
        }
        public void FilterByGenre(Genres genre)
        {
            var genreList = new List<MovieNode>();
            var node = Head;
            while (node != null)
            {
                if (genre == node.Movie.Genre)
                {
                    genreList.Add(node);
                }
                node = node.Next;
            }
            if (genreList.Count > 0)
            {
                foreach (var movie in genreList)
                {
                    movie.Movie.DisplayMovie();
                }
            }
            else
            {
                Console.WriteLine("фільмів з таким жанром не знайдено");
            }
        }
        public void DisplayMovies()
        {
            var node = Head;
            while (node != null)
            {
                node.Movie.DisplayMovie();
                node = node.Next;
            }
            Console.WriteLine();
        }
    }
}
