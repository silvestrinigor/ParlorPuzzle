using ParlorPuzzle.Boxes;
using ParlorPuzzle.Enums;

namespace ParlorPuzzle.Statements
{
    abstract class ParlorPuzzleStatement
    {
        private bool? _cachedIsTrue;
        private bool _isEvaluating;

        public string Message
            => GetMessage();

        protected abstract string GetMessage();

        public bool IsTrue
        {
            get
            {
                if (_cachedIsTrue.HasValue)
                    return _cachedIsTrue.Value;

                if (_isEvaluating)
                    throw new InvalidOperationException("Circular dependency detected in statement evaluation.");

                _isEvaluating = true;

                var value = VerifyIfStatementIsTrue();

                _cachedIsTrue = value;
                _isEvaluating = false;

                return value;
            }
        }

        protected abstract bool VerifyIfStatementIsTrue();

        public required ParlorPuzzleBox Box { get; set; }
        public required ParlorPuzzleBoxOption BoxOption { get; set; }
        public required ParlorPuzzleBoxes Boxes { get; set; }

        private IReadOnlyCollection<ParlorPuzzleBox>? _cachedPossible;
        private IReadOnlyCollection<ParlorPuzzleBox>? _cachedNotPossible;

        public IReadOnlyCollection<ParlorPuzzleBox> PossibleGemsLocationsInformedInStatement
            => _cachedPossible ??= GetPossibleGemsLocationsInformedInStatement();

        public IReadOnlyCollection<ParlorPuzzleBox> NotPossibleGemsLocationsInformedInStatement
            => _cachedNotPossible ??= GetNotPossibleGemsLocationsInformedInStatement();

        protected abstract IReadOnlyCollection<ParlorPuzzleBox> GetPossibleGemsLocationsInformedInStatement();
        protected abstract IReadOnlyCollection<ParlorPuzzleBox> GetNotPossibleGemsLocationsInformedInStatement();
    }
}
