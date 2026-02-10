using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class BoxesNextToThisBoxContainGemsParlorPuzzleStatement
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "All boxes next to this box contain gems.";

        protected override string GetInvertedMessage()
            => "All boxes next to this box does not contain gems.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption).Count
            == Boxes.GetBoxesNextTo(BoxOption).Count(x => x.ContainsGems);

        protected override bool VerifyInvertedIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption).Count
            == Boxes.GetBoxesNextTo(BoxOption).Count(x => !x.ContainsGems);

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
