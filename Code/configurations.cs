using System;
using System.Collections.Generic;

namespace DnDTools{
    
    public static class Cf{

        public static Lang lang = new Lang(0);

        public static void loadLang(){
            lang.l[0].Add("currency","P.");
        }

    }

    public struct Lang{
            
            public Dictionary<string, string>[] l;

            public Lang(byte a){
                l = new Dictionary<string, string>[]{
                    new Dictionary<string, string>(), //utilities
                    new Dictionary<string, string>(), //gui
                    new Dictionary<string, string>(), //entities
                    new Dictionary<string, string>()  //items
                };
            }

            public string getUtil(string k){
                return this.l[0][k];
            }
            public string getGui(string k){
                return this.l[1][k];
            }
            public string getEnt(string k){
                return this.l[2][k];
            }
            public string getItems(string k){
                return this.l[3][k];
            }

        }

}