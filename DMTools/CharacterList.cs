using DiegoG.DnDTDesktop.Characters;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DiegoG.DnDTDesktop
{
    [Serializable]
    public class CharacterList : IEnumerable<Character>
    {
        public Dictionary<string, Character> Characters { get; set; } = new Dictionary<string, Character>();
        public void Register(Character chara) => Characters.Add(chara.CharacterFileName, chara);
        public void Unregister(string characterFileName) => Characters.Remove(characterFileName);
        public void Unregister(Character chara) => Characters.Remove(chara.CharacterFileName);

        public IEnumerator<Character> GetEnumerator()
        {
            foreach (var chara in Characters.Values)
                yield return chara;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Character this[string chara]
        {
            get => Characters[chara];
        }
    }
}
