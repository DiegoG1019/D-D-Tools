using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Threading.Tasks;
using DiegoG.Utilities;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public abstract class CharacterTrait<T> where T : class
    {
        public string ParentName { get; set; }
        [IgnoreDataMember, JsonIgnore, XmlIgnore]
        public Character Parent => Program.Characters[ParentName];
        public virtual T Copy() => (T)Serialization.CopyByBinarySerialization(this);
    }
}
