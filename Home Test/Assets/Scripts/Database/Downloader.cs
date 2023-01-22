using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace HomeTest.Database
{
    public class Downloader
    {
        public async Task<Texture2D> DownloadImage(string imageUrl)
        {
            imageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg?crop=1.00xw:0.669xh;0,0.190xh&resize=640:*";
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);

            request.SendWebRequest();
            while (!request.isDone) await Task.Yield();

            if (request.result != UnityWebRequest.Result.Success)
                throw new Exception($"Data request error: {request.error}");

            return ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
