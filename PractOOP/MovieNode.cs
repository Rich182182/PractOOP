using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractOOP
{
    public class MovieNode
    {
        public Movie Movie { get; set; }
        public MovieNode Next { get; set; }
        public MovieNode Prev { get; set; }
        public MovieNode(Movie movie)
        {
            Movie = movie;
            Next = null;
            Prev = null;
        }
        public override string ToString()
        {
            return Movie.Title;
        }
    }
}
