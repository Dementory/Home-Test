using UnityEngine;

namespace HomeTest
{
    public class ListHeightSetter : ListChildrenInteractor
    {
        [SerializeField] private float _minHeight;

        private HeightSetterBehaviour _heightSetterBehaviour = new ParabolicHeightSetterBehaviour();

        protected override void UpdateChildren() => UpdateHeight();

        private void UpdateHeight()
        {
            float screenWidth = Screen.width;
            float centerPoint = screenWidth / 2;

            float contentWidth = ContentRect.sizeDelta.x;

            int childAmount = Content.childCount;

            foreach (Transform child in Content)
            {
                if (!child.gameObject.TryGetComponent(out HeightSetterEllement positionerFollower)) continue;

                float cardNormalizedDistance = contentWidth == 0 ? 1 : Mathf.Abs(child.position.x - centerPoint) / (contentWidth / childAmount);

                positionerFollower.SetHeight(_minHeight * _heightSetterBehaviour.GetHeight(cardNormalizedDistance));
            }
        }
    }
}
