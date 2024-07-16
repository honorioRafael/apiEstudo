using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IIdControlRepository : IBaseRepository_1<IdControl, BaseOutput_0, BaseDTO_0, BaseInternalPropertiesDTO_0, BaseAuxiliaryPropertiesDTO_0>
    {
        (long FirstId, long LastId) GetRangeId(long tableKey, long quantity);
    }
}
