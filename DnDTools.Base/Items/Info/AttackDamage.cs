using DiegoG.DnDTools.Base.Other;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items.Info
{
    public class AttackDamage
    {
        private readonly Dice[] die;
        public Dice this[Sizes ind]
        {
            get => die[(int)ind];
            set => die[(int)ind] = value;
        }
        public AttackDamage()
        {
            die = new Dice[SizeCount];
            for (int i = 0; i < SizeCount; i++)
                die[i] = Dice.NoDice;
        }
        public AttackDamage(Dice[] die) => this.die = die;

        public AttackDamage(Dice? fine, Dice? diminutive, Dice? tiny, Dice? small, Dice? medium, Dice? large, Dice? huge, Dice? gargantuan, Dice? colossal)
        {
            Dice?[] dices = new Dice?[] { fine, diminutive, tiny, small, medium, large, huge, gargantuan, colossal };
            for (int i = 0; i < die.Length; i++)
            {
                if (dices[i] is null)
                    die[i] = Dice.NoDice;
                else
                    die[i] = (Dice)dices[i];
            }
        }
    }
}
