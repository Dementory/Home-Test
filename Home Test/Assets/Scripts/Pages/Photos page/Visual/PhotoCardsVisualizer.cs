using System.Threading.Tasks;
using HomeTest.Database;
using UnityEngine;

namespace HomeTest.PhotosPage
{
    public class PhotoCardsVisualizer : MonoBehaviour, IServerDataVisualizer<PhotoData>
    {
        [SerializeField] private PhotoCard _cardPrefab;
        [SerializeField] private Transform _cardsContainer;

        private Downloader _downloader = new Downloader();

        public async Task<bool> Spawn(PhotoData[] photosData)
        {
            for (int i = 0; i < photosData.Length; i++)
            {
                PhotoData photoData = photosData[i];
                PhotoCard card = Instantiate(_cardPrefab, _cardsContainer);

                Texture2D image = await _downloader.DownloadImage(photoData.url);
                card.SetUp(photoData.title, image);

                if (i % 2 == 0)
                    card.Miror();
            }

            return true;
        }
    }
}
