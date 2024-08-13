using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository.Base;

namespace Study.Domain.Interface.Repository
{
    public interface IIdControlRepository : IBaseRepository_1<IdControlOutput, IdControlDTO, IdControlInternalPropertiesDTO>
    {
        (long FirstId, long LastId) GetRangeId(long tableKey, long quantity);
    }
}
