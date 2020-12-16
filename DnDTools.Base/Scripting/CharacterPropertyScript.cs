using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using CSScriptLib;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.Base.Characters.Complements;

namespace DiegoG.DnDTools.Base.Scripting
{
    public class CharacterPropertyScript : CharacterScript<CharacterPropertyScript>, ICharacterScript
    {
        public int DependentValue(Character chara, SecondaryCharacterStatProperty stat) => ScriptObject.GetDependentValue(chara, stat);
        public int OtherValue(Character chara, SecondaryCharacterStatProperty stat) => ScriptObject.GetOtherValue(chara, stat);
        public void ScriptInput(Character chara, SecondaryCharacterStatProperty stat, int input) => ScriptObject.Input(chara, stat, input);

        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public bool ReceiveInput => ScriptObject.ReceiveInput;
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public bool RespondToStatChanges => throw new NotImplementedException();//ScriptObject.RespondToStatChanges;
        public override void Validate()
        {
            try
            {
#warning No validation yet
            }catch(Exception e)
            {
                throw new InvalidScriptException($"CharacterPropertyScript \"[[{ScriptString}]]\" is invalid", e);
            }
        }
        public void Init()
        {
            try
            {
                ScriptObject = CSScript.Evaluator.LoadCode(ScriptString);
            }
            catch (Exception e)
            {
                throw new InvalidScriptException($"CharacterPropertyScript \"[[{ScriptString}]]\" is invalid", e);
            }
            Validate();
        }
        public CharacterPropertyScript() : base() { }
        public CharacterPropertyScript(string script) : base(script) { Init(); }
        public CharacterPropertyScript(string path, string filename) : base(path, filename) { Init(); }
    }
}
