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

        protected override string GetInvertedMessage()
            => $"The statement on the {ParlorPuzzleBoxes.GetBoxName(ChosenBox)} is false.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBox(BoxOption).Statement!.IsTrue;

        protected override bool VerifyInvertedIfStatementIsTrue()
            => !Boxes.GetBox(BoxOption).Statement!.IsTrue;

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInvertedInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInvertedInformedInStatement()
            => [];
    }
}
