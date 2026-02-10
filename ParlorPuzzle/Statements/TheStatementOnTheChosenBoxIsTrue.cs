using ParlorPuzzle.Boxes;
using ParlorPuzzle.Enums;

namespace ParlorPuzzle.Statements
{
    sealed class TheStatementOnTheChosenBoxIsTrue
        : ParlorPuzzleStatement
    {
        public required ParlorPuzzleBoxOption ChosenBox { get; set; }

        protected override string GetMessage()
            => $"The statement on the {ParlorPuzzleBoxes.GetBoxName(ChosenBox)} is true.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBox(BoxOption).Statement!.IsTrue;

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [];
    }
}
