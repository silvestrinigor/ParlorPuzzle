using ParlorPuzzle.Boxes;
using ParlorPuzzle.Enums;
using ParlorPuzzle.Factories;
using ParlorPuzzle.Statements;

namespace ParlorPuzzle.Games
{
    sealed class ParlorPuzzleGenerator
    {
        private readonly Random rng = new();

        public ParlorPuzzleGame Generate()
        {
            for (int attempt = 0; attempt < 100_000; attempt++)
            {
                var game = TryGenerate();

                if (game != null)
                    return game;
            }

            throw new InvalidOperationException("Failed to generate valid puzzle.");
        }

        private ParlorPuzzleGame? TryGenerate()
        {
            // 1. Create boxes
            var blue = new ParlorPuzzleBlueBox();
            var white = new ParlorPuzzleWhiteBox();
            var black = new ParlorPuzzleBlackBox();

            var boxes = new ParlorPuzzleBoxes(blue, white, black);

            // 2. Assign gems (exactly one)
            var gemIndex = rng.Next(3);
            blue.ContainsGems = gemIndex == 0;
            white.ContainsGems = gemIndex == 1;
            black.ContainsGems = gemIndex == 2;

            // 3. Create random statements
            var blueStmt = ParlorPuzzleStatementFactory.CreateRandom(
                    rng,
                    blue,
                    ParlorPuzzleBoxOption.BlueBox,
                    boxes
                    );

            var whiteStmt = ParlorPuzzleStatementFactory.CreateRandom(
                    rng,
                    white,
                    ParlorPuzzleBoxOption.WhiteBox,
                    boxes
                    );

            var blackStmt = ParlorPuzzleStatementFactory.CreateRandom(
                    rng,
                    black,
                    ParlorPuzzleBoxOption.BlackBox,
                    boxes
                    );

            // 4. Wire statements
            Wire(blueStmt, blue, ParlorPuzzleBoxOption.BlueBox, boxes);
            Wire(whiteStmt, white, ParlorPuzzleBoxOption.WhiteBox, boxes);
            Wire(blackStmt, black, ParlorPuzzleBoxOption.BlackBox, boxes);

            blue.Statement = blueStmt;
            white.Statement = whiteStmt;
            black.Statement = blackStmt;

            // 5. Validate rules
            var truths = new[]
            {
                blueStmt.IsTrue,
                whiteStmt.IsTrue,
                blackStmt.IsTrue
            };

            if (truths.All(t => t) || truths.All(t => !t))
                return null;

            var trueStatements = new[] { blueStmt, whiteStmt, blackStmt }
            .Where(s => s.IsTrue)
                .ToList();

            var notPossibleLocations = trueStatements
                .SelectMany(s => s.NotPossibleGemsLocationsInformedInStatement)
                .Distinct()
                .ToHashSet();

            var possibleLocations = trueStatements
                .SelectMany(s => s.PossibleGemsLocationsInformedInStatement)
                .Distinct()
                .Where(loc => !notPossibleLocations.Contains(loc))
                .ToList();

            // Must deduce exactly one solution
            if (possibleLocations.Count != 1)
                return null;

            return new ParlorPuzzleGame(boxes);
        }

        private static void Wire(
                ParlorPuzzleStatement stmt,
                ParlorPuzzleBox box,
                ParlorPuzzleBoxOption option,
                ParlorPuzzleBoxes boxes)
        {
            stmt.Box = box;
            stmt.BoxOption = option;
            stmt.Boxes = boxes;
        }
    }
}
