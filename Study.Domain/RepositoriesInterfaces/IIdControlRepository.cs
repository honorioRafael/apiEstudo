using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IIdControlRepository : IBaseRepository_1<IdControl>
    {
        (long FirstId, long LastId) GetRangeId(long tableKey, long quantity);
    }
}
