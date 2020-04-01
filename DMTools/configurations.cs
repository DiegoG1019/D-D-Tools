using System.Collections.Generic;
using Serilog;

namespace DnDTDesktop
{

    public static class Cf
    {

        public static class Lang
        { //I don't honestly have a reason to encapsulate these right now

            public static Dictionary<string, string> util = new Dictionary<string, string>();
            public static Dictionary<string, string> gui = new Dictionary<string, string>();
            public static Dictionary<string, string> ent = new Dictionary<string, string>();
            public static Dictionary<string, string> items = new Dictionary<string, string>();

        }

        public static class Options
        {
            public static Dictionary<string, int> EntityValues = new Dictionary<string, int>();
        }

        public static void LoadLang()
        {
            Lang.util.Add("currency", "P.");
            Lang.ent.Add("noRequirements", "Nothing");
            Log.Information("Loaded Language Data");
        }

        public static void LoadOptions()
        {

            Options.EntityValues.Add("dead", -10);
            Options.EntityValues.Add("bleedingOut", -1);
            Options.EntityValues.Add("down", 0);
            Options.EntityValues.Add("maxSpellLevel", 9);
            Log.Information("Loaded EntityValues Data");

            /*--------------------------------------*/

            Log.Information("Loaded Options");
        }

    }

}