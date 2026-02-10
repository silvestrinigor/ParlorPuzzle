using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class ABoxWithAFalseStatementContainsTheGems
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "A box with a false statement contains the gems.";

        protected override string GetInvertedMessage()
            => "A box with a false statement does not contains the gems.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBoxesExcept(BoxOption)
                 .Any(b => b.ContainsGems && !b.Statement!.IsTrue);

        protected override bool VerifyInvertedIfStatementIsTrue()
            => Boxes.GetBoxesExcept(BoxOption)
                 .Any(b => !b.ContainsGems && !b.Statement!.IsTrue);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => [.. Boxes.GetBoxesExcept(BoxOption)];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInvertedInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [];

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInvertedInformedInStatement()
            => [];
    }
}
