using UnityEngine;
using Zenject;

namespace HomeTest.CharacterPage
{
    public class CharacterPositioner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        [Inject] CharacterSwitcher _characterSwitcher;

        private Character _currentCharacter;
        private GameObject _currentCharacterObject;

        private void OnEnable() => _characterSwitcher.OnCharacterSwitch += PlaceCharacter;

        private void OnDisable() => _characterSwitcher.OnCharacterSwitch -= PlaceCharacter;

        private void PlaceCharacter(Character character)
        {
            if (character == _currentCharacter) return;

            RemoveCurrentCharacter();

            _currentCharacter = character;
            _currentCharacterObject = Instantiate(character.ModelPrefab, _spawnPoint.position, _spawnPoint.rotation);
            _currentCharacterObject.transform.SetParent(_spawnPoint);
        }

        private void RemoveCurrentCharacter()
        {
            if (_currentCharacterObject)
                Destroy(_currentCharacterObject);
        }
    }

}
