using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.Utilities.Settings;

namespace DiegoG.DnDTools.Base
{
    public abstract class DnDAppSettingsBase : ApplicationSettings
    {
        public override ulong Version => 0 + base.Version;

        public string DataDirectory { get; set; } = null;
        public string Lang { get; set; } = "eng";
        public string GameSettingsProfile { get; set; } = "default";
    }
}
