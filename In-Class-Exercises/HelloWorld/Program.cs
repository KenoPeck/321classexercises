using System;
using HelloWorldMath;   using HelloWorldMsg;    using HelloWorldLL;


namespace consApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitApp = false;
            do
            {
                ShowMenu();
                string? userInput = Console.ReadLine();
                Console.WriteLine();
                switch (userInput)
                {
                    case "0":
                        exitApp = true;
                        break;
                    case "1":
                        Console.WriteLine("Pass by value and pass by reference example:\n");
                        PassByValuePassByReference();
                        break;
                    case "2":
                        BasicMessageClass basicMessage = new BasicMessageClass("Hello World!");
                        basicMessage.ShowMessage();
                        break;
                    case "3":
                        Console.WriteLine("Writing \"Hello World!\" to file ./output.txt...\n\n");
                        writeToFile();
                        break;
                    case "4":
                        Console.WriteLine("Enter two numbers to be added in a linked list:\n");
                        Console.WriteLine("Enter first number:");
                        string input1 = Console.ReadLine();
                        if (string.IsNullOrEmpty(input1))
                        {
                            Console.WriteLine("Invalid input");
                            do
                            {
                                Console.WriteLine("Enter first number:");
                                input1 = Console.ReadLine();
                            }
                            while (!string.IsNullOrEmpty(input1));
                        }
                        int num1 = int.Parse(input1);
                        Console.WriteLine("Enter second number:");
                        string input2 = Console.ReadLine();
                        if (string.IsNullOrEmpty(input2))
                        {
                            do
                            {
                                Console.WriteLine("Enter second number:");
                                input2 = Console.ReadLine();
                            }
                            while (!string.IsNullOrEmpty(input2));
                        }
                        int num2 = int.Parse(input2);
                        Console.WriteLine($"Adding {num1} and {num2} in a linked list...\n");
                        LinkedList list = new LinkedList();
                        break;
                    default:
                        Console.WriteLine("\aInvalid input\n");
                        break;
                }
            }
            while (exitApp == false);


        }
        static void ShowMenu()
        {
            Console.WriteLine("C# Demos");
            Console.WriteLine("1: Show the pass by reference and pass by value scenario");
            Console.WriteLine("2: Show Hello World on the screen");
            Console.WriteLine("3: Write Hello World in a file");
            Console.WriteLine("4: Adding two numbers in a linked list");
            Console.WriteLine("0: Quit");
        }

        static void PassByValuePassByReference()
        {
            AngleClass aC1 = new AngleClass(); // declaring AngleClass1
            aC1.AngleDegrees = 45;  // setting AngleClass1 to 45 degrees
            Console.WriteLine($"AngleClass1.AngleDegrees = {aC1.AngleDegrees}");

            AngleClass aC2 = aC1;   // assigning AngleClass2 to AngleClass1
            Console.WriteLine($"AngleClass2 = AngleClass1");

            aC2.AngleDegrees = 90;  // setting AngleClass2 to 90 degrees
            Console.WriteLine($"AngleClass2.AngleDegrees = {aC2.AngleDegrees}");
            Console.WriteLine($"AngleClass1.AngleDegrees = {aC1.AngleDegrees}");


            AngleStruct aS1 = new AngleStruct(); // declaring AngleStruct1
            aS1.AngleDegrees = 45;  // setting AngleStruct1 to 45 degrees
            Console.WriteLine($"AngleStruct1 = {aS1.AngleDegrees}");

            AngleStruct aS2 = aS1; // assigning AngleStruct2 to AngleStruct1
            Console.WriteLine($"AngleStruct2 = AngleStruct1");

            aS2.AngleDegrees = 90;  // setting AngleStruct2 to 90 degrees
            Console.WriteLine($"AngleStruct2.AngleDegrees = {aS2.AngleDegrees}");
            Console.WriteLine($"AngleStruct1.AngleDegrees = {aS1.AngleDegrees}\n\n");

        }

        static void writeToFile()
        {
            BasicMessageClass basicMessage = new BasicMessageClass("Hello World!");
            //FileStream stream = new("./output.txt", FileMode.Create);
            //System.IO.StreamWriter sWriter = new(stream);
            //sWriter.WriteLine($"{basicMessage.Message}");
            //sWriter.Dispose();

            using (System.IO.StreamWriter sWriter2 = new("./output.txt"))
            {
                Console.SetOut(sWriter2);
                basicMessage.ShowMessage();
                Console.SetOut(Console.Out);
            }

        }
    }
}