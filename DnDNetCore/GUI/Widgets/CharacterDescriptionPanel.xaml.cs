using DiegoG.DnDNetCore.Characters;
using DiegoG.DnDNetCore.GUI.Pages;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiegoG.DnDNetCore.GUI.Widgets
{
    public partial class CharacterDescriptionPanel
    {
        public CharacterDescriptionPanel()
        {
            InitializeComponent();
            InitializeCharacterControl();

            NameTextBox.TextChanged += NameTextBox_TextBoxChanged;
            GenderBox.TextBoxChanged += GenderBox_TextBoxChanged;
            PersonalityBox.TextBoxChanged += PersonalityBox_TextBoxChanged;
            FullNameBox.TextBoxChanged += FullNameBox_TextBoxChanged;
            RaceBox.TextBoxChanged += RaceBox_TextBoxChanged;
            AlignmentBox.TextBoxChanged += AlignmentBox_TextBoxChanged;
            DeityBox.TextBoxChanged += DeityBox_TextBoxChanged;
            BodyTypeBox.TextBoxChanged += BodyTypeBox_TextBoxChanged;
            SizeBox.TextBoxChanged += SizeBox_TextBoxChanged;
            AgeBox.TextBoxTextChanged += AgeBox_TextBoxTextChanged;
            HeightBox.TextBoxTextChanged += HeightBox_TextBoxTextChanged;
            WeightBox.TextBoxTextChanged += WeightBox_TextBoxTextChanged;
            EyeColorBox.TextBoxChanged += EyeColorBox_TextBoxChanged;
            HairColorBox.TextBoxChanged += HairColorBox_TextBoxChanged;
            SkinColorBox.TextBoxChanged += SkinColorBox_TextBoxChanged;

            IntroButton.Click += IntroButton_Click;
            BioButton.Click += BioButton_Click;
            NotesButton.Click += NotesButton_Click;
        }

        private void NotesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
#warning Not Implemented, this should display a new window or widget or smth
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void BioButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
#warning Not Implemented, this should display a new window or widget or smth
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void IntroButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
#warning Not Implemented, this should display a new window or widget or smth
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void SkinColorBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
        {
#warning Not Implemented, this should display a color selection box, also prolly make a new control that acts like a button but shows up a color selection box
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void HairColorBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
        {
#warning Not Implemented, this should display a color selection box, also prolly make a new control that acts like a button but shows up a color selection box
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void EyeColorBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
        {
#warning Not Implemented, this should display a color selection box, also prolly make a new control that acts like a button but shows up a color selection box
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void WeightBox_TextBoxTextChanged(object sender, TextChangedEventArgs e, decimal newnumber)
            => HeldCharacter.Description.Weight[Settings<DnDSettings>.Current.PreferredMassUnit] = newnumber;

        private void HeightBox_TextBoxTextChanged(object sender, TextChangedEventArgs e, decimal newnumber)
            => HeldCharacter.Description.Height[Settings<DnDSettings>.Current.PreferredLengthUnit] = newnumber;

        private void AgeBox_TextBoxTextChanged(object sender, TextChangedEventArgs e, decimal newnumber)
            => HeldCharacter.Description.Age = (int)newnumber;

        private void SizeBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
        {
#warning Not Implemented, this should display a dropdown list for all sizes, prolly make a new user control
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }


        private void BodyTypeBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
        {
#warning Not Implemented, this should display a dropdown list for all body types, prolly make a new user control
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void DeityBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
            => HeldCharacter.Description.Deity = newtext;

        private void AlignmentBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
        {
#warning Not Implemented, this should display a dropdown list for all alignments, prolly make a new user control
#if !DEBUG
            throw new NotImplementedException();
#else
            App.NotImplementedMessageBox();
#endif
        }

        private void RaceBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
            => HeldCharacter.Description.Race = newtext;

        private void FullNameBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
            => HeldCharacter.Description.Fullname = newtext;

        private void PersonalityBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
            => HeldCharacter.Description.Personality = newtext;

        private void GenderBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
            => HeldCharacter.Description.Gender = newtext;

        private void NameTextBox_TextBoxChanged(object sender, TextChangedEventArgs e)
            => HeldCharacter.Description.Name = NameTextBox.Text;

        public override void UpdateCharacter()
        {
            NameTextBox.Text = HeldCharacter.Description.Name;
            GenderBox.ItemTextBoxText = HeldCharacter.Description.Gender;
            PersonalityBox.ItemTextBoxText = HeldCharacter.Description.Personality;
            FullNameBox.ItemTextBoxText = HeldCharacter.Description.Fullname;
            ExpLevelBox.ItemTextBoxText = HeldCharacter.Experience.Level;
            RaceBox.ItemTextBoxText = HeldCharacter.Description.Race;
            AlignmentBox.ItemTextBoxText = Settings<Lang>.Current.AlignmentStrings[HeldCharacter.Description.Alignment];
            DeityBox.ItemTextBoxText = HeldCharacter.Description.Deity;
            BodyTypeBox.ItemTextBoxText = Settings<Lang>.Current.BodyTypeStrings[HeldCharacter.Description.BodyType];
            SizeBox.ItemTextBoxText = Settings<Lang>.Current.SizeStrings[HeldCharacter.Description.Size];
            AgeBox.ItemTextBoxText = HeldCharacter.Description.Age;
            HeightBox.ItemTextBoxText = HeldCharacter.Description.Height[Settings<DnDSettings>.Current.PreferredLengthUnit];
            WeightBox.ItemTextBoxText = HeldCharacter.Description.Weight[Settings<DnDSettings>.Current.PreferredMassUnit];
            EyeColorBox.ItemTextBoxText = HeldCharacter.Description.EyeColor.GetColorName();
            HairColorBox.ItemTextBoxText = HeldCharacter.Description.HairColor.GetColorName();
            SkinColorBox.ItemTextBoxText = HeldCharacter.Description.SkinColor.GetColorName();
        }

        public override void PaintTheme()
        {
            NameTextBox.Foreground = new SolidColorBrush(Settings<Theme>.Current.CommonTextColor);
            GenderBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            PersonalityBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            FullNameBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            ExpLevelBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            RaceBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            AlignmentBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            DeityBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            BodyTypeBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            SizeBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            AgeBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            HeightBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            WeightBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            EyeColorBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            HairColorBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;
            SkinColorBox.ForegroundColor = Settings<Theme>.Current.CommonTextColor;

            GenderBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            PersonalityBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            FullNameBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            ExpLevelBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            RaceBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            AlignmentBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            DeityBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            BodyTypeBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            SizeBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            AgeBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            HeightBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            WeightBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            EyeColorBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            HairColorBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;
            SkinColorBox.SeparatorBorderColor = Settings<Theme>.Current.BorderColor2;

            GenderBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            PersonalityBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            FullNameBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            ExpLevelBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            RaceBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            AlignmentBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            DeityBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            BodyTypeBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            SizeBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            AgeBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            HeightBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            WeightBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            EyeColorBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            HairColorBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;
            SkinColorBox.SeparatorBorderThickness = Settings<Theme>.Current.BorderThickness2;

            SeparatorBorder.BorderBrush = new SolidColorBrush(Settings<Theme>.Current.BorderColor1);
            SeparatorBorder.BorderThickness = new Thickness(0, Settings<Theme>.Current.BorderThickness1, 0, Settings<Theme>.Current.BorderThickness1);

            IntroButton.BorderBrush = new SolidColorBrush(Settings<Theme>.Current.CommonButtonBorderColor);
            IntroButton.BorderThickness = new Thickness(Settings<Theme>.Current.CommonButtonBorderThickness);
            IntroButton.Background = new SolidColorBrush(Settings<Theme>.Current.CommonButtonBackgroundColor);
            IntroButton.Foreground = new SolidColorBrush(Settings<Theme>.Current.CommonButtonTextColor);

            BioButton.BorderBrush = new SolidColorBrush(Settings<Theme>.Current.CommonButtonBorderColor);
            BioButton.BorderThickness = new Thickness(Settings<Theme>.Current.CommonButtonBorderThickness);
            BioButton.Background = new SolidColorBrush(Settings<Theme>.Current.CommonButtonBackgroundColor);
            BioButton.Foreground = new SolidColorBrush(Settings<Theme>.Current.CommonButtonTextColor);

            NotesButton.BorderBrush = new SolidColorBrush(Settings<Theme>.Current.CommonButtonBorderColor);
            NotesButton.BorderThickness = new Thickness(Settings<Theme>.Current.CommonButtonBorderThickness);
            NotesButton.Background = new SolidColorBrush(Settings<Theme>.Current.CommonButtonBackgroundColor);
            NotesButton.Foreground = new SolidColorBrush(Settings<Theme>.Current.CommonButtonTextColor);

            Background = new SolidColorBrush(Settings<Theme>.Current.CommonBackgroundColor);
        }
    }
}
