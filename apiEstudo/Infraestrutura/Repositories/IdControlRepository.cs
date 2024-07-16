using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class IdControlRepository : BaseRepository_1<IdControl, BaseOutput_0, BaseDTO_0, BaseInternalPropertiesDTO_0, BaseAuxiliaryPropertiesDTO_0>, IIdControlRepository
    {
        public IdControlRepository(ConnectionContext context) : base(context) { }

        public (long FirstId, long LastId) GetRangeId(long tableKey, long quantity)
        {
            (long FirstId, long LastId) result;
            var idControl = _dbset.Where(x => x.TableKey == tableKey).FirstOrDefault();
            if (idControl == null)
            {
                _context.Add(new IdControl(tableKey, "", 1 + quantity));
                _context.SaveChanges();
                result = (1, 1 + quantity);
            }
            else
            {
                result = (idControl.NextId, idControl.NextId + quantity);
                idControl.NextId = idControl.NextId + quantity;
                _context.Update(idControl);
                _context.SaveChanges();
            }
            return result;
        }
    }
}
