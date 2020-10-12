using DiegoG.DnDTDesktop.Characters.Complements;
using DiegoG.DnDTDesktop.Other;
using DiegoG.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Characters
{
    [Serializable]
    public sealed class Description : CharacterTrait<Description>, INoted
    {
        public string Name { get; set; } = "No'One";
        public string Fullname { get; set; } = "Impohrtahnt";
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
        public Color Eyes { get; set; } = Color.SandyBrown;
        public Color Hair { get; set; } = Color.Black;
        public Color Skin { get; set; } = Color.BlanchedAlmond;
        public Color Bgcolor { get; set; } = Color.Transparent;
        public Color BannerColor { get; set; } = Color.Transparent;
        public Bitmap Mugshot { get; set; }
        public Bitmap FullBodyImage { get; set; }
        public bool HasMugshot => Mugshot != null;
        public bool HasFullBodyImage => FullBodyImage != null;
        public List<Bitmap> ArcaneMarks { get; set; } = new List<Bitmap>();
        public NoteList Notes { get; set; } = new NoteList();
    }
}
