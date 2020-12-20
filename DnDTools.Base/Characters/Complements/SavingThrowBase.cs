using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static DiegoG.DnDTools.Base.Enumerations;

namespace DiegoG.DnDTools.Base.Characters.Complements
{
    public class SavingThrowBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private readonly List<int> list = new List<int>();
        public int this[SavingThrow index]
        {
            get => list[(int)index];
            set { list[(int)index] = value; NotifyPropertyChanged(); }
        }
        public SavingThrowBase()
        {
            for (int i = 0; i < SavingThrowCount; i++)
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
                chara.SavingThrows[(SavingThrow)i].BasePoints = +list[i];
        }
        public void Add(SavingThrowBase other)
        {
            for (int i = 0; i < SavingThrowCount; i++)
                this.list[i] += other.list[i];
        }
    }
}
