using System;

namespace DnDTools{

    class App{

        public static Version version = new Version("Alpha",0,0,3,0);
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

            /*--------------------------------------------  -------------------------------------------*/

            /*--------------------------------------Initialization-------------------------------------*/
            
            Console.WriteLine("Running D&DTools version: {0}", App.version.get());
            Console.WriteLine("Program Author: {0}", App.author);
            Cf.loadLang();

            /*-----------------------------------------Testing-----------------------------------------*/
            
            Entity testEnt = new Entity(5);

            Console.WriteLine("testEnt extra: {0}", testEnt.expgrant.getExtra() );
            Console.WriteLine("testEnt baseGrant: {0}", testEnt.expgrant.getBaseGrant() );

            testEnt.expgrant.addBase(16);
            testEnt.expgrant.addExtra(48);
            testEnt.expgrant.subBase(16);
            testEnt.expgrant.subExtra(48);
            
            Console.WriteLine("testEnt grants: {0}", testEnt.expgrant.getExp() );

            Console.ReadKey();

        }

    }

}