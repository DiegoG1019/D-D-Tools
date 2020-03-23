using System;

namespace DnDTools{
    
    public static class Cf{

        public static Lang lang = new Lang();

        public static loadLang(){
            Cf.lang.Add("currency","P");
        }

    }

    public static struct Lang{
        
        Dictionary<string, string> utilities = new Dictionary<string, string>();
        Dictionary<string, string> gui = new Dictionary<string, string>();
        Dictionary<string, string> entities = new Dictionary<string, string>();
        Dictionary<string, string> items = new Dictionary<string, string>();

    }

}