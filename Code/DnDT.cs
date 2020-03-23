using System;

namespace DnDTools{

    class App{

        public static Version version = new Version("Alpha",0,0,2,1);
        public const string author = "Diego Garcia";
       
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

            Console.WriteLine("Running D&DTools version: {0}", App.version.get());
            Console.WriteLine("Program Author: {0}", App.author);
            Cf.loadLang();
            
            Wallet w1 = new Wallet(532);
            Wallet w2 = new Wallet(6699);

            Console.WriteLine("Wallet 1 get: {0}", w1.get());
            Console.WriteLine("Wallet 1 toString: {0}", w1.toString());

            w1.spend(69);
            w1.gain(124);
            w1.gain(w2);
            w1.spend(464);
            w1.gain(35);

            Console.WriteLine("Wallet 1 get(1): {0}", w1.get(1));
            Console.WriteLine("Wallet 1 get(3): {0}", w1.get(3));

            Wallet w3 = w1.separate(3563);

            Console.WriteLine("Wallet 3 get: {0}", w3.get());
            Console.WriteLine("Wallet 4 get: {0}", w3.separate(2221).get());
            Console.WriteLine("Wallet 3 get (again) : {0}", w3.get());

            w3.spend(w1.separate(159));

            Console.ReadKey();

        }

    }

}