using UnityEngine;
using UnityEngine.UI;

namespace HomeTest
{
    public static class ScrollUtilities
    {
        public static void SetValue(this ScrollRect scroll, Vector2 normalizedPosition, LayoutGroup layoutGroup = null)
        {
            RectTransform scrollContent = scroll.content.GetComponent<RectTransform>();

            RectOffset padding = new RectOffset();

            if (layoutGroup)
                padding = layoutGroup.padding;

            Vector2 sizeDelta = scrollContent.sizeDelta;
            sizeDelta -= new Vector2(Mathf.Abs(padding.left) + Mathf.Abs(padding.right), Mathf.Abs(padding.top) + Mathf.Abs(padding.bottom));

            float xPosiiton = GetAxisPosition(normalizedPosition.x, sizeDelta.x, scrollContent.anchoredPosition.x, scroll.horizontal);
            float yPosition = GetAxisPosition(normalizedPosition.y, sizeDelta.y, scrollContent.anchoredPosition.y, scroll.vertical);

            Vector2 position = new Vector2(xPosiiton, yPosition);
            scrollContent.anchoredPosition = position;

            float GetAxisPosition(float normalizedPosition, float size, float anchoredPosition, bool enabled) => enabled ? size * -normalizedPosition : anchoredPosition;
        }
    }
}
