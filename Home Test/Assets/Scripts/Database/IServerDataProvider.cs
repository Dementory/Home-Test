using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeTest.Database
{
    public interface IServerDataProvider<T>
    {
        Task<IEnumerable<T>> GetData(int amount, int startElementId = 0);
    }
}
