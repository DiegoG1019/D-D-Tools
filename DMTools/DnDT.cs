using System;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DMTools
{

    public enum Stats {
        strength,   constitution,   dexterity,   wisdom,   intelligence,   charisma,            
        fortitude,  reflex,         will,        speed,    initiative
    }; //Is it possible to dynamically initialize an enum? Maybe I just need a new object type

    public enum Schools { 
        abjuration, divination, conjuration, enchantment, evocation, illusion, necromancy, transmutation
    } //Perhaps both of these should be a configuration option

    static class App{

        public static int statCount = Enum.GetNames(typeof(Stats)).Length;
        public static int schoolCount = Enum.GetNames(typeof(Schools)).Length;

        public static Version version = new Version("Alpha",0,0,9,1);
        public const string author = "Diego Garcia";

        /*public const JsonSerializerOptions JSONOptions = new JsonSerializerOptions{
            WriteIndented = true,
        };/**/

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            /*--------------------------------------------  -------------------------------------------*/

            /*--------------------------------------Initialization-------------------------------------*/

            Console.WriteLine("Running D&DTools version: {0}", App.version.get());
            Console.WriteLine("Program Author: {0}", App.author);
            Cf.loadLang();
            Cf.loadOptions();

            /*-----------------------------------------Testing-----------------------------------------*/
            
            //test char
            int tchar = Character.Create(5, "Tchar");
            Loaded.Characters.Objects[tchar].armorC.armor = 5;
            Loaded.Characters.Objects[tchar].setBaseStats(Stats.dexterity, 14);
            Loaded.Characters.Objects[tchar].setBaseStats(Stats.charisma, 2);

            string tcskt = "{0}, ";
            string tcsk = "";
            for(int i = 0; i< Loaded.Characters.Objects[tchar].abilities.Count; i++){
                tcsk = tcsk + String.Format(tcskt, Loaded.Characters.Objects[tchar].feats[i].FullName);
            }
            for(int i = 0; i< Loaded.Characters.Objects[tchar].feats.Count; i++){
                tcsk = tcsk + String.Format(tcskt, Loaded.Characters.Objects[tchar].abilities[i].FullName);
            }

            string tc = "---------------- \n {0}'s significant abilities and feats: {1}";
            string tcs = "-----***----- \n {0}'s {1} #{2}: {3}\n  -{4}\n  Requires: {5}";

            Console.WriteLine(
                tc,
                tchar.desc.name,
                tcsk.Substring(0,tcsk.Length-2)
            );

            for(int i = 0; i<tchar.abilities.Count; i++){
                Console.WriteLine(tcs,
                    tchar.desc.name,
                    "Ability",
                    i+1,
                    tchar.abilities[i].FullName,
                    tchar.abilities[i].description,
                    tchar.abilities[i].requirements
                );
            }
            for(int i = 0; i<tchar.feats.Count; i++){
                Console.WriteLine(tcs,
                    tchar.desc.name,
                    "Feat",
                    i+1,
                    tchar.feats[i].FullName,
                    tchar.feats[i].description,
                    tchar.feats[i].requirements
                );
            }

            Console.WriteLine(" *** {0}: {1}",Stats.charisma,tchar.getMod(Stats.charisma));
            Console.WriteLine(" *** {0}: {1}",Stats.constitution,tchar.getMod(Stats.constitution));
            Console.WriteLine(" *** {0}: {1}",Stats.dexterity,tchar.getMod(Stats.dexterity));
            Console.WriteLine(" *** {0}: {1}",Stats.strength,tchar.getMod(Stats.strength));
            Console.WriteLine(" *** {0}: {1}",Stats.intelligence,tchar.getMod(Stats.intelligence));
            Console.WriteLine(" *** {0}: {1}",Stats.wisdom,tchar.getMod(Stats.wisdom));

            /*FileStream fileOut = new FileStream("Tchar2.character.json", FileMode.OpenOrCreate, 
            FileAccess.ReadWrite);

            File.WriteAllText("Tchar2.character", JsonSerializer.Serialize(tchar, JSONOptions));/**/

            /*---------------------------------------Finalization--------------------------------------*/

            Console.ReadKey();

        }

    }

}