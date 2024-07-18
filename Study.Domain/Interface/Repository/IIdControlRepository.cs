using Study.Domain.Models;

namespace Study.Domain.Interface.Repository
{
    public interface IIdControlRepository : IBaseRepository_1<IdControl>
    {
        (long FirstId, long LastId) GetRangeId(long tableKey, long quantity);
    }
}
