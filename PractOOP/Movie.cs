using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PractOOP
{
    public class Movie
    {
        public string Title { get; }
        public Genres Genre { get; }
        public Movie(string title, Genres genre)
        {
            Title = title;
            Genre = genre;
        }
        public void DisplayMovie()
        {
            Console.WriteLine($"Назва: {this.Title} Жанр: {GenreExtensions.DisplayGenre(this.Genre)}");
        }
        public override string ToString()
        {
            return Title;
        }
    }
}
