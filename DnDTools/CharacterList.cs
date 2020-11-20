using DiegoG.DnDNetCore.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DiegoG.DnDNetCore
{
    [Serializable]
    public class CharacterList : IEnumerable<Character>
    {
        private Dictionary<string, Character> DictCharacters { get; set; } = new Dictionary<string, Character>();
        public void Register(Character chara) => DictCharacters.Add(chara.CharacterFileName, chara);
        public void Unregister(string characterFileName) => DictCharacters.Remove(characterFileName);
        public void Unregister(Character chara) => DictCharacters.Remove(chara.CharacterFileName);
        public bool IsRegistered(string characterFileName) => DictCharacters.ContainsKey(characterFileName);
        public bool IsRegistered(Character chara) => DictCharacters.ContainsKey(chara.CharacterFileName);

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
    }
}
