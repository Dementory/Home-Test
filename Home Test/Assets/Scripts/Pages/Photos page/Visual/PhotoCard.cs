using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace HomeTest.PhotosPage
{
    public class PhotoCard : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Transform _textBlock;
        [Space]
        [SerializeField] private Image _image;

        public void SetUp(string text, Texture2D imageTexture)
        {
            _text.text = text;
            _image.sprite = ImageConverter.FromTextureToSprite(imageTexture);
        }

        public void Miror()
        {
            MirorPosition(_textBlock);
            MirorPosition(_image.transform);

            void MirorPosition(Transform mirroredObject)
            {
                Vector2 position = mirroredObject.localPosition;
                mirroredObject.localPosition = new Vector2(-position.x, position.y);
            }
        }

    }
}
