using System;

namespace DnDTools{

    class App{
       
       public enum Stats {
           str,
           con,
           dex,
           wis,
           inte,
           cha,
           fortitude,
           reflexes,
           will,
           speed,
           initiative
        };
       
        static void Main(string[] args){
            
            Dice d1 = new Dice(2,8,2);
            Dice d2 = new Dice(2,8,-2);
            Dice d3 = new Dice(2,8);

            Console.WriteLine(d1.toString());
            Console.WriteLine(d2.toString());
            Console.WriteLine(d3.toString());
            Console.WriteLine(d1.throwDice());
            Console.WriteLine(d2.throwDice());
            Console.WriteLine(d3.throwDice());
            Console.ReadKey();

        }

    }

}