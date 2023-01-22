using UnityEngine;

namespace HomeTest.PhotosPage
{
    public class EdgeDetectorLoader : MonoBehaviour
    {
        [SerializeField] private ScrollRectEdgeDetector _scrollEdgeDetector;

        private ServerDataController<PhotoData> _photosLoader;

        private void Start() => _photosLoader = gameObject.GetComponentWithException<ServerDataController<PhotoData>>();

        private void OnEnable() => _scrollEdgeDetector.OnBottomEdgeReach += () => LoadPhotos();

        private void OnDisable() => _scrollEdgeDetector.OnBottomEdgeReach -= () => LoadPhotos();

        private void LoadPhotos()
        {
            if (_photosLoader.IsLoading) return;

            _photosLoader.LoadObjects();
        }

    }
}
