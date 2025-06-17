using PractOOP;
using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        MovieManager movieManager = CreateMovieManagerWithInitialMovies();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("МЕНЕДЖЕР ФІЛЬМІВ");
            Console.WriteLine("---------------\n");

            Console.WriteLine("СПИСОК ФІЛЬМІВ:");
            Console.WriteLine("--------------");
            movieManager.DisplayMovies();
            Console.WriteLine();

            ShowMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddMovie(movieManager);
                    break;
                case "2":
                    RemoveMovie(movieManager);
                    break;
                case "3":
                    FilterByGenre(movieManager);
                    break;
                case "4":
                    SearchMovie(movieManager);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine("\nНатисніть Enter для продовження...");
            Console.ReadLine();
        }
    }

    private static MovieManager CreateMovieManagerWithInitialMovies()
    {
        MovieManager manager = new MovieManager(new Movie("Аватар", Genres.SciFi));
        manager.AddMovie(new Movie("Термінатор", Genres.Action));
        manager.AddMovie(new Movie("Титанік", Genres.Drama));
        manager.AddMovie(new Movie("Шрек", Genres.Animation));
        manager.AddMovie(new Movie("Гаррі Поттер", Genres.Fantasy));
        return manager;
    }

    private static void ShowMenu()
    {
        Console.WriteLine("МЕНЮ:");
        Console.WriteLine("1. Додати фільм");
        Console.WriteLine("2. Видалити фільм");
        Console.WriteLine("3. Фільтрувати за жанром");
        Console.WriteLine("4. Пошук фільму за назвою");
        Console.WriteLine("5. Вийти");
        Console.Write("Ваш вибір: ");
    }

    private static void AddMovie(MovieManager manager)
    {
        Console.Clear();
        Console.WriteLine("ДОДАВАННЯ ФІЛЬМУ\n");

        Console.Write("Назва фільму: ");
        string title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Помилка! Назва фільму не може бути порожньою.");
            return;
        }

        Genres genre = SelectGenre("Жанр фільму: ");

        manager.AddMovie(new Movie(title, genre));
        Console.WriteLine("Фільм додано успішно.");

        Console.WriteLine("\nОновлений список фільмів:");
        Console.WriteLine("-----------------------");
        manager.DisplayMovies();
    }

    private static void RemoveMovie(MovieManager manager)
    {
        Console.Clear();
        Console.WriteLine("ВИДАЛЕННЯ ФІЛЬМУ\n");

        Console.WriteLine("Поточний список фільмів:");
        manager.DisplayMovies();
        Console.WriteLine();

        Console.Write("Введіть назву фільму для видалення: ");
        string title = Console.ReadLine();

        manager.RemoveMovieByTitle(title);

        Console.WriteLine("\nОновлений список фільмів:");
        Console.WriteLine("-----------------------");
        manager.DisplayMovies();
    }

    private static void FilterByGenre(MovieManager manager)
    {
        Console.Clear();
        Console.WriteLine("ФІЛЬТРАЦІЯ ЗА ЖАНРОМ\n");

        Genres genre = SelectGenre("Оберіть жанр: ");

        Console.WriteLine($"\nФільми жанру \"{GenreExtensions.DisplayGenre(genre)}\":");
        Console.WriteLine("---------------------------");
        manager.FilterByGenre(genre);
    }

    private static void SearchMovie(MovieManager manager)
    {
        Console.Clear();
        Console.WriteLine("ПОШУК ФІЛЬМУ ЗА НАЗВОЮ\n");

        Console.Write("Введіть назву фільму для пошуку: ");
        string title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Помилка! Назва фільму не може бути порожньою.");
            return;
        }

        Console.WriteLine("\nРезультат пошуку:");
        Console.WriteLine("-----------------");
        manager.FindMovieByTitle(title);
    }

    private static Genres SelectGenre(string prompt)
    {
        Console.WriteLine(prompt);

        var genres = Enum.GetValues(typeof(Genres));
        for (int i = 0; i < genres.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {GenreExtensions.DisplayGenre((Genres)genres.GetValue(i))}");
        }

        Console.Write("\nНомер жанру: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > genres.Length)
        {
            Console.Write($"Введіть число від 1 до {genres.Length}: ");
        }

        return (Genres)genres.GetValue(choice - 1);
    }
}
