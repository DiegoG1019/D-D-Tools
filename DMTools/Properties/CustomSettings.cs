using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Properties
{
    internal sealed partial class Settings
    {
        public Verbosity Verbosity
        {
            get => (Verbosity)___Vb;
            set => ___Vb = (int)value;
        }
    }
}
