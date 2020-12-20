using DiegoG.DnDTools.Base.Characters;
using DiegoG.DnDTools.Desktop.GUI.Pages;
using DiegoG.Utilities.Settings;
using DiegoG.WPF;
using Serilog;
using System;
using System.Windows.Controls;

namespace DiegoG.DnDTools.Desktop.GUI.Components
{
    public abstract class CharacterUserControl : UserControl, IThemeable, ICharacterHolder
    {
        public CharacterSheet CharacterSheet { get; private set; }
        public Character HeldCharacter => CharacterSheet.HeldCharacter;
        public void InitializeCharacterControl()
        {
            CharacterSheet = this.GetParent<CharacterSheet>();
            if (CharacterSheet == null)
            {
                var ne = new Exception("This widget does not belong to a CharacterSheet");
                Log.Fatal(ne.ToString());
                throw ne;
            }
            UpdateCharacter();
            PaintTheme(Settings<Theme>.Current);
        }
        public abstract void UpdateCharacter();
        public abstract void PaintTheme(Theme theme);
    }
}
