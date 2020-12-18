using DiegoG.DnDTools.Base;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDTools.Desktop
{
    public class AppSettings : DnDAppSettingsBase
    {
        public override ulong Version => 0 + base.Version;
        public string Theme { get; set; } = "default";
    }
}
