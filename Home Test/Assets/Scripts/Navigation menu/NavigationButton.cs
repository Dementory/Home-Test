using HomeTest.UIView;
using UnityEngine;
using UnityEngine.UI;

namespace HomeTest
{

    [RequireComponent(typeof(Button))]
    public class NavigationButton : MonoBehaviour
    {
        [SerializeField] private View _view;

        private Button _button;

        private void Start() => AssignButton();

        private void AssignButton()
        {
            if (!_button)
                _button = gameObject.GetComponentWithException<Button>();
        }

        public void RewriteButtonOpenAction(IViewSwitcher viewSwitcher)
        {
            AssignButton();

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => viewSwitcher.Show(_view));
        }

    }
}
