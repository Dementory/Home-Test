using System.Threading.Tasks;

namespace HomeTest
{
    public interface IServerDataVisualizer<T>
    {
        Task<bool> Spawn(T[] data);
    }
}
