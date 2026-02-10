using ParlorPuzzle.Statements;

namespace ParlorPuzzle.Boxes
{
    abstract class ParlorPuzzleBox
    {
        public bool ContainsGems
        {
            get;
            set;
        }

        public ParlorPuzzleStatement? Statement
        {
            get;
            set;
        }
    }
}
