using DiegoG.Utilities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.DnDTDesktop.Enumerations;

namespace DiegoG.DnDTDesktop.Characters.Complements
{
    public class SavingThrowBase
    {
        private readonly List<int> list = new List<int>();
        public int this[SavingThrow index]
        {
            get => list[(int)index];
            set => list[(int)index] = value;
        }
        public SavingThrowBase()
        {
            for(int i = 0; i < SavingThrowCount; i++)
                list.Add(0);
        }
        private CharacterStat<SavingThrow, CharacterSavingThrowProperty> ToCharacterSavingThrow(Character chara)
        {
            var cst = new CharacterStat<SavingThrow, CharacterSavingThrowProperty>(chara.CharacterFileName);
            for (int i = 0; i < SavingThrowCount; i++)
                cst[(SavingThrow)i].BasePoints = list[i];
            return cst;
        }
        public void ReplaceCharacterSavingThrow(Character chara) => chara.SavingThrows = ToCharacterSavingThrow(chara);
        public void AddCharacterSavingThrow(Character chara)
        {
            for (int i = 0; i < SavingThrowCount; i++)
                chara.SavingThrows[(SavingThrow)i].BasePoints =+ list[i];
        }
        public void Add(SavingThrowBase other)
        {
            for (int i = 0; i < SavingThrowCount; i++)
                this.list[i] += other.list[i];
        }
    }
}
