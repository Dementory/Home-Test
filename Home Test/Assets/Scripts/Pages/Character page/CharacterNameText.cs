using TMPro;
using UnityEngine;
using Zenject;

namespace HomeTest.CharacterPage
{

    [RequireComponent(typeof(TMP_Text))]
    public class CharacterNameText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        [Inject] CharacterSwitcher _characterSwitcher;

        private void OnEnable() => _characterSwitcher.OnCharacterSwitch += SetName;

        private void OnDisable() => _characterSwitcher.OnCharacterSwitch -= SetName;

        private void SetName(Character character) => _text.text = character.Name;
    }
}
