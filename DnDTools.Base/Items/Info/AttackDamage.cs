using DiegoG.DnDTools.Base.Other;
using System.Collections.Generic;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Items.Info
{
    public record AttackDamage
    {
        private readonly Dice[] die;
        public Dice this[Sizes ind] => die[(int)ind];

        public Dice Fine       => this[Sizes.Fine];
        public Dice Diminutive => this[Sizes.Diminutive];
        public Dice Tiny       => this[Sizes.Tiny];
        public Dice Small      => this[Sizes.Small];
        public Dice Medium     => this[Sizes.Medium];
        public Dice Large      => this[Sizes.Large];
        public Dice Huge       => this[Sizes.Huge];
        public Dice Gargantuan => this[Sizes.Gargantuan];
        public Dice Colossal   => this[Sizes.Colossal];

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
