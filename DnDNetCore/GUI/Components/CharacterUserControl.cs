using DiegoG.DnDNetCore.Characters;
using DiegoG.DnDNetCore.GUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiegoG.DnDNetCore.GUI.Components
{
    public abstract class CharacterUserControl : UserControl
    {
        public CharacterSheet CharacterSheet { get; private set; }
        public Character HeldCharacter => CharacterSheet.HeldCharacter;
        public void InitializeCharacterControl()
        {
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is CharacterSheet))
            {
                try
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }
                catch (InvalidOperationException e)
                {
                    throw new Exception("This widget does not belong to a CharacterSheet", e);
                }
            }
            CharacterSheet = parent as CharacterSheet;

            UpdateCharacter();
            PaintTheme();
        }
        public abstract void UpdateCharacter();
        public abstract void PaintTheme();
    }
}
