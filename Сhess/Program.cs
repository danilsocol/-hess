using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            int select = 1;

            WorkConsole.ReadMenu(select);
            Selection(select);
        }
        static void Selection(int select)
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Enter)
                {

                    Person oneUser = new Person();
                    Person twoUser = new Person();

                    Console.Clear();
                    switch (select)
                    {
                        case 1:
                            CreateUser(oneUser);
                            CreateUser(twoUser);
                            GameActions();
                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:

                            break;
                    }
                    break;
                }
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                    if (select != 1)
                        select -= 1;

                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                    if (select != 4)
                        select += 1;

                Console.Clear();
                WorkConsole.ReadMenu(select);
            }
        }
        public static void CreateUser(Person User)
        {
            do
            {
                User.name = WorkConsole.ReadName();
                Console.Clear();

            } while (User.name.Length == 0);
        }
        public static void GameActions()
        {
            Field field = new Field();
            field.CreateField();

        }
    }
}
