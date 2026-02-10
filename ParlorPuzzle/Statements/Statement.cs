using ParlorPuzzle.Boxes;
using ParlorPuzzle.Enums;

namespace ParlorPuzzle.Statements
{
    abstract class ParlorPuzzleStatement
    {
        private bool? _cachedIsTrue;
        private bool _isEvaluating;

        public string Message
            => IsInverted
            ? GetInvertedMessage()
            : GetMessage();

        protected abstract string GetMessage();
        protected abstract string GetInvertedMessage();

        public bool IsTrue
        {
            get
            {
                if (_cachedIsTrue.HasValue)
                    return _cachedIsTrue.Value;

                if (_isEvaluating)
                    return false; // breaks circular truth dependency safely

                _isEvaluating = true;

                var value = IsInverted
                    ? VerifyInvertedIfStatementIsTrue()
                    : VerifyIfStatementIsTrue();

                _cachedIsTrue = value;
                _isEvaluating = false;

                return value;
            }
        }

        protected abstract bool VerifyIfStatementIsTrue();
        protected abstract bool VerifyInvertedIfStatementIsTrue();

        public bool IsInverted { get; set; }

        public required ParlorPuzzleBox Box { get; set; }
        public required ParlorPuzzleBoxOption BoxOption { get; set; }
        public required ParlorPuzzleBoxes Boxes { get; set; }

        private IReadOnlyCollection<ParlorPuzzleBox>? _cachedPossible;
        private IReadOnlyCollection<ParlorPuzzleBox>? _cachedNotPossible;

        public IReadOnlyCollection<ParlorPuzzleBox> PossibleGemsLocationsInformedInStatement
            => _cachedPossible ??= IsInverted
            ? GetPossibleGemsLocationsInvertedInformedInStatement()
            : GetPossibleGemsLocationsInformedInStatement();

        public IReadOnlyCollection<ParlorPuzzleBox> NotPossibleGemsLocationsInformedInStatement
            => _cachedNotPossible ??= IsInverted
            ? GetNotPossibleGemsLocationsInvertedInformedInStatement()
            : GetNotPossibleGemsLocationsInformedInStatement();

        protected abstract IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement();
        protected abstract IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInvertedInformedInStatement();
        protected abstract IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement();
        protected abstract IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInvertedInformedInStatement();
    }
}
