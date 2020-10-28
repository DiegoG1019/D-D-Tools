using DiegoG.DnDTDesktop.Other;
using static DiegoG.DnDTDesktop.Enumerations;

namespace DiegoG.DnDTDesktop.Items.Info
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
    }
}
