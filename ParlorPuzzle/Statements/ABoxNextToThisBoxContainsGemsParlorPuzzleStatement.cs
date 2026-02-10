using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class ABoxNextToThisBoxContainsGemsParlorPuzzleStatement
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "A box next to this box contains gems.";

        protected override string GetInvertedMessage()
            => "A box next to this box does not contains gems.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption)
                 .Any(b => b.ContainsGems);

        protected override bool VerifyInvertedIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption)
            .Any(x => !x.ContainsGems);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => Boxes.GetBoxesNextTo(BoxOption);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInvertedInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInvertedInformedInStatement()
            => Boxes.GetBoxesNextTo(BoxOption);
    }
}
