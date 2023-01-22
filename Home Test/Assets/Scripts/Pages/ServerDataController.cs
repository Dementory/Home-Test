using System.Collections.Generic;
using System.Linq;
using HomeTest.Database;
using UnityEngine;

namespace HomeTest
{
    public abstract class ServerDataController<T> : MonoBehaviour
    {
        [SerializeField] private int _amountLoadedPerChunk;

        private IServerDataProvider<T> _dataProvider;
        private IServerDataVisualizer<T> _photoCardVisualizer;

        private int _dataObjectsAmount;

        private bool _isLoading;
        public bool IsLoading => _isLoading;

        private void Start()
        {
            _dataProvider = gameObject.GetComponentWithException<IServerDataProvider<T>>();
            _photoCardVisualizer = gameObject.GetComponentWithException<IServerDataVisualizer<T>>();

            LoadObjects();
        }

        public async void LoadObjects()
        {
            _isLoading = true;

            IEnumerable<T> photosData = await _dataProvider.GetData(_amountLoadedPerChunk, _dataObjectsAmount);
            _dataObjectsAmount += photosData.Count();

            await _photoCardVisualizer.Spawn(photosData.ToArray());

            _isLoading = false;
        }
    }
}
