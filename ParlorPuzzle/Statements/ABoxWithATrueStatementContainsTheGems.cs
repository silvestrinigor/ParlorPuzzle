using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class ABoxWithATrueStatementContainsTheGems
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "A box with a true statement contains the gems.";

        protected override string GetInvertedMessage()
            => "A box with a true statement does not contains the gems.";

        protected override bool VerifyIfStatementIsTrue()
        {
            if (Boxes.GetBox(BoxOption).ContainsGems)
                return true;

            return Boxes.GetBoxesExcept(BoxOption)
                 .Any(b => b.ContainsGems && b.Statement!.IsTrue);
        }


        protected override bool VerifyInvertedIfStatementIsTrue()
        {
            if (!Boxes.GetBox(BoxOption).ContainsGems)
                return true;

            return Boxes.GetBoxesExcept(BoxOption)
                 .Any(b => !b.ContainsGems && b.Statement!.IsTrue);
        }

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
