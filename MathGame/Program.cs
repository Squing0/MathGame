using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

internal class Program
{
    static private List<string> answers = new List<string>();
    
    private static void Main(string[] args)
    {          
        while (true)
        {
            Console.WriteLine("Hi, welcome to this simple math game! " +
                "\nPlease choose from one of the 4 options below:");
            Console.WriteLine("1:  ADD");
            Console.WriteLine("2:  SUBTRACT");
            Console.WriteLine("3:  MULTIPLY");
            Console.WriteLine("4:  DIVIDE");
            Console.WriteLine("5:  QUIT");
            Console.WriteLine("5:  SHOW RESULTS\n");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Operation("+");
                    break;
                case 2:
                    Operation("-");
                    break;
                case 3:
                    Operation("*");
                    break;
                case 4:
                    Operation("/");
                    break;
                case 5:
                    Console.WriteLine("\nThank you for playing!");
                    System.Environment.Exit(0);                   
                    break;
                case 6:
                    Results();
                    break;
            }
        }
    }

    private static void Results()
    {
        Console.WriteLine(answers[0]);
    }

    private static void Operation(string op)
    {
        Random random = new Random();
        int firstNum = random.Next(0, 100);
        int secondNum = random.Next(0, 100);
        int answer = 0;

        switch (op)
        {
            case "+":
                answer = firstNum + secondNum;
                break;
            case "-":
                answer = firstNum - secondNum;
                break;
            case "*":
                answer = firstNum - secondNum;
                break;
            case "/":
                answer = firstNum - secondNum;
                break;
        }

        Action<string> question = Console.WriteLine;
        question($"What is {firstNum} {op} {secondNum}?");
        int userAnswer = Convert.ToInt32(Console.ReadLine());

        answers.Add("lol");

        if (userAnswer == answer) {
            Console.WriteLine("Right answer!\n");
        }
        else
        {
            Console.WriteLine($"Wrong answer!\nThe answer was {answer}\n");
        }
        
    }    
}