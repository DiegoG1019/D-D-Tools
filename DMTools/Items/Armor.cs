using DiegoG.Utilities;

namespace DiegoG.DnDTDesktop.Items
{
    public class Armor : Item
    {
        public int Buff { get; set; }
        public ushort MaximumDeterity { get; set; }
        public int Penalty { get; set; }
        public Percentage SpellFailure { get; set; }
        public int SpeedPenalty { get; set; }
    }
}
