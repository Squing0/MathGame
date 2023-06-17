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
            Console.WriteLine("7:  RANDOM MODE");
            Console.WriteLine("8:  QUIT\n");

            if (questionNum > 0)
            {
                Console.Write($"You have {questionNum - 1} questions left!\n");
            }
            int userChoice = 0;
            while (userChoice == 0) {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    if(userChoice < 1 || userChoice > 8) {
                        userChoice = 0;
                        Console.WriteLine("Please enter a number betwen 1 and 8!");
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter a number!");
                }
            }
            

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
                    randomMode();
                    break;
                case 8:
                    timerStop();
                    break;
            }
        }
    }

    private static void NumQuestions()
    {
        if (questionNum == 0)
        {
            while(questionNum == 0) { 
            try
            {
                Console.WriteLine("Please enter how many questions you want to answer.");
                questionNum = Convert.ToInt32(Console.ReadLine()) + 1;
                    if(questionNum < 0)
                    {
                        questionNum = 0;
                        Console.WriteLine("You can't enter a negative number!");
                    }
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a number!");
            }
    }

        }
        else {
            Console.WriteLine("You've already selected your questions!\n");
        }
    }

    private static void Results()
    {
        if(answers.Count == 0)
        {
            Console.WriteLine("You haven't answered any questions yet!\n");
        }
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
            timerStop();
        }

        Random random = new Random();
        int firstNum = 0;
        int secondNum = 0;

        Console.WriteLine("What level of difficulty would you like to select?\n" +
            "1:  EASY\n" +
            "2:  MEDIUM\n" +
            "3:  HARD");

        int difSelection = 0;
        while (difSelection == 0)
        {
            try
            {
                difSelection = Convert.ToInt32(Console.ReadLine());
                if( difSelection < 1 || difSelection > 3)
                {
                    difSelection = 0;
                    Console.WriteLine("Please enter a number between 1 and 3!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number!");
            }
        }

        switch (difSelection)
        {
            case 1:
                firstNum = random.Next(0, 100);
                secondNum = random.Next(0, 100);
                break;
            case 2:
                firstNum = random.Next(200, 500);
                secondNum = random.Next(200, 500);
                break;
            case 3:
                firstNum = random.Next(700, 1000);
                secondNum = random.Next(700, 1000);
                break;
        }


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

        int userAnswer = 0;
        while (userAnswer == 0) 
        {
            try
            {
                userAnswer = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a number!");
            }
        }
        

       

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
    public static void timerStop() {
        Console.WriteLine("\nThank you for playing!");
        stopwatch.Stop();
        Console.WriteLine($"Total time playing: {Math.Round(stopwatch.Elapsed.TotalMinutes)} minutes and {Math.Round(stopwatch.Elapsed.TotalSeconds) - (Math.Round(stopwatch.Elapsed.TotalMinutes) * 60)} seconds!");
        System.Environment.Exit(0);
    }
    public static void randomMode() {
        Random random = new Random();
        int ranNum = random.Next(1, 10);

        for(int i = 0; i < ranNum; i++)
        {
            int ranOperation = random.Next(1,4);
            int firstNum = random.Next(0, 100);
            int secondNum = random.Next(0, 100);
            int ranAnswer = 0;
            string op = "";

            switch (ranOperation)
            {
                case 1:
                    op = "+";
                    ranAnswer = firstNum + secondNum;
                    break;
                case 2:
                    op = "-";
                    ranAnswer = firstNum - secondNum;
                    break;
                case 3:
                    op = "*";
                    ranAnswer = firstNum * secondNum;
                    break;
                case 4:
                    op = "/";
                    ranAnswer = firstNum / secondNum;
                    break;
            }
            string question = $"What is {firstNum} {op} {secondNum}?";
            Console.WriteLine(question);
            int ranUserAnswer = 0;
            while(ranUserAnswer == 0 )
            {
                try
                {
                    ranUserAnswer = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter a number!");
                }
            }
          

            if (ranUserAnswer == ranAnswer)
            {
                Console.WriteLine("Right answer!\n");
                answers.Add("RIGHT");
            }
            else
            {
                Console.WriteLine($"Wrong answer!\nThe answer was {ranAnswer}\n");
                answers.Add("WRONG");
            }
        }
        timerStop();
    }

}