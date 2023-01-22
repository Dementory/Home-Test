using System;
using UnityEngine;

namespace HomeTest
{
    public class PointerClickDetector : MonoBehaviour
    {
        public event Action OnPointerClick;

        void OnMouseDown() => OnPointerClick?.Invoke();
    }
}
