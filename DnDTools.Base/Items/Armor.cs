using DiegoG.DnDTools.Base.Other;
using DiegoG.Utilities;

namespace DiegoG.DnDTools.Base.Items
{
    public class Armor : Item
    {
        public int Protection { get; set; } = 0;
        public ushort MaximumDeterity { get; set; } = 0;
        public int Penalty { get; set; } = 0;
        public Percentage SpellFailure { get; set; } = new Percentage(0);
        public int SpeedPenalty { get; set; } = 0;
        public Armor() { }
        public Armor(NameDesc nameDesc) : base(nameDesc) { }
    }
}
