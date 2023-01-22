using System.Collections.Generic;
using HomeTest.UIView;
using UnityEngine;

namespace HomeTest
{
    public class NavigationMenu : MonoBehaviour
    {
        [SerializeField] private List<NavigationButton> _navigationButtons = new List<NavigationButton>();

        private IViewSwitcher _viewSwitcher;

        private void Start()
        {
            _viewSwitcher = gameObject.GetComponentWithException<IViewSwitcher>();

            RewriteButtonsOpenAction();
        }

        private void RewriteButtonsOpenAction()
        {
            foreach (NavigationButton navigationButton in _navigationButtons)
                navigationButton.RewriteButtonOpenAction(_viewSwitcher);
        }

    }
}
