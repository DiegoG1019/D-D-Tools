using System;

namespace DiegoG.DnDTools.Base.Other
{
    [Serializable]
    public record NameDesc
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public NoteList Notes { get; set; } = new();
        public NameDesc() { }
        public NameDesc(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
        public NameDesc(string name, string desc, NoteList notes) : this(name, desc)
        {
            Notes = notes;
        }
    }
}
