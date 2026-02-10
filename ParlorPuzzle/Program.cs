using ParlorPuzzle.Enums;
using ParlorPuzzle.Games;

namespace ParlorPuzzle
{
    class Program
    {
        static void Main()
        {
            var generator = new ParlorPuzzleGenerator();

            while (true)
            {
                var game = generator.Generate();

                Console.WriteLine("""
                        There will always be at least one box which displays only true statements.
                        There will always be at least one box which displays only false statements.
                        Only one box has a prize within. The other 2 are always empty.
                        """);

                Console.WriteLine();

                Console.WriteLine($"Blue box:  {game.GetBoxStatementMessage(ParlorPuzzleBoxOption.BlueBox)}");
                Console.WriteLine($"White box: {game.GetBoxStatementMessage(ParlorPuzzleBoxOption.WhiteBox)}");
                Console.WriteLine($"Black box: {game.GetBoxStatementMessage(ParlorPuzzleBoxOption.BlackBox)}");

                Console.WriteLine("🟦 ⬜ ⬛");

                Console.WriteLine("Choose a box to open:");
                Console.WriteLine("1 - Blue");
                Console.WriteLine("2 - White");
                Console.WriteLine("3 - Black");
                Console.WriteLine("Q - Quit");

                var input = Console.ReadLine();

                if (string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase))
                    break;

                var choice = input switch
                {
                    "1" => ParlorPuzzleBoxOption.BlueBox,
                    "2" => ParlorPuzzleBoxOption.WhiteBox,
                    "3" => ParlorPuzzleBoxOption.BlackBox,
                    _ => throw new InvalidOperationException("Invalid choice")
                };

                Console.WriteLine();
                Console.WriteLine(
                    game.OpenOneBox(choice)
                        ? "🎉 The box contains gems!"
                        : "❌ The box is empty."
                );

                Console.WriteLine();
                Console.Write("Play again? (Y/N): ");
                var again = Console.ReadLine();

                if (!string.Equals(again, "Y", StringComparison.OrdinalIgnoreCase))
                    break;
            }
        }
    }
}
