using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace HomeTest.CharacterPage
{
    public class CharactersWindow : MonoBehaviour
    {
        [SerializeField] private Button _letSwitchButton;
        [SerializeField] private Button _rightSwitchButton;

        [Inject] private CharacterSwitcher _characterSwitcher;

        private void Start()
        {
            _letSwitchButton.onClick.AddListener(() => _characterSwitcher.PreviousCharacter());
            _rightSwitchButton.onClick.AddListener(() => _characterSwitcher.NextCharacter());
        }
    }
}
