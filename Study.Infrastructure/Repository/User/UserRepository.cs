using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.DTO.UserDTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;
using Study.Infrastructure.Repository.Base;

namespace Study.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User, InputCreateUser, InputUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        { }

        public UserDTO? GetByName(string name)
        {
            return FromEntryToDTO(_dbset.Where(x => x.Name == name).FirstOrDefault());
        }
    }
}
