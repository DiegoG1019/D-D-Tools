﻿using DiegoG.DnDTDesktop.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiegoG.DnDTDesktop.GUI.Elements
{
    public interface ICharacterGUI
    {
        Character HeldCharacter { get; }
        event Action HeldCharacterChanged;
    }
}
