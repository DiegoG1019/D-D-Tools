using System;

namespace DnDTools{

    public enum Stats {
        str,      con,       dex,      wis,       inte,     cha,            
        fort,     refl,      will,     spd,      initiative
    }; //Is it possible to dynamically initialize an enum? Maybe I just need a new object type

    public enum Schools { 
        abjuration, divination, conjuration, enchantment, evocation, illusion, necromancy, transmutation
    } //Perhaps both of these should be a configuration option

    class App{

        public static Version version = new Version("Alpha",0,0,7,4);
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
            tchar.setBaseStats(Stats.dex, 14);
            tchar.setBaseStats(Stats.cha, 2);

            string tcskt = "{0}, ";
            string tcsk = "";
            for(int i = 0; i<tchar.skills.Count; i++){
                tcsk = tcsk + String.Format(tcskt, tchar.skills[i].name);
            }

            string tc = "---------------- \n {0}'s significant skills: {1}";
            string tcs = "------***------ \n {0} Skill #{1} \n {2} \n  Key Statistic: {3} \n  Levels: {4} \n  Misc. Levels: {5} \n  Can it be used without training? {6} \n  Is it penalized by armor? {7} \n  Is it a class skill? {8} \n  Skill modifier: {9}";

            Console.WriteLine(
                tc,
                tchar.desc.name,
                tcsk.Substring(0,tcsk.Length-2)
            );

            for(int i = 0; i<tchar.skills.Count; i++){
                Console.WriteLine(tcs,
                    tchar.desc.name,
                    i+1,
                    tchar.skills[i].name,
                    tchar.skills[i].keyStat,
                    tchar.skills[i].level,
                    tchar.skills[i].miscLevels,
                    !tchar.skills[i].getFlag(Skill.flags.trainedOnly), //This value is inverted, as denoted by the ! preceding it. - if trainedOnly is true, then it can only be used with training. Therefore, to answer if it can be used /Without/ training, it needs to be inverted.
                    tchar.skills[i].getFlag(Skill.flags.penalizedByArmor),
                    tchar.skills[i].getFlag(Skill.flags.JobSkill),
                    tchar.skills[i].getMod()
                );
            }

            /*---------------------------------------Finalization--------------------------------------*/

            Console.ReadKey();

        }

    }

}