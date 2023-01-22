using System.Threading.Tasks;
using UnityEngine;

namespace HomeTest.RadialPage
{
    public class PostsVisualizer : MonoBehaviour, IServerDataVisualizer<PostData>
    {
        [SerializeField] private PostCard _postCardPrefab;
        [SerializeField] private Transform _cardsContainer;

        public async Task<bool> Spawn(PostData[] data)
        {
            foreach (PostData postData in data)
            {
                PostCard postCard = Instantiate(_postCardPrefab.gameObject, _cardsContainer).GetComponent<PostCard>();
                postCard.SetText(postData.title);
            }

            return true;
        }
    }
}
