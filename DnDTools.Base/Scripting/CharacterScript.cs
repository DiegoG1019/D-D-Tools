using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using CSScriptLib;
using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.Utilities.IO;

namespace DiegoG.DnDTools.Base.Scripting
{
    public interface ICharacterScript
    {
        [OnDeserialized]
        void Init();
    }
    [Serializable]
    public abstract class CharacterScript<T>
    {
        static CharacterScript() => JsonSerializationSettings.RegisterClassCallbacksJsonConverter<CharacterScript<T>>();
        public string ScriptString { get; protected set; }
        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public dynamic ScriptObject { get; protected set; }

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
        }
        public CharacterScript(string path, string filename)
        {
            ScriptString = File.ReadAllText(Path.Combine(path, filename));
        }
    }
}
