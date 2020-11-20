using DiegoG.DnDNetCore.Characters.Complements;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DiegoG.DnDNetCore.Enumerations;

namespace DiegoG.DnDNetCore.GUI.Widgets.Complements
{
    /// <summary>
    /// Interaction logic for SkillInfoColumn.xaml
    /// </summary>
    public partial class SkillInfoColumn
    {
        private int IndexField;
        public int SkillIndex
        {
            get => IndexField;
            set
            {
                IndexField = value;
                UpdateCharacter();
            }
        }
        public Skill HeldSkill => HeldCharacter.Skills[SkillIndex];
        public SkillInfoColumn()
        {
            InitializeComponent();
#if !DESIGN
            InitializeCharacterControl();      
#endif
            StatSelectorCombobox.ItemsSource = StatsCollection;
            StatSelectorCombobox.SelectionChanged += StatSelectorCombobox_SelectionChanged;
            SkillNameTextBox.TextChanged += SkillNameTextBox_TextChanged;
            OtherRanksTextbox.TextChanged += OtherRanksTextbox_TextChanged;
            RanksTextBox.TextChanged += RanksTextBox_TextChanged;
        }

        private void StatSelectorCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var stat = (Stats)StatSelectorCombobox.SelectedIndex;
            StatSelectorCombobox.Text = Settings<Lang>.Current.ShortStatsStrings[stat];
            HeldSkill.KeyStat = stat;
        }

        public override void PaintTheme(Theme theme)
        {
            MainGrid.Background = new SolidColorBrush(theme.CommonElementBackgroundColor);
            foreach (var control in MainGrid.Children)
                (control as Control).PaintControlTheme(theme);
            SkillModifierTextbox.Background = new SolidColorBrush(theme.HighlightedElementBackgroundColor1.Modify(63));

            ArmorPenalizerTextbox.BorderBrush = new SolidColorBrush(theme.HighlightedElementBackgroundColor2);
            ArmorPenalizerTextbox.Background = new SolidColorBrush(theme.HighlightedElementBackgroundColor2.Modify(0x0C));

            StatModifierTextbox.Background = new SolidColorBrush(theme.BorderColor1.Modify(0x0C));

            MiscRanksTextbox.Background = new SolidColorBrush(theme.BorderColor1.Modify(0x0C));
        }

        private readonly List<CheckBox> FlagChecks = new();
        public override void UpdateCharacter()
        {
            SkillNameTextBox.Text = HeldSkill.Name;
            StatSelectorCombobox.SelectedIndex = (int)HeldSkill.KeyStat;
            SkillModifierTextbox.Text = HeldSkill.Modifier.ToString();
            StatModifierTextbox.Text = HeldSkill.ParentStats.Modifier.ToString();
            RanksTextBox.Text = HeldSkill.Rank.ToString();
            MiscRanksTextbox.Text = HeldSkill.MiscRanks.ToString();
            OtherRanksTextbox.Text = HeldSkill.OtherRanks.ToString();
            ArmorPenalizerTextbox.Text = (HeldSkill.PenalizedByArmorFlag ? HeldCharacter.Equipped.ArmorPenalty : 0).ToString();

            FlagChecks.Clear();
            foreach (var (Flag, Value) in HeldSkill.Flags)
            {
                var checkbox = new CheckBox()
                { 
                    Height = 15, 
                    Width = 150, 
                    Content = Convert.ToString(Flag), 
                    IsChecked = Value, 
                    HorizontalContentAlignment = HorizontalAlignment.Center, 
                    HorizontalAlignment = HorizontalAlignment.Center, 
                    VerticalContentAlignment = VerticalAlignment.Center 
                };
                checkbox.Checked += (s, e) => HeldSkill.Flags[Flag] = (bool)checkbox.IsChecked;
                FlagChecks.Add(checkbox);
            }
            FlagsCombobox.ItemsSource = FlagChecks;
        }

        private void SkillNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => HeldSkill.Name = SkillNameTextBox.Text;

        private int OtherRanks_PrevValue = 0;
        private void OtherRanksTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(OtherRanksTextbox.Text, out int result))
            {
                OtherRanks_PrevValue = result;
                HeldSkill.OtherRanks = result;
                return;
            }
            OtherRanksTextbox.Text = OtherRanks_PrevValue.ToString();
        }

        private int RanksTextBox_PrevValue = 0;
        private void RanksTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(RanksTextBox.Text, out int result))
            {
                RanksTextBox_PrevValue = result;
                HeldSkill.Rank = result;
                return;
            }
            RanksTextBox.Text = RanksTextBox_PrevValue.ToString();
        }
    }
}
