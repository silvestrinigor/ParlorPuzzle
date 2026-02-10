using ParlorPuzzle.Enums;

namespace ParlorPuzzle.Boxes
{
    sealed record ParlorPuzzleBoxes(
        ParlorPuzzleBlueBox BlueBox,
        ParlorPuzzleWhiteBox WhiteBox,
        ParlorPuzzleBlackBox BlackBox
    )
    {
        public IReadOnlyCollection<ParlorPuzzleBox> GetBoxesNextTo(ParlorPuzzleBoxOption option)
        {
            return option switch
            {
                ParlorPuzzleBoxOption.BlueBox => [WhiteBox],
                ParlorPuzzleBoxOption.WhiteBox => [BlueBox, BlackBox],
                ParlorPuzzleBoxOption.BlackBox => [WhiteBox],
                _ => throw new ArgumentOutOfRangeException(nameof(option))
            };
        }

        public IReadOnlyCollection<ParlorPuzzleBox> GetBoxesNotNextTo(ParlorPuzzleBoxOption option)
        {
            return option switch
            {
                ParlorPuzzleBoxOption.BlueBox => [BlackBox],
                ParlorPuzzleBoxOption.WhiteBox => [],
                ParlorPuzzleBoxOption.BlackBox => [BlueBox],
                _ => throw new ArgumentOutOfRangeException(nameof(option))
            };
        }

        public IReadOnlyCollection<ParlorPuzzleBox> GetBoxesExcept(ParlorPuzzleBoxOption option)
        {
            return option switch
            {
                ParlorPuzzleBoxOption.BlueBox => [WhiteBox, BlackBox],
                ParlorPuzzleBoxOption.WhiteBox => [BlueBox, BlackBox],
                ParlorPuzzleBoxOption.BlackBox => [WhiteBox, BlueBox],
                _ => throw new ArgumentOutOfRangeException(nameof(option))
            };
        }

        public ParlorPuzzleBox GetBox(ParlorPuzzleBoxOption option)
        {
            return option switch
            {
                ParlorPuzzleBoxOption.BlueBox => BlueBox,
                ParlorPuzzleBoxOption.WhiteBox => WhiteBox,
                ParlorPuzzleBoxOption.BlackBox => BlackBox,
                _ => throw new ArgumentOutOfRangeException(nameof(option))
            };
        }

        public static string GetBoxName(ParlorPuzzleBoxOption option)
        {
            return option switch
            {
                ParlorPuzzleBoxOption.BlueBox => "blue box",
                ParlorPuzzleBoxOption.WhiteBox => "white box",
                ParlorPuzzleBoxOption.BlackBox => "black box",
                _ => throw new ArgumentOutOfRangeException(nameof(option))
            };
        }
    }
}
