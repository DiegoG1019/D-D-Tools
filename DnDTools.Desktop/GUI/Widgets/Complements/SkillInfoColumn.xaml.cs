using DiegoG.DnDTools.Base;
using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.Utilities.Settings;
using DiegoG.WPF;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Desktop.GUI.Widgets.Complements
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
#if !DESIGN
                UpdateCharacter();
#endif
            }
        }
        public Skill HeldSkill => HeldCharacter.Skills[SkillIndex];
        public SkillInfoColumn()
        {
            InitializeComponent();
#if !DESIGN
            InitializeCharacterControl();
            StatSelectorCombobox.ItemsSource = StatsStringCollection;
#endif
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
            ArmorPenalizerTextbox.Text = (HeldSkill.PenalizedByArmor ? HeldCharacter.Equipped.ArmorPenalty : 0).ToString();

            FlagChecks.Clear();
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
