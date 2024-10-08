﻿using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;
using Study.Infrastructure.Repository.Base;

namespace Study.Infrastructure.Repository
{
    public class IdControlRepository : BaseRepository_1<IdControl, IdControlOutput, IdControlDTO, IdControlInternalPropertiesDTO>, IIdControlRepository
    {
        public IdControlRepository(AppDbContext context) : base(context) { }

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
