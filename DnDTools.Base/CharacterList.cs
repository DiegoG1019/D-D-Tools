using DiegoG.DnDTools.Base.Characters;
using DiegoG.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DiegoG.DnDTools.Base
{
    [Serializable]
    public class CharacterList : IEnumerable<Character>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ObservableDictionary<string, Character> DictCharacters { get; } = new();
        public void Register(Character chara) => DictCharacters.Add(chara.CharacterFileName, chara);
        public void Unregister(string characterFileName) => DictCharacters.Remove(characterFileName);
        public void Unregister(Character chara) => DictCharacters.Remove(chara.CharacterFileName);
        public bool IsRegistered(string characterFileName) => DictCharacters.ContainsKey(characterFileName);
        public bool IsRegistered(Character chara) => DictCharacters.ContainsKey(chara.CharacterFileName);

        public Character Selected { get; private set; }
        public void Select(Character character)
        {
            if (!IsRegistered(character))
                Register(character);
            Selected = character;
        }
        public void Select(string characterFileName)
            => Selected = this[characterFileName];

        /// <summary>
        /// Unsafe, be sure to also change the character's Filename
        /// </summary>
        /// <param name="chara"></param>
        /// <param name="newname"></param>
        public void ChangeCharacterFileName(Character chara, string newname)
        {
            if (IsRegistered(chara))
                DictCharacters.Remove(chara.CharacterFileName);
            DictCharacters.Add(newname, chara);
        }
        /// <summary>
        /// Unsafe, be sure to also change the character's Filename
        /// </summary>
        /// <param name="characterFileName"></param>
        /// <param name="newname"></param>
        public void ChangeCharacterRegistrationKey(string characterFileName, string newname)
            => ChangeCharacterFileName(this[characterFileName], newname);

        public IEnumerator<Character> GetEnumerator()
        {
            foreach (var chara in DictCharacters.Values)
                yield return chara;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Character this[string chara] => DictCharacters[chara];

        public CharacterList() => DictCharacters.CollectionChanged += DictCharacters_CollectionChanged;

        private void DictCharacters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            => NotifyPropertyChanged(nameof(CharacterList));
    }
}
