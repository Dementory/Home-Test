using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace HomeTest.Database
{

    public class DatabaseReader<T>
    {
        public async Task<T> GetDataList(string listName, string databaseUrl)
        {
            string jsonData = await GetJsonData(databaseUrl);

            string requestUrl = "{\"" + listName + "\":" + jsonData + "}";

            T dataList = JsonUtility.FromJson<T>(requestUrl);

            return dataList;
        }

        private async Task<string> GetJsonData(string requestUrl)
        {
            UnityWebRequest request = UnityWebRequest.Get(requestUrl);

            request.SendWebRequest();
            while (!request.isDone) await Task.Yield();

            if (request.result != UnityWebRequest.Result.Success)
                throw new Exception($"Data request error: {request.error}");

            return request.downloadHandler.text;
        }
    }

}
