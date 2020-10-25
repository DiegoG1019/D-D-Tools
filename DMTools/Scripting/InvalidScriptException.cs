using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTDesktop.Scripting
{
    public class InvalidScriptException : Exception
    {
        public InvalidScriptException() : base() { }
        public InvalidScriptException(string message) : base(message) { }
        public InvalidScriptException(string message, Exception innerException) : base(message, innerException) { }
    }
}
