using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

internal class Program
{
    static private List<string> answers = new List<string>();
    static private int questionNum = 0;
    static private Stopwatch stopwatch = new Stopwatch();
    
    private static void Main(string[] args)
    {          
        while (true)
        {
            stopwatch.Start();
            Console.WriteLine("Hi, welcome to this simple math game! " +
                "\nPlease choose from one of the 4 options below:");
            Console.WriteLine("1:  ADD");
            Console.WriteLine("2:  SUBTRACT");
            Console.WriteLine("3:  MULTIPLY");
            Console.WriteLine("4:  DIVIDE");           
            Console.WriteLine("5:  SHOW RESULTS");
            Console.WriteLine("6:  NUMBER OF QUESTIONS");
            Console.WriteLine("7:  QUIT\n");

            if(questionNum > 0)
            {
                Console.Write($"You have {questionNum - 1} questions left!\n");
            }

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
                    Results();
                    break;
                case 6:
                    NumQuestions();
                    break;
                case 7:
                    Console.WriteLine("\nThank you for playing!");
                    stopwatch.Stop();
                    Console.WriteLine($"Total time playing: {Math.Round(stopwatch.Elapsed.TotalMinutes)} minutes and {Math.Round(stopwatch.Elapsed.TotalSeconds)} seconds!");
                    System.Environment.Exit(0);
                    break;
            }
        }
    }

    private static void NumQuestions()
    {
        if (questionNum == 0)
        {
            Console.WriteLine("Please enter how many questions you want to answer.");
            questionNum = Convert.ToInt32(Console.ReadLine()) + 1;
            Console.WriteLine("");
        }
        else {
            Console.WriteLine("You've already selected your questions!\n");
        }
    }

    private static void Results()
    {
        for(int i = 0; i < answers.Count; i++)
        {
            Console.WriteLine($"\n{answers[i]} {answers[i + 1]}\n");
            i++;
        }
        
    }

    private static void Operation(string op)
    {
        questionNum -= 1;
        if (questionNum == 0)
        {
            Console.WriteLine("\nThank you for playing!");
            stopwatch.Stop();
            Console.WriteLine($"Total time playing: {Math.Round(stopwatch.Elapsed.TotalMinutes)} minutes and {Math.Round(stopwatch.Elapsed.TotalSeconds)} seconds!");
            System.Environment.Exit(0);

        }


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
                answer = firstNum * secondNum;
                break;
            case "/":
                answer = firstNum / secondNum;
                break;
        }

        string question = $"What is {firstNum} {op} {secondNum}?";
        Console.WriteLine(question);
        int userAnswer = Convert.ToInt32(Console.ReadLine());

        answers.Add(question);

        if (userAnswer == answer) {
            Console.WriteLine("Right answer!\n");
            answers.Add("RIGHT");
        }
        else
        {
            Console.WriteLine($"Wrong answer!\nThe answer was {answer}\n");
            answers.Add("WRONG");
        }


        
    }    
}