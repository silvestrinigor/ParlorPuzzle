using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class ABoxNextToThisBoxContainsGemsParlorPuzzleStatement
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "A box next to this box contains gems.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption)
                 .Any(b => b.ContainsGems);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => Boxes.GetBoxesNextTo(BoxOption);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => Boxes.GetBoxesNotNextTo(BoxOption);
    }
}
