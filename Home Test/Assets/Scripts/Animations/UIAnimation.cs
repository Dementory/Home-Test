using UnityEngine;

namespace HomeTest.Animation
{
    public abstract class UIAnimation : MonoBehaviour
    {
        public abstract void SetActive(bool enabled, bool withoutAnimation);
    }
}
