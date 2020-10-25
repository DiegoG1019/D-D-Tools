using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSScriptLib;
using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.Characters.Complements;

namespace DiegoG.DnDTDesktop.Scripting
{
    public class CharacterPropertyScript : CharacterScript<CharacterPropertyScript>
    {
        public int DependentValue(Character chara, SecondaryCharacterStatProperty stat) => ScriptObject.GetDependentValue(chara, stat);
        public int OtherValue(Character chara, SecondaryCharacterStatProperty stat) => ScriptObject.GetOtherValue(chara, stat);
        public void ScriptInput(Character chara, SecondaryCharacterStatProperty stat, int input) => ScriptObject.Input(chara, stat, input);
        public bool ReceiveInput => ScriptObject.ReceiveInput;
        public bool RespondToStatChanges => throw new NotImplementedException();//ScriptObject.RespondToStatChanges;
        public override void Validate()
        {
            try
            {
                int _;
                var s = new SecondaryCharacterStat();
                _ = ScriptObject.GetDependentValue(Parent, s);
                _ = ScriptObject.GetOtherValue(Parent, s);
            }catch(Exception e)
            {
                throw new InvalidScriptException($"CharacterPropertyScript \"[[{ScriptString}]]\" is invalid", e);
            }
        }
        public override void Init() 
        {
            ScriptObject = Evaluator.LoadCode(ScriptObject);
            Validate();
        }
        public CharacterPropertyScript() : base() { }
        public CharacterPropertyScript(string script) : base(script) { }
        public CharacterPropertyScript(string path, string filename) : base(path, filename) { }
    }
}
