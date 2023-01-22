using System;
using UnityEngine;

namespace HomeTest.CharacterPage
{
    public abstract class CharacterSwitcher : MonoBehaviour
    {
        public event Action<Character> OnCharacterSwitch;

        public abstract void NextCharacter();

        public abstract void PreviousCharacter();

        protected void OnCharacterSwitchInvoke(Character character) => OnCharacterSwitch?.Invoke(character);
    }
}
