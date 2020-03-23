using System;

namespace DnDTools{
    
    public struct Dice{
        private static dynamic rand = new Random();

        private byte throws;
        private byte type;
        private sbyte extra;

        public Dice(byte throws, byte type){
            this.throws = throws;
            this.type = type;
            this.extra = 0;
        }
        public Dice(byte throws, byte type, sbyte extra){
            this.throws = throws;
            this.type = type;
            this.extra = extra;
        }
        public short throwDice(){

            short total = 0;

            for(byte i = this.throws; i > 0; i--){
                total += Dice.rand.Next(1,this.type+1);
            };

            return (short)(total+this.extra);

        }

        public Dice add(Dice other){
            if(this.type == other.type){
                return new Dice((byte)(this.throws+other.throws), this.type, this.extra);
            }else{
                throw new TypeMismatchException("Attempted to add two Die of different types");
            }
        }
        public Dice add(byte value){
            return new Dice((byte)(this.throws+value), this.type, this.extra);
        }

        public Dice sub(byte value){
            if(this.throws > value){
                return new Dice(1, this.type, this.extra);
            }else{
                return new Dice((byte)(this.throws-value), this.type, this.extra);
            }
        }

        public string toString(){
            if(this.extra > 0){
                return String.Format("{0}d{1}+{2}",this.throws, this.type, this.extra);
            }else{
                if(this.extra < 0){
                    return String.Format("{0}d{1}{2}", this.throws, this.type, this.extra);
                }else{
                    return String.Format("{0}d{1}", this.throws, this.type);
                }
            }
        }

    }

    public struct Wallet{


        
    }

}