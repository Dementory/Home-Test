using UnityEngine;

namespace HomeTest
{
    public class HeightSetterEllement : MonoBehaviour
    {
        [SerializeField] private Transform _content;

        public void SetHeight(float height) => _content.localPosition = new Vector2(_content.localPosition.x, height);
    }
}
