using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public sealed class Description : CharacterTrait<Description>, INoted
    {
        public string Name { get; set; } = "No'One";
        public string Fullname { get; set; } = "No'One Impohrtahnt";
        public string Race { get; set; } = "Human";
        public Alignments Alignment { get; set; } = Alignments.TrueNeutral;
        public string Deity { get; set; } = "None";
        public BodyTypes BodyType { get; set; } = BodyTypes.Humanoid;
        public Sizes Size { get; set; } = Sizes.Medium;
        public string Bio { get; set; } = "Bio";
        public string Intro { get; set; } = "None";
        public string Personality { get; set; } = "Bland";
        public string Gender { get; set; } = "Male";
        public int Age { get; set; } = 18;
        public Length Height { get; set; } = new Length(1.2M, Length.Units.Meter);
        public Mass Weight { get; set; } = new Mass(50, Mass.Units.Kilogram);
        public uint EyeColor { get; set; } = 0xFF8B4513;
        public uint HairColor { get; set; } = 0xFF000000;
        public uint SkinColor { get; set; } = 0xFFFFEBCD;
        public NoteList Notes { get; set; } = new NoteList();

        public uint Bgcolor { get; set; } = 0x00000000;
        public uint BannerColor { get; set; } = 0x00000000;
        //public Bitmap Mugshot { get; set; }
        //public Bitmap FullBodyImage { get; set; }
        //public bool HasMugshot => Mugshot != null;
        //public bool HasFullBodyImage => FullBodyImage != null;
        //public List<Bitmap> ArcaneMarks { get; set; } = new List<Bitmap>();
    }
}
