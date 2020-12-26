using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Base
{
    [Serializable]
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException() { }
        public InvalidCharacterException(string message) : base(message) { }
        public InvalidCharacterException(string message, Exception inner) : base(message, inner) { }
        protected InvalidCharacterException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
