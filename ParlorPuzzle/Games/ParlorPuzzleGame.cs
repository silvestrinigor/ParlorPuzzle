using ParlorPuzzle.Boxes;
using ParlorPuzzle.Enums;

namespace ParlorPuzzle.Games
{
    sealed class ParlorPuzzleGame(ParlorPuzzleBoxes boxes)
    {
        private readonly ParlorPuzzleBoxes boxes = boxes;

        public bool OpenOneBox(ParlorPuzzleBoxOption option)
        {
            return option switch
            {
                ParlorPuzzleBoxOption.BlueBox => boxes.BlueBox.ContainsGems,
                ParlorPuzzleBoxOption.WhiteBox => boxes.WhiteBox.ContainsGems,
                ParlorPuzzleBoxOption.BlackBox => boxes.BlackBox.ContainsGems,
                _ => throw new ArgumentOutOfRangeException(nameof(option))
            };
        }

        public string GetBoxStatementMessage(ParlorPuzzleBoxOption option)
        {
            return option switch
            {
                ParlorPuzzleBoxOption.BlueBox => boxes.BlueBox.Statement!.Message,
                ParlorPuzzleBoxOption.WhiteBox => boxes.WhiteBox.Statement!.Message,
                ParlorPuzzleBoxOption.BlackBox => boxes.BlackBox.Statement!.Message,
                _ => throw new ArgumentOutOfRangeException(nameof(option))
            };
        }
    }
}
