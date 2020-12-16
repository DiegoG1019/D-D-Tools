using DiegoG.DnDTools.Base.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Desktop.GUI.Components
{
    public interface ICharacterHolder
    {
        public Character HeldCharacter { get; }
        public void UpdateCharacter();
    }
}
