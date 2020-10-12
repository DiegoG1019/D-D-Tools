using DiegoG.DnDTDesktop.Characters;
using DiegoG.DnDTDesktop.Properties;
using DiegoG.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;
using static DiegoG.DnDTDesktop.Enums;
using static System.Windows.Forms.CheckedListBox;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public partial class CharacterInfoHeader : UserControl, ICharacterGUIElement
    {
        public static ObjectCollection TypeList { get; private set; }
        public static ObjectCollection SizeList { get; private set; }
        public static ObjectCollection AlignmentList { get; private set; }

        public ICharacterGUI ParentCharacterGUI => (ICharacterGUI) Parent;
        public Character HeldCharacter => ParentCharacterGUI.HeldCharacter;

        static CharacterInfoHeader()
        {
            foreach (var i in Enum.GetNames(typeof(BodyTypes)))
                TypeList.Add(Resources.ResourceManager.GetString(i));
            foreach (var i in Enum.GetNames(typeof(Sizes)))
                SizeList.Add(Resources.ResourceManager.GetString(i));
            foreach (var i in Enum.GetNames(typeof(Alignments)))
                AlignmentList.Add(Resources.ResourceManager.GetString(i));
        }
        public CharacterInfoHeader()
        {
            InitializeComponent();

            if (!(Parent is ICharacterGUI) && !(Parent is ICharacterGUIElement))
                throw new Exception("Parent must be implement ICharacterGUI");

            ParentCharacterGUI.HeldCharacterChanged += CharacterInfoHeader_HeldCharacterChanged;
            TypeListBox.Items.AddRange(TypeList);
            SizeListBox.Items.AddRange(SizeList);
            AlignmentListBox.Items.AddRange(AlignmentList);

            CharacterInfoHeader_HeldCharacterChanged();

            LevelTextBox.BackColor = Color.Black;

            NameTextBox.TextChanged += NameTextBox_TextChanged;
            FullNameTextBox.TextChanged += FullNameTextBox_TextChanged;
            GenderTextBox.TextChanged += GenderTextBox_TextChanged;
            CharacterFileNameBox.TextChanged += CharacterFileNameBox_TextChanged;
            BioTextBox.TextChanged += BioTextBox_TextChanged;
            RaceTextBox.TextChanged += RaceTextBox_TextChanged;
            DeityTextBox.TextChanged += DeityTextBox_TextChanged;
            AgeTextBox.TextChanged += AgeTextBox_TextChanged;
            HeightTextBox.TextChanged += HeightTextBox_TextChanged;
            WeightTextBox.TextChanged += WeightTextBox_TextChanged;
        }

        private void WeightTextBox_TextChanged(object sender, EventArgs e)
        {
            var str = WeightTextBox.Text.Substring(0, WeightTextBox.Text.Length - Mass.ShortUnits[Mass.Units.Kilogram].Length);
            HeldCharacter.Description.Weight = new Mass(Convert.ToDecimal(str), Mass.Units.Kilogram);
        }
        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            var str = HeightTextBox.Text.Substring(0, HeightTextBox.Text.Length - Length.ShortUnits[Length.Units.Meter].Length);
            HeldCharacter.Description.Height = new Length(Convert.ToDecimal(str), Length.Units.Meter);
        }
        private void AgeTextBox_TextChanged(object sender, EventArgs e)
        {
            var str = AgeTextBox.Text.Substring(0, AgeTextBox.Text.Length - Resources.Years_word.Length + 1);
            HeldCharacter.Description.Age = Convert.ToInt32(str);
        }
        private void DeityTextBox_TextChanged(object sender, EventArgs e) => HeldCharacter.Description.Deity = DeityTextBox.Text;
        private void RaceTextBox_TextChanged(object sender, EventArgs e) => HeldCharacter.Description.Race = RaceTextBox.Text;
        private void BioTextBox_TextChanged(object sender, EventArgs e) => HeldCharacter.Description.Bio = BioTextBox.Text;
        private void CharacterFileNameBox_TextChanged(object sender, EventArgs e) => HeldCharacter.CharacterFileName = CharacterFileNameBox.Text;
        private void GenderTextBox_TextChanged(object sender, EventArgs e) => HeldCharacter.Description.Gender = GenderTextBox.Text;
        private void FullNameTextBox_TextChanged(object sender, EventArgs e) => HeldCharacter.Description.Fullname = FullNameTextBox.Text;
        private void NameTextBox_TextChanged(object sender, EventArgs e) => HeldCharacter.Description.Name = NameTextBox.Text;

        private void CharacterInfoHeader_HeldCharacterChanged()
        {
            NameTextBox.Text = HeldCharacter.Description.Name;
            FullNameTextBox.Text = HeldCharacter.Description.Fullname;
            GenderTextBox.Text = HeldCharacter.Description.Gender;
            CharacterFileNameBox.Text = HeldCharacter.CharacterFileName;
            BioTextBox.Text = HeldCharacter.Description.Bio;
            LevelTextBox.Text = $"{HeldCharacter.Jobs.AllLevels}";
            RaceTextBox.Text = HeldCharacter.Description.Race;
            DeityTextBox.Text = HeldCharacter.Description.Deity;
            AgeTextBox.Text = $"{HeldCharacter.Description.Age} {Resources.Years_word}";
            HeightTextBox.Text = $"{HeldCharacter.Description.Height.Meter:#.##}{Length.ShortUnits[Length.Units.Meter]}";
            WeightTextBox.Text = $"{HeldCharacter.Description.Weight.Kilogram:#.##}{Mass.ShortUnits[Mass.Units.Kilogram]}";

            EyeColorColorLabel.BackColor = HeldCharacter.Description.Eyes;
            SkinColorColorLabel.BackColor = HeldCharacter.Description.Skin;
            HairColorColorLabel.BackColor = HeldCharacter.Description.Hair;

            EyeColorColorLabel.ForeColor = Utilities.Other.GetOppositeColor(HeldCharacter.Description.Eyes);
            SkinColorColorLabel.ForeColor = Utilities.Other.GetOppositeColor(HeldCharacter.Description.Skin);
            HairColorColorLabel.ForeColor = Utilities.Other.GetOppositeColor(HeldCharacter.Description.Hair);

            EyeColorColorLabel.Text = Utilities.Other.GetColorName(HeldCharacter.Description.Eyes);
            SkinColorColorLabel.Text = Utilities.Other.GetColorName(HeldCharacter.Description.Skin);
            HairColorColorLabel.Text = Utilities.Other.GetColorName(HeldCharacter.Description.Hair);

            AlignmentListBox.SelectedIndex = Convert.ToInt32(HeldCharacter.Description.Alignment);
            SizeListBox.SelectedIndex = Convert.ToInt32(HeldCharacter.Description.Size);
            TypeListBox.SelectedIndex = Convert.ToInt32(HeldCharacter.Description.BodyType);
        }
    }
}
