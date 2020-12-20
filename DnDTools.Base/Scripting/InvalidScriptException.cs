using System;

namespace DiegoG.DnDTools.Base.Scripting
{
    public class InvalidScriptException : Exception
    {
        public InvalidScriptException() : base() { }
        public InvalidScriptException(string message) : base(message) { }
        public InvalidScriptException(string message, Exception innerException) : base(message, innerException) { }
    }
}
