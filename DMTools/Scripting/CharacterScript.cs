using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CSScriptLib;
using DiegoG.DnDTDesktop.Characters.Complements;

namespace DiegoG.DnDTDesktop.Scripting
{
    [Serializable]
    public abstract class CharacterScript<T> : CharacterTrait<T> where T : class
    {
        public static IEvaluator Evaluator = CSScript.Evaluator.ReferenceAssemblyOf<CharacterScript<T>>();
        public string ScriptString { get; protected set; }
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public dynamic ScriptObject { get; protected set; }

        [OnDeserialized]
        public abstract void Init();
        /// <summary>
        /// Validates the script. Throws InvalidScriptException
        /// </summary>
        public abstract void Validate();
        public bool ValidateSafe()
        {
            try { Validate(); }
            catch (InvalidScriptException) { return false; }
            return true;
        }
        /// <summary>
        /// This is for serialization purposes
        /// </summary>
        public CharacterScript() { }
        public CharacterScript(string script)
        {
            ScriptString = script;
            Init();
        }
        public CharacterScript(string path, string filename)
        {
            ScriptString = File.ReadAllText(Path.Combine(path, filename));
            Init();
        }
    }
}
