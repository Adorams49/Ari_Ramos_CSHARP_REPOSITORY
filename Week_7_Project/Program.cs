using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "Typing Speed Test";

        while (true)
        {
            Console.Clear();
            ShowTitle("WELCOME TO: TYPING BLAST ⌨️");
            
            Console.WriteLine();
            Console.WriteLine();
            CenteredLine("Let's see how fast you can type");
            Console.WriteLine();

            Thread.Sleep(2000);

            Console.WriteLine();
            ShowSectionTitle("HERE IS YOUR PARAGRAPH");
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(2000);

            string paragraph = GenerateRandomParagraph();
            ShowParagraph(paragraph);
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(2000);

            ShowSectionTitle("YOU START IN");
            Countdown();

            Console.WriteLine();
            Console.WriteLine("Start typing below:");
            Console.WriteLine("--------------------------------------------------");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string userInput = Console.ReadLine();
            stopwatch.Stop();

            Thread.Sleep(2000);
            Console.WriteLine("--------------------------------------------------");

            double timeInSeconds = stopwatch.Elapsed.TotalSeconds;
            int typedWordCount = userInput.Split(' ').Length;
            double wpm = (typedWordCount / timeInSeconds) * 60;
            double accuracy = CalculateAccuracy(paragraph, userInput);

            Console.WriteLine();
            Console.WriteLine();
            ShowSectionTitle("RESULTS");
            ShowResults(timeInSeconds, wpm, accuracy);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Do you want to try again? (Y to retry / any other key to exit)");
            string choice = Console.ReadLine();
            if (choice.Trim().ToUpper() != "Y")
            {
                Console.WriteLine("\nThanks for playing! Press any key to exit...");
                Console.ReadKey();
                break;
            }
        }
    }

    static void ShowTitle(string title)
    {
        Console.Clear();
        int width = Console.WindowWidth;
        string line = new string('-', width).Substring(0, width - 1);
        Console.WriteLine(line);
        CenteredLine(title);
        Console.WriteLine(line);
    }

    static void ShowSectionTitle(string text)
    {
        Console.WriteLine();
        int width = Console.WindowWidth;
        string centered = $" {text} ";
        int padding = (width - centered.Length) / 2;
        string line = new string('-', padding) + centered + new string('-', padding);
        Console.WriteLine(line);
    }

    static void CenteredLine(string text)
    {
        int width = Console.WindowWidth;
        int padding = (width - text.Length) / 2;
        Console.WriteLine(new string(' ', Math.Max(padding, 0)) + text);
    }

    static void ShowParagraph(string paragraph)
    {
        Console.WriteLine(paragraph);
    }

    static void Countdown()
    {
        for (int i = 3; i >= 1; i--)
        {
            Console.WriteLine($"         {i}");
            Thread.Sleep(1000);
        }
    }

    static string GenerateRandomParagraph()
    {
        string[] sentences = new[]
        {
            "Typing is a skill worth improving.",
            "Stay focused and breathe evenly.",
            "Let your fingers find the rhythm.",
            "Start slow and build confidence.",
            "Practice daily to see results.",
            "Avoid distractions while typing.",
            "Speed comes from accuracy.",
            "Relax your shoulders and hands.",
            "Don't watch your fingers.",
            "Typing should feel natural."
        };

        Random rnd = new Random();
        return string.Join(" ", sentences.OrderBy(x => rnd.Next()).Take(3));
    }

    static double CalculateAccuracy(string original, string typed)
    {
        string[] originalWords = original.Split(' ');
        string[] typedWords = typed.Split(' ');

        int correct = 0;
        for (int i = 0; i < Math.Min(originalWords.Length, typedWords.Length); i++)
        {
            if (originalWords[i].Equals(typedWords[i], StringComparison.OrdinalIgnoreCase))
            {
                correct++;
            }
        }

        return ((double)correct / originalWords.Length) * 100;
    }

    static void ShowResults(double seconds, double wpm, double accuracy)
    {
        Console.ResetColor();
        Console.WriteLine($"Time Taken: {seconds:F2} seconds");

        Console.ForegroundColor = GetColorForWPM(wpm);
        Console.WriteLine($"Words Per Minute (WPM): {wpm:F1}");
        ExplainWPM(wpm);
        Console.ResetColor();

        Console.ForegroundColor = GetColorForAccuracy(accuracy);
        Console.WriteLine($"Accuracy: {accuracy:F1}%");
        ExplainAccuracy(accuracy);
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("Color Explanation:");
        Console.WriteLine("🟥 Red = Needs improvement");
        Console.WriteLine("🟨 Yellow = Decent but room to improve");
        Console.WriteLine("🟩 Green = Great job!");
    }

    static ConsoleColor GetColorForWPM(double wpm)
    {
        if (wpm >= 60) return ConsoleColor.Green;
        if (wpm >= 40) return ConsoleColor.Yellow;
        return ConsoleColor.Red;
    }

    static ConsoleColor GetColorForAccuracy(double acc)
    {
        if (acc >= 90) return ConsoleColor.Green;
        if (acc >= 70) return ConsoleColor.Yellow;
        return ConsoleColor.Red;
    }

    static void ExplainWPM(double wpm)
    {
        if (wpm >= 60)
            Console.WriteLine("→ Excellent speed! YoU type like a pro.");
        else if (wpm >= 40)
            Console.WriteLine("→ Good speed! You’re above average.");
        else
            Console.WriteLine("→ Keep practicing! Improve your typing speed.");
    }

    static void ExplainAccuracy(double acc)
    {
        if (acc >= 90)
            Console.WriteLine("→ Great accuracy! Very few mistakes.");
        else if (acc >= 70)
            Console.WriteLine("→ Decent accuracy! There's room for improvement.");
        else
            Console.WriteLine("→ Accuracy is low! Focus on typing carefully.");
    }
}