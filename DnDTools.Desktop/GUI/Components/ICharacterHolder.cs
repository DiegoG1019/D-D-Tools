using DiegoG.DnDTools.Base.Characters;

namespace DiegoG.DnDTools.Desktop.GUI.Components
{
    public interface ICharacterHolder
    {
        public Character HeldCharacter { get; }
        public void UpdateCharacter();
    }
}
