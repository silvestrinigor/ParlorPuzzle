using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class ABoxWithAFalseStatementContainsTheGems
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "A box with a false statement contains the gems.";

        protected override bool VerifyIfStatementIsTrue()
        {
            if (Boxes.GetBox(BoxOption).ContainsGems)
                return false;

            return Boxes.GetBoxesExcept(BoxOption)
                 .Any(b => b.ContainsGems && !b.Statement!.IsTrue);
        }

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => Boxes.GetBoxesExcept(BoxOption);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [Boxes.GetBox(BoxOption)];
    }
}
