using System;
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new();
        bool exitApp = false;
        do
        {
            menu.ShowMenu();
            string? userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    exitApp = true;
                    break;
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
            }
        }
        while (exitApp == false);
        

    }
}