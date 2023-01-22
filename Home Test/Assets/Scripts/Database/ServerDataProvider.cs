using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace HomeTest.Database
{
    public abstract class ServerDataProvider<Data, Container> : MonoBehaviour, IServerDataProvider<Data>
    {
        private DatabaseReader<Container> _databaseReader = new DatabaseReader<Container>();

        protected abstract string DatabaseUrl { get; }

        public async Task<IEnumerable<Data>> GetData(int amount, int startElementId = 0)
        {
            string listName = GetListName();

            Container container = await _databaseReader.GetDataList(listName, DatabaseUrl);
            IEnumerable<Data> dataList = ExtractData(container, startElementId, amount);

            return dataList;
        }

        protected abstract IEnumerable<Data> ExtractData(Container container, int startElementId, int amount);

        protected abstract string GetListName();
    }
}
