using System.Text.RegularExpressions;

namespace AdventureGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            string name = GetUserInput("What is your name? ");

            Console.WriteLine($"Hello, {name}! Welcome to our story.");

            Console.WriteLine("It begins on a cold rainy night. You're sitting in your room and hear a noise coming from down the hall. Do you go investigate?");

            string? noiseChoice = GetValidChoice($"Type YES or NO: ", "YES", "NO");

            if (noiseChoice == "NO")
            {
                Console.WriteLine("Not much of an adventure if we don't leave our room!");
                Console.WriteLine("THE END.");
            }
            else if (noiseChoice == "YES")
            {
                Console.WriteLine("You walk into the hallway and see a light coming from under a door down the hall.");
                Console.WriteLine("You walk towards it. Do you open it or knock?");

                string? doorChoice = GetValidChoice("Type OPEN or KNOCK: ", "OPEN", "KNOCK");

                if (doorChoice == "KNOCK")
                {
                    ManageKnock();
                }
                else if (doorChoice == "OPEN")
                {
                    ManageOpen();
                }
            }
        }

        static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string? userInput = Console.ReadLine()?.Trim();

            // Validate input
            while (string.IsNullOrEmpty(userInput) || !IsAlphabetic(userInput))
            {
                Console.Write($"Invalid input. Please enter alphabetic characters only.\n{prompt}");
                userInput = Console.ReadLine()?.Trim();
            }

            return userInput;
        }
        static string GetValidChoice(string prompt, string option1, string option2)
        {
            Console.Write(prompt);

            while (true)
            {
                string? choice = Console.ReadLine()?.ToUpper()?.Trim();

                if (!string.IsNullOrEmpty(choice) && (choice == option1 || choice == option2))
                {
                    return choice;
                }

                Console.Write("Invalid choice. Please enter either " + option1 + " or " + option2 + ": ");
            }
        }

        static string GetValidChoice(string prompt, params string[] validOptions)
        {
            Console.Write(prompt);

            while (true)
            {
                string? choice = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(choice) && validOptions.Contains(choice))
                {
                    return choice;
                }

                Console.Write("Invalid choice. Please enter a number between 1-3: ");
            }
        }

        static bool IsAlphabetic(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z ]+$");
        }
        static void ManageKnock()
        {
            Console.WriteLine("A voice behind the door speaks. It says, \"Answer this riddle: \"");
            Console.WriteLine("\"Poor people have it. Rich people need it. If you eat it you die. What is it?\"");
            string? riddleAnswer = GetUserInput("Type your answer:");

            if (riddleAnswer == "NOTHING")
            {
                Console.WriteLine("The door opens and NOTHING is there.");
                Console.WriteLine("You turn off the light and run back to your room and lock the door.");
                Console.WriteLine("THE END.");
            }
            else
            {
                Console.WriteLine("You answered incorrectly. The door doesn't open.");
                Console.WriteLine("THE END.");
            }
        }
        static void ManageOpen()
        {
            Console.WriteLine("The door is locked! See if one of your three keys will open it.");
            string keyChoice = GetValidChoice("Enter a number (1-3): ", "1", "2", "3");

            switch (keyChoice)
            {
                case "1":
                    Console.WriteLine("You choose the first key. Lucky choice!");
                    Console.WriteLine("The door opens and NOTHING is there. Strange...");
                    Console.WriteLine("THE END.");
                    break;
                case "2":
                    Console.WriteLine("You choose the second key. The door doesn't open.");
                    Console.WriteLine("THE END.");
                    break;
                case "3":
                    Console.WriteLine("You choose the third key. The door doesn't open.");
                    Console.WriteLine("THE END.");
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
            }
        }
    }

}