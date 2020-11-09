using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.DnDNetCore
{
    public class AppSettings : ApplicationSettings
    {
        public override ulong Version { get; } = 0;

        public string DataDirectory { get; set; } = null;
        public string Theme { get; set; } = "default";
        public string Lang { get; set; } = "eng";
        public string GameSettingsProfile { get; set; } = "default";
    }
}
