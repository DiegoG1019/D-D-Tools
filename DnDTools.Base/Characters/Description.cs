using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities.Measures;
using System;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters
{
    [Serializable]
    public sealed class Description : CharacterTrait<Description>, INoted
    {
        public string Name { get => NameField; set { NameField = value; NotifyPropertyChanged(); } }
        private string NameField = "No'One";
        public string Fullname { get => FullnameField; set { FullnameField = value; NotifyPropertyChanged(); } }
        private string FullnameField = "No'One Impohrtahnt";
        public string Race { get => RaceField; set { RaceField = value; NotifyPropertyChanged(); } }
        private string RaceField = "Human";
        public Alignments Alignment { get => AlignmentField; set { AlignmentField = value; NotifyPropertyChanged(); } }
        private Alignments AlignmentField = Alignments.TrueNeutral;
        public string Deity { get => DeityField; set { DeityField = value; NotifyPropertyChanged(); } }
        private string DeityField = "None";
        public BodyTypes BodyType { get => BodyTypeField; set { BodyTypeField = value; NotifyPropertyChanged(); } }
        private BodyTypes BodyTypeField = BodyTypes.Humanoid;
        public Sizes Size { get => SizeField; set { SizeField = value; NotifyPropertyChanged(); } }
        private Sizes SizeField = Sizes.Medium;
        public string Bio { get => BioField; set { BioField = value; NotifyPropertyChanged(); } }
        private string BioField = "Bio";
        public string Intro { get => IntroField; set { IntroField = value; NotifyPropertyChanged(); } }
        private string IntroField = "None";
        public string Personality { get => PersonalityField; set { PersonalityField = value; NotifyPropertyChanged(); } }
        private string PersonalityField = "Bland";
        public string Gender { get => GenderField; set { GenderField = value; NotifyPropertyChanged(); } }
        private string GenderField = "None";
        public int Age { get => AgeField; set { AgeField = value; NotifyPropertyChanged(); } }
        private int AgeField = 18;
        public Length Height { get => HeightField; set { HeightField = value; NotifyPropertyChanged(); } }
        private Length HeightField = new Length(1.2M, Length.Units.Meter);
        public Mass Weight { get => WeightField; set { WeightField = value; NotifyPropertyChanged(); } }
        private Mass WeightField = new Mass(50, Mass.Units.Kilogram);
        public uint EyeColor { get => EyeColorField; set { EyeColorField = value; NotifyPropertyChanged(); } }
        private uint EyeColorField = 0xFF8B4513;
        public uint HairColor { get => HairColorField; set { HairColorField = value; NotifyPropertyChanged(); } }
        private uint HairColorField = 0xFF000000;
        public uint SkinColor { get => SkinColorField; set { SkinColorField = value; NotifyPropertyChanged(); } }
        private uint SkinColorField = 0xFFFFEBCD;
        public NoteList Notes { get => NotesField; set { NotesField = value; NotifyPropertyChanged(); } }
        private NoteList NotesField = new NoteList();

        public uint Bgcolor { get => BgcolorField; set { BgcolorField = value; NotifyPropertyChanged(); } }
        private uint BgcolorField = 0x00000000;
        public uint BannerColor { get => BannerColorField; set { BannerColorField = value; NotifyPropertyChanged(); } }
        private uint BannerColorField = 0x00000000;
        //public Bitmap Mugshot { get => MugshotField; set { MugshotField = value; NotifyPropertyChanged(); } }
        //private Bitmap MugshotField;
        //public Bitmap FullBodyImage { get => FullBodyImageField; set { FullBodyImageField = value; NotifyPropertyChanged(); } }
        //private Bitmap FullBodyImageField;
        //public bool HasMugshot => Mugshot != null;
        //public bool HasFullBodyImage => FullBodyImage != null;
        //public ObservableCollection<Bitmap> ArcaneMarks { get => ArcaneMarksField; set {  } }
        //private ObservableCollection<Bitmap> ArcaneMarksField;
    }
}
