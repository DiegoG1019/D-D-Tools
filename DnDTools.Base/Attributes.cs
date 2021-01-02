using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.Utilities.Settings;

namespace DiegoG.DnDTools.Base.Attributes
{
    /// <summary>
    /// Applied to properties of a character that are relevant for active display 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class PresentationRelevantAttribute : Attribute
    {
        public PresentationRelevantAttribute(string propertyName) => PropertyName = propertyName;
        public string PropertyName { get; init; }
        public string LangPropertyName => Settings<Lang>.CurrentGetString(PropertyName);
    }
}
