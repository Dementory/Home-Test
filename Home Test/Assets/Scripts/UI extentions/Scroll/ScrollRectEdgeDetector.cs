using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomeTest
{

    [RequireComponent(typeof(ScrollRect))]
    public class ScrollRectEdgeDetector : MonoBehaviour
    {
        [Range(0.5f, 1)]
        [SerializeField] private float _topEdgeThreshold;

        [Range(0f, 0.5f)]
        [SerializeField] private float _bottomEdgeThreshold;

        private ScrollRect _scrollRect;

        private bool _reachedTopEdge;
        private bool _reachedBottomEdge;

        public Action OnTopEdgeReach;
        public Action OnBottomEdgeReach;

        private void Start() => _scrollRect = gameObject.GetComponentWithException<ScrollRect>();

        private void Update()
        {
            CheckIfRechedEdge(_topEdgeThreshold, ref _reachedTopEdge, ref OnTopEdgeReach, Side.Top);

            CheckIfRechedEdge(_bottomEdgeThreshold, ref _reachedBottomEdge, ref OnBottomEdgeReach, Side.Bottom);
        }

        private void CheckIfRechedEdge(float edgeThreshold, ref bool reachedEdge, ref Action OnEdgeRech, Side side)
        {
            float verticalPosition = _scrollRect.verticalNormalizedPosition;
            bool reachedThreshold = side == Side.Top ? verticalPosition > edgeThreshold : verticalPosition < edgeThreshold;

            if (reachedThreshold && !reachedEdge)
            {
                OnEdgeRech?.Invoke();

                reachedEdge = true;
            }
            else
            {
                reachedEdge = false;
            }
        }

        private enum Side
        {
            Top,
            Bottom
        }
    }
}
