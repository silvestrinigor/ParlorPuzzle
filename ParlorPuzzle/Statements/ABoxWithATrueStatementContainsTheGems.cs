using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class ABoxWhitATrueStatementContainsTheGems
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "A box with a true statement contains the gems.";

        protected override string GetInvertedMessage()
            => "A box with a true statement does not contains the gems.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption)
                 .Any(b => b.ContainsGems && b.Statement!.IsTrue);

        protected override bool VerifyInvertedIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption)
                 .Any(b => !b.ContainsGems && b.Statement!.IsTrue);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => [.. Boxes.GetBoxesNextTo(BoxOption)];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInvertedInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInvertedInformedInStatement()
            => [];
    }
}
