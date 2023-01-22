using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomeTest
{

    [RequireComponent(typeof(ScrollRect))]
    public class HorizontalScrollScaler : ListChildrenInteractor
    {
        [Min(0)] [SerializeField] private float _scaleIntensity;
        [Range(0, 1)] [SerializeField] private float _minScale;

        protected override void UpdateChildren() => UpdateScale();

        private void UpdateScale()
        {
            float screenWidth = Screen.width;
            float centerPoint = screenWidth / 2;

            float contentWidth = ContentRect.sizeDelta.x;

            foreach (Transform child in Content)
            {
                float cardNormalizedDistance = contentWidth == 0 ? 1 : Mathf.Abs(child.position.x - centerPoint) / contentWidth;
                float cardInversedNormalizedDistance = 1 - cardNormalizedDistance;

                float scale = cardInversedNormalizedDistance + cardNormalizedDistance * _minScale;
                scale -= Mathf.Clamp01((scale - _minScale) * cardNormalizedDistance * _scaleIntensity);

                child.localScale = Vector3.one * scale;
            }
        }
    }
}
