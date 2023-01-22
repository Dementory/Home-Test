using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomeTest
{
    public abstract class ListChildrenInteractor : MonoBehaviour
    {
        protected Transform Content;
        protected ScrollRect ScrollRect;
        protected RectTransform ContentRect;

        private void Start()
        {
            Initialize();

            UpdateChildren();
        }

        protected virtual void Initialize()
        {
            ScrollRect = gameObject.GetComponentWithException<ScrollRect>();
            Content = ScrollRect.content;

            if (!Content)
                throw new NullReferenceException("Content in scroll rect isn't assigned");

            ContentRect = Content.gameObject.GetComponentWithException<RectTransform>();

            ScrollRect.onValueChanged.AddListener(delta => UpdateChildren());
        }

        protected abstract void UpdateChildren();
    }
}
