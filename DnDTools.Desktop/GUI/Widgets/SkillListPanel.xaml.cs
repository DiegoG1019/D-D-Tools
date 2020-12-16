using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.Base.Characters.Complements;
using DiegoG.DnDTools.Desktop.GUI.Widgets.Complements;
using DiegoG.Utilities;
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
using DiegoG.WPF;

namespace DiegoG.DnDTools.Desktop.GUI.Widgets
{
    /// <summary>
    /// Interaction logic for SkillListPanel.xaml
    /// </summary>
    public partial class SkillListPanel
    {
        public SkillList Skills => HeldCharacter.Skills;
        public SkillListPanel()
        {
            InitializeComponent();
#if !DESIGN
            InitializeCharacterControl();
            ExtraBaseSkillPointsNumeric.TextChanged += ExtraBaseSkillPointsNumeric_TextChanged;
            ExtraSkillPointsNumeric.TextChanged += ExtraSkillPointsNumeric_TextChanged;
#endif
        }

        private void ExtraSkillPointsNumeric_TextChanged(object sender, TextChangedEventArgs e)
            => Skills.ExtraSkillPoints = int.Parse(ExtraSkillPointsNumeric.Text);

        private void ExtraBaseSkillPointsNumeric_TextChanged(object sender, TextChangedEventArgs e) 
            => Skills.ExtraBaseSkillPoints = int.Parse(ExtraBaseSkillPointsNumeric.Text);

        public override void PaintTheme(Theme theme)
        {
            foreach(var grid in MainGrid.Children)
                if (grid is Grid)
                    foreach (var items in (grid as Grid).Children)
                        (items as Control).PaintControlTheme(theme);
            SkillsPanel.Background = new SolidColorBrush(theme.CommonElementBackgroundColor);
        }
        public override void UpdateCharacter()
        {
            AsyncTaskManager<SkillInfoColumn> TaskMan = new();
            for(int i = 0; i < HeldCharacter.Skills.Count; i++)
                TaskMan.Run ( () => new(){ SkillIndex = i } );

            TotalJobSkillPointsNumeric.SetNumber(Skills.JobSkillPoints);
            AbilityBaseSkillPointsNumeric.SetNumber(Skills.AbilityBaseSkillPoints);
            ExtraAbilitySkillPointsNumeric.SetNumber(Skills.ExtraAbilitySkillPoints);
            ExtraBaseSkillPointsNumeric.SetNumber(Skills.ExtraBaseSkillPoints);
            ExtraSkillPointsNumeric.SetNumber(Skills.ExtraSkillPoints);

            SpentSkillPointsBox.ItemTextBoxText = Skills.SpentSkillPoints.ToString();
            RemainingSkillPointsBox.ItemTextBoxText = Skills.RemainingSkillPoints.ToString();
            TotalSkillPointsBox.ItemTextBoxText = Skills.TotalSkillPoints.ToString();

            JobSkillsMaxRankBox.ItemTextBoxText = Skills.MaxJobSkillRank.ToString();
            OtherSkillsMaxRankBox.ItemTextBoxText = Skills.MaxOtherSkillRank.ToString();
            
            TaskMan.WaitAll();
            foreach (var i in TaskMan.AllResults)
                SkillsPanel.Children.Add(i);
        }
    }
}
