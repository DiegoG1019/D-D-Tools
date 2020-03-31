using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace DMTools
{

    public enum Stats
    {
        strength, constitution, dexterity, wisdom, intelligence, charisma,
        fortitude, reflex, will, speed, initiative
    }; //Is it possible to dynamically initialize an enum? Maybe I just need a new object type

    public enum Schools
    {
        abjuration, divination, conjuration, enchantment, evocation, illusion, necromancy, transmutation
    } //Perhaps both of these should be a configuration option

    static class App
    {

        public static int statCount = Enum.GetNames(typeof(Stats)).Length;
        public static int schoolCount = Enum.GetNames(typeof(Schools)).Length;

        public static readonly Version version = new Version("Alpha", 0, 0, 9, 2);
        public const string author = "Diego Garcia";

        public const string WriteDir = "C:/Users/%USERNAME%/Documents/DnDT/";

        public static int tchar = Character.Create(5, "Tchar");

        public static JsonSerializerOptions JSONOptions = new JsonSerializerOptions{
            WriteIndented = true,
        };/**/

        [STAThread]
        static void Main()
        {

            /*--------------------------------------------  -------------------------------------------*/

            /*--------------------------------------Initialization-------------------------------------*/

            Console.WriteLine("Running D&DTools version: {0}", App.version.Full);
            Console.WriteLine("Program Author: {0}", App.author);
            Cf.loadLang();
            Cf.loadOptions();

            /*-----------------------------------------Testing-----------------------------------------*/

            //test char
            Loaded.Characters.Objects[tchar].armorC.armor = 5;
            Loaded.Characters.Objects[tchar].SetBaseStats(Stats.dexterity, 14);
            Loaded.Characters.Objects[tchar].SetBaseStats(Stats.charisma, 2);

            string tcskt = "{0}, ";
            string tcsk = "";
            for (int i = 0; i < Loaded.Characters.Objects[tchar].abilities.Count; i++)
            {
                tcsk += String.Format(tcskt, Loaded.Characters.Objects[tchar].feats[i].FullName);
            }
            for (int i = 0; i < Loaded.Characters.Objects[tchar].feats.Count; i++)
            {
                tcsk += String.Format(tcskt, Loaded.Characters.Objects[tchar].abilities[i].FullName);
            }

            string tc = "---------------- \n {0}'s significant abilities and feats: {1}";
            string tcs = "-----***----- \n {0}'s {1} #{2}: {3}\n  -{4}\n  Requires: {5}";

            Console.WriteLine(
                tc,
                Loaded.Characters.Objects[tchar].desc.name,
                tcsk.Substring(0, tcsk.Length - 2)
            );

            for (int i = 0; i < Loaded.Characters.Objects[tchar].abilities.Count; i++)
            {
                Console.WriteLine(tcs,
                    Loaded.Characters.Objects[tchar].desc.name,
                    "Ability",
                    i + 1,
                    Loaded.Characters.Objects[tchar].abilities[i].FullName,
                    Loaded.Characters.Objects[tchar].abilities[i].description,
                    Loaded.Characters.Objects[tchar].abilities[i].requirements
                );
            }
            for (int i = 0; i < Loaded.Characters.Objects[tchar].feats.Count; i++)
            {
                Console.WriteLine(tcs,
                    Loaded.Characters.Objects[tchar].desc.name,
                    "Feat",
                    i + 1,
                    Loaded.Characters.Objects[tchar].feats[i].FullName,
                    Loaded.Characters.Objects[tchar].feats[i].description,
                    Loaded.Characters.Objects[tchar].feats[i].requirements
                );
            }

            Console.WriteLine(" *** {0}: {1}", Stats.charisma, Loaded.Characters.Objects[tchar].GetMod(Stats.charisma));
            Console.WriteLine(" *** {0}: {1}", Stats.constitution, Loaded.Characters.Objects[tchar].GetMod(Stats.constitution));
            Console.WriteLine(" *** {0}: {1}", Stats.dexterity, Loaded.Characters.Objects[tchar].GetMod(Stats.dexterity));
            Console.WriteLine(" *** {0}: {1}", Stats.strength, Loaded.Characters.Objects[tchar].GetMod(Stats.strength));
            Console.WriteLine(" *** {0}: {1}", Stats.intelligence, Loaded.Characters.Objects[tchar].GetMod(Stats.intelligence));
            Console.WriteLine(" *** {0}: {1}", Stats.wisdom, Loaded.Characters.Objects[tchar].GetMod(Stats.wisdom));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

            /*---------------------------------------Finalization--------------------------------------*/

        }

    }

}