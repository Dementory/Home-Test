using UnityEngine;
using HomeTest.Animation;

namespace HomeTest.UIView
{
    public class View : MonoBehaviour
    {
        private UIAnimation _animaiton;

        private void Start() => _animaiton = gameObject.GetComponent<UIAnimation>();

        public void Show(bool immediately = false) => SetActive(true, immediately);

        public void Hide(bool immediately = false) => SetActive(false, immediately);

        private void SetActive(bool enabled, bool withoutAnimation)
        {
            if(_animaiton)
            {
                _animaiton.SetActive(enabled, withoutAnimation);
                return;
            }

            gameObject.SetActive(enabled);
        }
    }
}
