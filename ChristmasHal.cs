using System.Threading;

public class ChristmasHunt
{
    public void BeginTreasureHunt()
    {
        // Intro
        Console.Clear();
        Console.WriteLine("Gollum lived on a slimy island of rock in the middle of the lake. He was watching Bilbo now from the distance with his pale eyes like telescopes. Bilbo could not see him, but he was wondering a lot about Bilbo, for he could see that he was no goblin at all.");
        Console.WriteLine("(Press enter)");
        Console.ReadLine();
        Console.WriteLine("Gollum got into his boat and shot off from the island, while Bilbo was sitting on the brink altogether flummoxed and at the end of his way and his wits. Suddenly up came Gollum and whispered and hissed:");
        Console.ReadLine();

        WriteLineGolumn("Praps ye sits here and chats with it a bitsy, my preciousss. It likes riddles, praps it does, does it?");
        Console.ReadLine();

        WriteBilbo("'Very well, '");
        Console.Write(" said Bilbo, who was anxious to agree, until he found out more about the creature, whether he was quite alone, whether he was fierce or hungry, and whether he was a friend of the goblins.");
        WriteBilbo("'You ask first.' ");
        Console.WriteLine("he said, becuase he did not have time to think of a riddle.");
        Console.ReadLine();

        // Riddle 1 (Golumn)
        // "\n" = new line
        Console.WriteLine("So Golumn hissed..");
        WriteLineGolumn("   There is one that is called Smaug \n   With scales colored red. \n   Another sits on a shelf \n   At the foot of your bed.");
        GetAnswer("dragon", "", "Now go find the dragon and bring back the key.");
        GetKey("smaug");

        // Riddle 2 (Bilbo)
        Console.WriteLine();
        Console.WriteLine("Unfortunately for Gollum Bilbo had heard that sort of thing before; and the answer was all round him any way.He said without even scratching his head or putting on his thinking cap.");
        WriteLineBilbo("   A box without hinges, key or lid, \n   Yet golden treasure inside is hid.");
        GetAnswer(
            "egg",
            "Gollum remembered thieving from nests long ago, and sitting under the river bank teaching his grandmother, teaching his grandmother to suck..",
            "Now go look where they are hid."
        );
        GetKey("gold", "Did you look where they are hid?");

        // Riddle 4 (Golumn)
        Console.WriteLine();
        Console.WriteLine("Golumn he thought the time had come to ask something hard and horrible. This is what he said:");
        WriteLineGolumn("   This thing all things devours: \n   Birds, beasts, trees, flowers; \n   Gnaws iron, bites steel; \n   Grinds hard stones to meal: "
            + "\n   Slays kings, ruins town, \n   And beats high mountain down.");
        GetAnswer(
            "time",
            "His tongue seemed to stick in his mouth; he wanted to shout out: 'Give me more time! Give me time!' But all that came out with a sudden squeal was:",
            "Look downstairs only"
        );
        GetKey("clock", "Look for something that measures it.");

        // Riddle 3 (Bilbo)
        Console.WriteLine();
        Console.WriteLine("Bilbo, nearly bursting his brain to think of riddles that could save him from being eaten said:");
        WriteLineBilbo("   Thirty white horses on a red hill, \n   First, they chomp, \n   Then they stamp, \n   Then they stand still.");
        GetAnswer("teeth", "How you eat.", "Go look where you clean your teeth");
        GetKey("brush");

        // Riddle 5 (Golumn)
        Console.WriteLine();
        Console.WriteLine("These ordinary everyday sort of riddles were tiring for him. "
            + "Also they reminded him of days when he had been less lonely and sneaky and nasty, and that put him out of temper. "
            + "What is more they made him hungry; so this time he tried something a bit more difficult and more unpleasant:");
        WriteLineGolumn("   It cannot be seen, cannot be felt, \n   Cannot be heard, cannot be smelt, \n   It lies behind stars and under hill, \n"
            + "   And empty holes it fills. \n   It comes first and follows after, \n   Ends life, kills laughter.");
        GetAnswer(
            "dark"
        );

        Console.WriteLine();
        WriteGolumn("Thief, thief, thief! ");
        Console.Write("Cried Golumn. ");
        WriteLineGolumn("'Baggins! We hates it, we hates it, we hates it for ever!'");

        Thread.Sleep(1000);

        Console.WriteLine();
        Console.WriteLine("Look in a dark place to find your precious!");

        Console.ReadLine();
    }

    private void WriteLineGolumn(string quote)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(quote);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void WriteGolumn(string quote)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(quote);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void WriteLineBilbo(string quote)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(quote);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void WriteBilbo(string quote)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(quote);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Ask question and wait for correct answer.  Provide a hint if supplies. 
    /// </summary>
    /// <param name="correctAnswer"></param>
    /// <param name="hint"></param>
    /// <returns></returns>
    private bool GetAnswer(string correctAnswer, string hint = "", string answerLocation = "")
    {
        int tryCount = 0;

        do
        {
            tryCount++;

            // Read answer
            Console.Write("enter answer > ");
            string response = Console.ReadLine() ?? "";

            // Does answer == correct answer? 
            if (string.Equals(response.Trim(), correctAnswer, StringComparison.CurrentCultureIgnoreCase))
            {
                // Correct answer was give, display answer location and exit;
                if (string.IsNullOrWhiteSpace(answerLocation) == false)
                {
                    Console.WriteLine(answerLocation);
                }
                return true;
            }

            if (tryCount > 4)
            {
                return false;
            }

            // Wrong answer.  Print random Golumn scary quote
            Random random = new Random();
            int rInt = random.Next(0, 5);
            WriteLineGolumn(Quotes.Golumn[rInt]);

            if (tryCount > 1 && string.IsNullOrEmpty(hint) == false)
            {
                // Print hint if tried more than once.
                Console.WriteLine(hint);
            }
        }
        while (tryCount < 4);

        return false;
    }

    /// <summary>
    /// Get key and check if correct answer.  Display hint
    /// </summary>
    /// <param name="correctAnswer"></param>
    /// <param name="hint"></param>
    /// <returns></returns>
    private bool GetKey(string correctAnswer, string hint = "Please try again.")
    {
        int tryCount = 0;
        do
        {
            tryCount++;

            // Read answer
            Console.Write("enter key > ");
            string? response = Console.ReadLine();

            // Does answer == correct answer? Exit with true.
            if (string.Equals(response, correctAnswer, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            if (tryCount > 3)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(hint) == false)
            {
                Console.WriteLine(hint);
            }
        }
        while (true);
    }
}
