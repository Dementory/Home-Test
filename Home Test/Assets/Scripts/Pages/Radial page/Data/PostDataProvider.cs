using System.Collections.Generic;
using HomeTest.Database;
using System.Linq;

namespace HomeTest.RadialPage
{
    public class PostDataProvider : ServerDataProvider<PostData, PostDataContainer>
    {
        private const string DATABASE_URL = "https://jsonplaceholder.typicode.com/posts";
        protected override string DatabaseUrl => DATABASE_URL;

        protected override IEnumerable<PostData> ExtractData(PostDataContainer container, int startElementId, int amount) =>
            container.postsData.Skip(startElementId).Take(amount);

        protected override string GetListName()
        {
            PostDataContainer photoDataContainer = new PostDataContainer();
            string listName = nameof(photoDataContainer.postsData);

            return listName;
        }
    }
}
