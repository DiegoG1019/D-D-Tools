using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.Utilities.Settings;
using DiegoG.DnDTools.Base;

namespace DiegoG.DnDTools.CLI
{
    public class AppSettings : DnDAppSettingsBase
    {
        public override ulong Version => 0 + base.Version;
    }
}
