using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.Desktop.GUI.Pages;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using DiegoG.WPF;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Desktop.GUI.Widgets
{
    public partial class CharacterDescriptionPanel
    {
        public CharacterDescriptionPanel()
        {
            InitializeComponent();
#if !DESIGN
            InitializeCharacterControl();

            AlignmentBox.ItemDropDownSource = AlignmentsCollection;
            BodyTypeBox.ItemDropDownSource = BodyTypesCollection;
            SizeBox.ItemDropDownSource = SizesCollection;
#endif
            AlignmentBox.SelectionChanged += AlignmentBox_SelectionChanged;
            BodyTypeBox.SelectionChanged += BodyTypeBox_SelectionChanged;
            SizeBox.SelectionChanged += SizeBox_SelectionChanged;
            
            AgeBox.NumericBoxChanged += AgeBox_NumericBoxChanged;
            HeightBox.NumericBoxChanged += HeightBox_NumericBoxChanged;
            WeightBox.NumericBoxChanged += WeightBox_NumericBoxChanged;

            NameTextBox.TextChanged += NameTextBox_TextBoxChanged;
            GenderBox.TextBoxChanged += GenderBox_TextBoxChanged;
            PersonalityBox.TextBoxChanged += PersonalityBox_TextBoxChanged;
            FullNameBox.TextBoxChanged += FullNameBox_TextBoxChanged;
            RaceBox.TextBoxChanged += RaceBox_TextBoxChanged;
            DeityBox.TextBoxChanged += DeityBox_TextBoxChanged;

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

        private void SizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e, int newindex)
            => HeldCharacter.Description.Size = (Sizes)newindex;

        private void BodyTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e, int newindex)
            => HeldCharacter.Description.BodyType = (BodyTypes)newindex;

        private void AlignmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e, int newindex)
            => HeldCharacter.Description.Alignment = (Alignments)newindex;

        private void WeightBox_NumericBoxChanged(object sender, TextChangedEventArgs e, double newnumber)
            => HeldCharacter.Description.Weight[Settings<DnDSettings>.Current.PreferredMassUnit] = (decimal)newnumber;

        private void HeightBox_NumericBoxChanged(object sender, TextChangedEventArgs e, double newnumber)
            => HeldCharacter.Description.Height[Settings<DnDSettings>.Current.PreferredLengthUnit] = (decimal)newnumber;

        private void AgeBox_NumericBoxChanged(object sender, TextChangedEventArgs e, double newnumber)
            => HeldCharacter.Description.Age = (int)newnumber;

        private void DeityBox_TextBoxChanged(object sender, TextChangedEventArgs e, string newtext)
            => HeldCharacter.Description.Deity = newtext;

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
            RaceBox.ItemTextBoxText = HeldCharacter.Description.Race;
            DeityBox.ItemTextBoxText = HeldCharacter.Description.Deity;

            AlignmentBox.ItemDropDownIndex = (int)HeldCharacter.Description.Alignment;
            BodyTypeBox.ItemDropDownIndex = (int)HeldCharacter.Description.BodyType;
            SizeBox.ItemDropDownIndex = (int)HeldCharacter.Description.Size;
            AgeBox.ItemNumericBoxNumber = HeldCharacter.Description.Age;
            
            ExpLevelBox.ItemNumericBoxNumber = HeldCharacter.Experience.Level;
            HeightBox.ItemNumericBoxNumber = (double)HeldCharacter.Description.Height[Settings<DnDSettings>.Current.PreferredLengthUnit];
            WeightBox.ItemNumericBoxNumber = (double)HeldCharacter.Description.Weight[Settings<DnDSettings>.Current.PreferredMassUnit];
            
            EyeColorBox.ItemTextBoxText = HeldCharacter.Description.EyeColor.ToColor().GetName();
            HairColorBox.ItemTextBoxText = HeldCharacter.Description.HairColor.ToColor().GetName();
            SkinColorBox.ItemTextBoxText = HeldCharacter.Description.SkinColor.ToColor().GetName();
        }

        public override void PaintTheme(Theme theme)
        {
            NameTextBox.Foreground = new SolidColorBrush(theme.CommonTextColor);

            GenderBox.PaintTheme(theme);
            PersonalityBox.PaintTheme(theme);
            FullNameBox.PaintTheme(theme);
            ExpLevelBox.PaintTheme(theme);
            RaceBox.PaintTheme(theme);
            AlignmentBox.PaintTheme(theme);
            DeityBox.PaintTheme(theme);
            BodyTypeBox.PaintTheme(theme);
            SizeBox.PaintTheme(theme);
            AgeBox.PaintTheme(theme);
            HeightBox.PaintTheme(theme);
            WeightBox.PaintTheme(theme);
            EyeColorBox.PaintTheme(theme);
            HairColorBox.PaintTheme(theme);
            SkinColorBox.PaintTheme(theme);

            SeparatorBorder.BorderBrush = new SolidColorBrush(theme.BorderColor1);
            SeparatorBorder.BorderThickness = new Thickness(0, theme.BorderThickness1, 0, theme.BorderThickness1);

            IntroButton.BorderBrush = new SolidColorBrush(theme.CommonButtonBorderColor);
            IntroButton.BorderThickness = new Thickness(theme.CommonButtonBorderThickness);
            IntroButton.Background = new SolidColorBrush(theme.CommonButtonBackgroundColor);
            IntroButton.Foreground = new SolidColorBrush(theme.CommonButtonTextColor);

            BioButton.BorderBrush = new SolidColorBrush(theme.CommonButtonBorderColor);
            BioButton.BorderThickness = new Thickness(theme.CommonButtonBorderThickness);
            BioButton.Background = new SolidColorBrush(theme.CommonButtonBackgroundColor);
            BioButton.Foreground = new SolidColorBrush(theme.CommonButtonTextColor);

            NotesButton.BorderBrush = new SolidColorBrush(theme.CommonButtonBorderColor);
            NotesButton.BorderThickness = new Thickness(theme.CommonButtonBorderThickness);
            NotesButton.Background = new SolidColorBrush(theme.CommonButtonBackgroundColor);
            NotesButton.Foreground = new SolidColorBrush(theme.CommonButtonTextColor);

            Background = new SolidColorBrush(theme.CommonWidgetBackgroundColor);
        }
    }
}
