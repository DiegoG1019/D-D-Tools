using System;

namespace DnDTools{
    public class TypeMismatchException: Exception{
        public TypeMismatchException(string message): base(message) {
        }
    }
}