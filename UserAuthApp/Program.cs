using UserAuthApp.Models;

namespace UserAuthApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Вход");
                Console.WriteLine("2. Регистрация");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Login();
                }
                else if (choice == "2")
                {
                    Register();
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }
            }

            void Login()
            {
                Console.Clear();
                Console.Write("Имя пользователя: ");
                string username = Console.ReadLine()!;
                Console.Write("Пароль: ");
                string password = Console.ReadLine()!;

                using (var db = new AppDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == username);

                    if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
                    {
                        Console.WriteLine("Неверное имя пользователя или пароль.");
                        return;
                    }

                    Console.WriteLine("Успешный вход!");
                    MainMenu();
                }
            }

            void Register()
            {
                Console.Clear();
                Console.Write("Введите имя пользователя: ");
                string username = Console.ReadLine()!;
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine()!;

                using (var db = new AppDbContext())
                {
                    if (db.Users.Any(u => u.Username == username))
                    {
                        Console.WriteLine("Пользователь с таким именем уже существует.");
                        return;
                    }

                    var user = new User
                    {
                        Username = username,
                        PasswordHash = PasswordHasher.HashPassword(password)
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                    Console.WriteLine("Регистрация успешна!");
                    MainMenu();
                }
            }

            void MainMenu()
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в главное меню!");
                Console.WriteLine("1. Выйти");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Выход...");
                    Environment.Exit(0);
                }
            }

        }
    }
}
