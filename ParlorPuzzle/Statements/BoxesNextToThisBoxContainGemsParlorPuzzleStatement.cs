using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class BoxesNextToThisBoxContainGemsParlorPuzzleStatement
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "All boxes next to this box contain gems.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption).Count
            == Boxes.GetBoxesNextTo(BoxOption).Count(x => x.ContainsGems);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => Boxes.GetBoxesNextTo(BoxOption);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [];
    }
}
