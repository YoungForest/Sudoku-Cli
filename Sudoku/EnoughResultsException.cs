using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    [Serializable()]
    public class EnoughResultsException : System.Exception
    {
        public EnoughResultsException() : base() { }
        public EnoughResultsException(string message) : base(message) { }
        public EnoughResultsException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected EnoughResultsException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }

        public override string ToString()
        {
            return "Terminated normaly.";
        }
    }
}
