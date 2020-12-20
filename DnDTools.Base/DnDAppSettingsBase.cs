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
