using System;
using System.Collections.Generic;
using UnityEngine;

namespace HomeTest.UIView
{
    public class ViewSwitcher : MonoBehaviour, IViewSwitcher
    {
        [SerializeField] private View _startView;
        [SerializeField] private List<View> _views = new List<View>();

        private View _currentView;

        #region Initialization

        private void Start()
        {
            HideAllViews();

            SetUpStartView();
        }

        private void HideAllViews()
        {
            if (_views.Count == 0) return;

            foreach (View view in _views)
                view.Hide(true);
        }

        private void SetUpStartView()
        {
            if (!_startView)
                throw new NullReferenceException("Start view isn't assigned");

            _currentView = _startView;
            _currentView.Show(true);
        }

        #endregion

        public void Show(View view)
        {
            if (_currentView == view) return;

            _currentView.Hide();

            view.Show();
            _currentView = view;
        }
    }
}
