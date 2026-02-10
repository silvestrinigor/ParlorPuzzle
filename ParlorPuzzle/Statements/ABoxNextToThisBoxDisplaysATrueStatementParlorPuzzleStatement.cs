using ParlorPuzzle.Boxes;

namespace ParlorPuzzle.Statements
{
    sealed class ABoxNextToThisBoxDisplaysATrueStatementParlorPuzzleStatement
        : ParlorPuzzleStatement
    {
        protected override string GetMessage()
            => "A box next to this box displays a true statement.";

        protected override bool VerifyIfStatementIsTrue()
            => Boxes.GetBoxesNextTo(BoxOption)
                 .Any(b => b.Statement?.IsTrue == true);

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement()
            => Boxes.GetAllBoxes();

        protected override IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement()
            => [];
    }
}
