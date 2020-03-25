using System;

namespace DnDTools{

    public enum Stats {
        str,      con,       dex,      wis,       inte,     cha,            
        fort,     refl,      will,     spd,      initiative
    };

    public enum Schools { 
        abjuration, divination, conjuration, enchantment, evocation, illusion, necromancy, transmutation
    }

    class App{

        public static Version version = new Version("Alpha",0,0,6,0);
        public const string author = "Diego Garcia";
       
        static void Main(string[] args){

            /*--------------------------------------------  -------------------------------------------*/

            /*--------------------------------------Initialization-------------------------------------*/
            
            Console.WriteLine("Running D&DTools version: {0}", App.version.get());
            Console.WriteLine("Program Author: {0}", App.author);
            Cf.loadLang();
            Cf.loadOptions();

            /*-----------------------------------------Testing-----------------------------------------*/
            
            //test char
            Character tchar = new Character(5, "Tchar");
            tchar.armorC.armor = 5;
            tchar.baseStats[(byte)Stats.dex] = 14;

            string tc = "---------------- \n Tchar's basehp {0} \n Tchar's current hp {1} \n Tchar's current lethal damage {2} \n Is Tchar dead? {3} \n Tchar's AC {4} \n Tchar's touch AC {5} \n Tchar's unaware AC {6} \n Tchar is {7}";

            Console.WriteLine(
                tc,
                tchar.health.getBaseHP(),
                tchar.health.getHP(),
                tchar.health.lethalDamage.get(),
                tchar.health.isDead(),
                tchar.armorC.get(),
                tchar.armorC.touch(),
                tchar.armorC.unaware(),
                tchar.health.getState()
            );

            tchar.health.lethalDamage.hurt(5);

            Console.WriteLine(
                tc,
                tchar.health.getBaseHP(),
                tchar.health.getHP(),
                tchar.health.lethalDamage.get(),
                tchar.health.isDead(),
                tchar.armorC.get(),
                tchar.armorC.touch(),
                tchar.armorC.unaware(),
                tchar.health.getState()
            );
            
            tchar.health.lethalDamage.hurt(5);

            Console.WriteLine(
                tc,
                tchar.health.getBaseHP(),
                tchar.health.getHP(),
                tchar.health.lethalDamage.get(),
                tchar.health.isDead(),
                tchar.armorC.get(),
                tchar.armorC.touch(),
                tchar.armorC.unaware(),
                tchar.health.getState()
            );

            tchar.health.lethalDamage.hurt(5);

            Console.WriteLine(
                tc,
                tchar.health.getBaseHP(),
                tchar.health.getHP(),
                tchar.health.lethalDamage.get(),
                tchar.health.isDead(),
                tchar.armorC.get(),
                tchar.armorC.touch(),
                tchar.armorC.unaware(),
                tchar.health.getState()
            );

            tchar.health.lethalDamage.heal(2);

            Console.WriteLine(
                tc,
                tchar.health.getBaseHP(),
                tchar.health.getHP(),
                tchar.health.lethalDamage.get(),
                tchar.health.isDead(),
                tchar.armorC.get(),
                tchar.armorC.touch(),
                tchar.armorC.unaware(),
                tchar.health.getState()
            );

            tchar.health.lethalDamage.heal(7);

            Console.WriteLine(
                tc,
                tchar.health.getBaseHP(),
                tchar.health.getHP(),
                tchar.health.lethalDamage.get(),
                tchar.health.isDead(),
                tchar.armorC.get(),
                tchar.armorC.touch(),
                tchar.armorC.unaware(),
                tchar.health.getState()
            );

            tchar.health.lethalDamage.heal(100);
            
            Console.WriteLine(
                tc,
                tchar.health.getBaseHP(),
                tchar.health.getHP(),
                tchar.health.lethalDamage.get(),
                tchar.health.isDead(),
                tchar.armorC.get(),
                tchar.armorC.touch(),
                tchar.armorC.unaware(),
                tchar.health.getState()
            );

            /*---------------------------------------Finalization--------------------------------------*/

            Console.ReadKey();

        }

    }

}