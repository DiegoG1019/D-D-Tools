using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items.Info
{
    public record AttackThrow
    {
        public Stats KeyStat { get; init; }
        public Stats SecondaryStat { get; init; }

        public AttackThrow(Stats s) :
            this(s, s)
        { }
        public AttackThrow(Stats s1, Stats s2)
        {
            KeyStat = s1;
            SecondaryStat = s2;
        }
    }
}
