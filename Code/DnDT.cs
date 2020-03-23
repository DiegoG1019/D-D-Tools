using System;

namespace DnDTools{

    class App{

        public static Version version = new Version("Alpha",0,0,4,0);
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
            
            //test char
            Character tchar = new Character(5);

            Console.WriteLine(
                "---------------- \n Tchar's level {0} \n Tchar's current exp {1} \n Tchar's required exp {2} \n Can Tchar level up? {3} \n How much more exp does Tchar need? {4}",
                tchar.level,
                tchar.exp.get(),
                tchar.exp.getRequired(),
                tchar.exp.didLevel(),
                tchar.exp.getRequiredLeft()
            );

            try{
                tchar.exp.levelUp();
            }catch(CantLevelUpYet e1){
                Console.WriteLine(e1.ToString());
            }

            tchar.exp.gain(28772);
            Console.WriteLine(
                "---------------- \n Tchar's level {0} \n Tchar's current exp {1} \n Tchar's required exp {2} \n Can Tchar level up? {3} \n How much more exp does Tchar need? {4}",
                tchar.level,
                tchar.exp.get(),
                tchar.exp.getRequired(),
                tchar.exp.didLevel(),
                tchar.exp.getRequiredLeft()
            );

            try{
                tchar.exp.levelUp();
            }catch(CantLevelUpYet e1){
                Console.WriteLine(e1.ToString());
            }

            tchar.exp.gain(69451);
            Console.WriteLine(
                "---------------- \n Tchar's level {0} \n Tchar's current exp {1} \n Tchar's required exp {2} \n Can Tchar level up? {3} \n How much more exp does Tchar need? {4}",
                tchar.level,
                tchar.exp.get(),
                tchar.exp.getRequired(),
                tchar.exp.didLevel(),
                tchar.exp.getRequiredLeft()
            );

            try{
                tchar.exp.levelUp();
            }catch(CantLevelUpYet e1){
                Console.WriteLine(e1.ToString());
            }
            
            Console.WriteLine(
                "---------------- \n Tchar's level {0} \n Tchar's current exp {1} \n Tchar's required exp {2} \n Can Tchar level up? {3} \n How much more exp does Tchar need? {4}",
                tchar.level,
                tchar.exp.get(),
                tchar.exp.getRequired(),
                tchar.exp.didLevel(),
                tchar.exp.getRequiredLeft()
            );


            /*---------------------------------------Finalization--------------------------------------*/

            Console.ReadKey();

        }

    }

}