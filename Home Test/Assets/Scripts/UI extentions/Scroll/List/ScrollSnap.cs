using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HomeTest
{
    [RequireComponent(typeof(ScrollRect))]
    public class ScrollSnap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float _snapDuration;

        private ScrollRect _scrollRect;
        private LayoutGroup _layoutGroup;

        private bool _isPointerClicked;

        private void Start()
        {
            _scrollRect = gameObject.GetComponentWithException<ScrollRect>();

            if (_scrollRect.content)
                _layoutGroup = _scrollRect.content.GetComponent<LayoutGroup>();

            _scrollRect.onValueChanged.AddListener(delta => Snap());
        }

        private void Snap()
        {
            if (_isPointerClicked || !_scrollRect.content) return;

            int childrenAmount = _scrollRect.content.childCount - 1;

            if (childrenAmount < 1) return;

            float normalizedGapDistance = 1 / (float)childrenAmount;
            float normalizedPosition = _scrollRect.horizontalNormalizedPosition;

            float scrollValue = Mathf.Round(normalizedPosition / normalizedGapDistance) / (float)childrenAmount;

            _scrollRect.SetValue(new Vector2(scrollValue, 0), _layoutGroup);
        }

        public void OnPointerDown(PointerEventData eventData) => _isPointerClicked = true;

        public void OnPointerUp(PointerEventData eventData) => _isPointerClicked = false;
    }
}
