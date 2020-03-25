using System;
using System.Collections.Generic;

namespace DnDTools{
    
    public static class Cf{

        public static class Lang{

            public enum lcat{ //Language category
                util, gui, ent, item
            }

            public static Dictionary<string, string>[] l = new Dictionary<string, string>[]{
                new Dictionary<string, string>(), //utilities
                new Dictionary<string, string>(), //gui
                new Dictionary<string, string>(), //entities
                new Dictionary<string, string>()  //items
            };

            public static string getUtil(string k){
                return l[0][k];
            }
            public static string getGui(string k){
                return l[1][k];
            }
            public static string getEnt(string k){
                return l[2][k];
            }
            public static string getItems(string k){
                return l[3][k];
            }

        }

        public static class Options{
            public static Dictionary<string, int> EntityValues;
        }

        public static void loadLang(){
            Lang.l[0].Add("currency","P.");
        }

        public static void loadOptions(){
            Options.EntityValues.Add("dead",-10);
            Options.EntityValues.Add("bleedingOut",-1);
            Options.EntityValues.Add("down",0);
        }

    }

}