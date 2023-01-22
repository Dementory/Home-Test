using System.Collections.Generic;
using System.Linq;
using HomeTest.Database;

namespace HomeTest.PhotosPage
{
    public class PhotoDataProvider : ServerDataProvider<PhotoData, PhotoDataContainer>
    {
        private const string DATABASE_URL = "https://jsonplaceholder.typicode.com/photos/";
        protected override string DatabaseUrl => DATABASE_URL;

        protected override IEnumerable<PhotoData> ExtractData(PhotoDataContainer container, int startElementId, int amount) =>
            container.photosData.Skip(startElementId).Take(amount);

        protected override string GetListName()
        {
            PhotoDataContainer photoDataContainer = new PhotoDataContainer();
            string listName = nameof(photoDataContainer.photosData);

            return listName;
        }
    }
}
