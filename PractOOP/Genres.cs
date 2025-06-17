using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PractOOP
{
    public enum Genres
    {
        [Display(Name = "Бойовик")]
        Action,
        [Display(Name = "Комедія")]
        Comedy,
        [Display(Name = "Драма")]
        Drama,
        [Display(Name = "Жахи")]
        Horror,
        [Display(Name = "Наукова фантастика")]
        SciFi,
        [Display(Name = "Романтика")]
        Romance,
        [Display(Name = "Трилер")]
        Thriller,
        [Display(Name = "Документальний")]
        Documentary,
        [Display(Name = "Анімація")]
        Animation,
        [Display(Name = "Фантастика")]
        Fantasy
    }
    public static class GenreExtensions
    {
        public static string DisplayGenre(Genres genre)
        {
            var type = typeof(Genres);
            var memInfo = type.GetMember(genre.ToString());
            var attr = memInfo[0].GetCustomAttribute<DisplayAttribute>();
            return attr?.Name ?? genre.ToString();
        }
    }

}
