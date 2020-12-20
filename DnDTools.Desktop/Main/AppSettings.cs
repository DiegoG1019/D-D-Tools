using DiegoG.DnDTools.Base;

namespace DiegoG.DnDTools.Desktop
{
    public class AppSettings : DnDAppSettingsBase
    {
        public override ulong Version => 0 + base.Version;
        public string Theme { get; set; } = "default";
    }
}
