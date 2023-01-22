using UnityEngine;

namespace HomeTest
{
    public class ParabolicHeightSetterBehaviour : HeightSetterBehaviour
    {
        public override float GetHeight(float horizontalNormalizedDistance) => Mathf.Pow(horizontalNormalizedDistance, 2);
    }
}
