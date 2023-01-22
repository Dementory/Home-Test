using UnityEngine;

namespace HomeTest
{
    public class ImageConverter
    {
        public static Sprite FromTextureToSprite(Texture2D texture) =>
            Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
    }
}
