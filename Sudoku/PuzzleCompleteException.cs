using System;
using System.Runtime.Serialization;

namespace SudokuLibrary
{
    [Serializable]
    internal class PuzzleCompleteException : Exception
    {
        public PuzzleCompleteException()
        {
        }

        public PuzzleCompleteException(string message) : base(message)
        {
        }

        public PuzzleCompleteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PuzzleCompleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            return "A puzzle is filled done!";
        }
    }
}