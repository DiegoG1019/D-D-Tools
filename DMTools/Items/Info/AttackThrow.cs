﻿using static DiegoG.DnDTDesktop.Enums;

namespace DiegoG.DnDTDesktop.Items.Info
{
    public class AttackThrow
    {
        public Stats KeyStat { get; set; }
        public Stats SecondaryStat { get; set; }

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
