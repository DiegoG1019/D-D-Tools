using System;

namespace DnDTools{
    public class TypeMismatchException: Exception{
        public TypeMismatchException(string message): base(message) {
        }
    }

    public class WalletOverDrawException: Exception{
        public WalletOverDrawException(string message): base(message){
        }
    }

    public class TooManyFreeLevels: Exception{
        public TooManyFreeLevels(string message): base(message){
        }
    }

    public class CantLevelUpYet: Exception{
        public CantLevelUpYet(string message): base(message){
        }
    }
}