using System.Threading.Tasks;
using UnityEngine;

namespace HomeTest.Animation
{

    [RequireComponent(typeof(CanvasGroup))]
    public class FadeAnimation : UIAnimation
    {
        #region Fields

        [Tooltip("Animation duration in seconds")]
        [SerializeField, Min(0)] private float _duration;

        private CanvasGroup _canvasRenderer;

        #endregion

        #region Initialization

        private void Start() => _canvasRenderer = gameObject.GetComponentWithException<CanvasGroup>();

        #endregion

        public override async void SetActive(bool enabled, bool withoutAnimation)
        {
            int finalGoal = enabled ? 1 : 0;

            if (withoutAnimation)
                SetActiveWithoutAnimation(enabled, finalGoal);

            float frameProgress = Time.deltaTime / _duration;
            frameProgress = enabled ? frameProgress : -frameProgress;

            if (enabled)
                gameObject.SetActive(enabled);

            while (_canvasRenderer.alpha != finalGoal)
            {
                _canvasRenderer.alpha += frameProgress;

                await Task.Yield();
            }

            if (!enabled)
                gameObject.SetActive(enabled);

        }

        private void SetActiveWithoutAnimation(bool enabled, int finalGoal)
        {
            _canvasRenderer.alpha = finalGoal;
            gameObject.SetActive(enabled);
        }

    }
}
