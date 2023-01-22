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

        private bool _isPointerClicked;

        private void Start() => _scrollRect = gameObject.GetComponentWithException<ScrollRect>();

        private void LateUpdate() => Snap();

        private void Snap()
        {
            if (_isPointerClicked || !_scrollRect.content) return;

            float childrenAmount = _scrollRect.content.childCount - 1;

            if (childrenAmount < 1) return;

            float normalizedGapDistance = 1 / (float)childrenAmount;
            float normalizedPosition = _scrollRect.horizontalNormalizedPosition;

            float targetNormalizedPosition = Mathf.Round(normalizedPosition / normalizedGapDistance) / (float)childrenAmount;

            float scrollStep = Time.deltaTime / _snapDuration;
            float scrollValue = Mathf.LerpUnclamped(normalizedPosition, targetNormalizedPosition, scrollStep);

            _scrollRect.normalizedPosition = new Vector2(scrollValue, 0);
        }

        public void OnPointerDown(PointerEventData eventData) => _isPointerClicked = true;

        public void OnPointerUp(PointerEventData eventData) => _isPointerClicked = false;
    }
}
