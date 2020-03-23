using System;
using System.Collections.Generic;


namespace DnDTools{

    public struct Version{
        
        private string preppendix;
        private byte[] v;
        public Version(string p, byte w, byte z, byte y, byte x){
            this.v = new byte[4];
            this.v[0] = w;
            this.v[1] = z;
            this.v[2] = y;
            this.v[3] = x;
            this.preppendix = p;
        }
        public string get(){
            return String.Format("{0}-{1}.{2}.{3}.{4}",this.preppendix, this.v[0], this.v[1], this.v[2], this.v[3]);
        }

    }

    public interface Historied{
        
        dynamic get();
        dynamic get(int i);
        int getItems();

    }
    
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
        public int throwDice(){

            int total = 0;

            for(byte i = this.throws; i > 0; i--){
                total += Dice.rand.Next(1,this.type+1);
            };

            return total+this.extra;

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

    public struct PriceTag{
        private ulong value;

        public PriceTag(ulong v){
            this.value = v;
        }

        public ulong get(){
            return this.value;
        }

        public void set(ulong v){
            this.value = v;
        }

        public void change(int v){
            this.value = (ulong)((int)this.value + v);
        }

        ///And finally, here's the reason I made this in the first place
        public string toString(){
            return String.Format("{0}{1}",Cf.lang.getUtil("currency"),this.value);
        }
        
    }

    public struct Wallet: Historied{

        private ulong value;
        private List<int> history;
        private float weight;

        private void updateWeight(){
            if(this.value > 0){
                this.weight = this.value/50F;
            }else{
                this.weight = 0F;
            }
        }

        public Wallet(ulong value){
            this.history = new List<int>();
            this.value = value;
            this.history.Add((int)value);
            if(this.value > 0){
                this.weight = this.value/50F;
            }else{
                this.weight = 0F;
            }
        }

        public void add(ulong value){
            this.value += value;
            this.updateWeight();
        }

        public void gain(ulong value){
            this.add(value);
            this.history.Add(((int)value));
        }
        public void gain(Wallet other){
            this.add(other.value);
            other.empty();
            this.history.Add(((int)value));
        }

        public void sub(ulong value){
            if(value > this.value){
                throw new WalletOverDrawException(String.Format("Attempted to draw {0} over limit. W1:{1} ; w2:{2}",value-this.value,this.value,value));
            }else{
                this.value -= value;
                this.updateWeight();
            }
        }

        public void spend(ulong value){
            this.sub(value);
            this.history.Add(-((int)value));
        }
        public void spend(Wallet other){
            this.sub(other.value);
            this.history.Add(-((int)other.value));
        }

        public void empty(){
            this.spend(this.value);
        }

        public dynamic get(){
            return this.value;
        }
        public dynamic get(int i){
            return this.history[i];
        }

        public int getItems(){
            return this.history.Count;
        }

        public string toString(){
            return String.Format("{0}{1}",Cf.lang.getUtil("currency"),this.value);
        }

        public Wallet separate(ulong value){
            this.spend(value);
            return new Wallet(value);
        }
        
    }

}