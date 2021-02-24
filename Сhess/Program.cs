using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuSelect = 1;

            WorkConsole.ReadMenu(menuSelect);
            Selection(menuSelect);
        }
        static void Selection(int selectCell)
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Enter)
                {

                    Person oneUser = new Person();
                    Person twoUser = new Person();

                    Console.Clear();
                    switch (selectCell)
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
                    if (selectCell != 1)
                        selectCell -= 1;

                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                    if (selectCell != 4)
                        selectCell += 1;

                Console.Clear();
                WorkConsole.ReadMenu(selectCell);
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
