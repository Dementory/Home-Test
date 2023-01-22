using System;
using UnityEngine;

namespace HomeTest.CharacterPage
{

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PointerClickDetector))]
    public class AnimationPlayerOnClick : MonoBehaviour
    {
        [SerializeField] private PointerClickDetector _clickDetector;
        private Animator _animator;

        private const string ON_CLICK_KEYWORD = "On click";

        private void Start()
        {
            _animator = gameObject.GetComponentWithException<Animator>();

            if (!_clickDetector)
                throw new NullReferenceException("Click detector isn't assigned");
        }

        private void OnEnable() => _clickDetector.OnPointerClick += PlayAnimation;

        private void OnDisable() => _clickDetector.OnPointerClick -= PlayAnimation;

        private void PlayAnimation() => _animator.SetTrigger(ON_CLICK_KEYWORD);

    }
}
