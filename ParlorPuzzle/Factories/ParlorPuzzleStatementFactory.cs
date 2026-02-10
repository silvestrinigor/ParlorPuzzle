using ParlorPuzzle.Boxes;
using ParlorPuzzle.Enums;
using ParlorPuzzle.Statements;

namespace ParlorPuzzle.Factories
{
    static class ParlorPuzzleStatementFactory
    {
        private static readonly Func<
            ParlorPuzzleBox, ParlorPuzzleBoxOption, ParlorPuzzleBoxes, ParlorPuzzleStatement
            >[] Factories =
            [
            (box, option, boxes) =>
                new ABoxNextToThisBoxContainsGemsParlorPuzzleStatement
                {
                    Box = box,
                    BoxOption = option,
                    Boxes = boxes
                },

            (box, option, boxes) =>
            {
                var otherBoxes = Enum.GetValues<ParlorPuzzleBoxOption>()
                    .Where(b => b != option)
                    .ToArray();

                return new TheStatementOnTheChosenBoxIsTrue
                {
                    ChosenBox = otherBoxes[Random.Shared.Next(otherBoxes.Length)],
                    Box = box,
                    BoxOption = option,
                    Boxes = boxes
                };
            },

            (box, option, boxes) =>
                new AllBoxesNextToThisBoxContainGemsParlorPuzzleStatement
                {
                    Box = box,
                    BoxOption = option,
                    Boxes = boxes
                },

            (box, option, boxes) =>
                new ABoxWithAFalseStatementContainsTheGems
                {
                    Box = box,
                    BoxOption = option,
                    Boxes = boxes
                },

            (box, option, boxes) =>
                new ABoxWithATrueStatementContainsTheGems
                {
                    Box = box,
                    BoxOption = option,
                    Boxes = boxes
                },

            (box, option, boxes) =>
                new ABoxNextToThisBoxDisplaysATrueStatementParlorPuzzleStatement
                {
                    Box = box,
                    BoxOption = option,
                    Boxes = boxes
                }
        ];

        public static ParlorPuzzleStatement CreateRandom(
                Random rng,
                ParlorPuzzleBox box,
                ParlorPuzzleBoxOption option,
                ParlorPuzzleBoxes boxes)
        {
            var factory = Factories[rng.Next(Factories.Length)];
            return factory(box, option, boxes);
        }
    }
}
