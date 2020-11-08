﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DiegoG.DnDNetCore.Other
{
    public class NoteList : List<string>
    {
        public event Action NotesChanged;
        public new void Add(string item)
        {
            base.Add(item);
            NotesChanged();
        }
        public new void Clear()
        {
            base.Clear();
            NotesChanged();
        }
        public new void Remove(string item)
        {
            base.Remove(item);
            NotesChanged();
        }
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            NotesChanged();
        }
        public new string this[int index]
        {
            get => base[index];
            set
            {
                base[index] = value;
                NotesChanged();
            }
        }

        public NoteList() : base() => NotesChanged += NoteList_NotesChanged;

        private void NoteList_NotesChanged()
        {
            string c = string.Empty;
            foreach (string b in this)
                c += $"-{b}\n";
            AllNotes = c.Trim();
        }

        [JsonIgnore, IgnoreDataMember, XmlIgnore]
        public string AllNotes { get; private set; }
    }
    public interface INoted
    {
        NoteList Notes { get; set; }
    }
}