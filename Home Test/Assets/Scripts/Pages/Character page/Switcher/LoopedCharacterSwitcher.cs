using UnityEngine;

namespace HomeTest.CharacterPage
{
    public class LoopedCharacterSwitcher : CharacterSwitcher
    {
        [SerializeField] private Character[] _characters;

        private int _currentCharacterId;

        private void Start() => SelectCharacter();            

        public override void NextCharacter()
        {
            _currentCharacterId++;

            SelectCharacter();
        }

        public override void PreviousCharacter()
        {
            _currentCharacterId--;

            SelectCharacter();
        }

        private void SelectCharacter()
        {
            int id = Mathf.Abs(_currentCharacterId) % _characters.Length;

            OnCharacterSwitchInvoke(_characters[id]);
        }

    }
}
