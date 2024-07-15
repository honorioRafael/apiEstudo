using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using System.Formats.Tar;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IBaseService<TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputCreateComplete : BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        int Create(TInputCreate inputCreate);
        List<int> CreateMultiple(List<TInputCreate> listInputCreate);
        List<int> CreateMultiple(List<TInputCreateComplete> listInputCreate);
        int Update(TInputIdentityUpdate inputIdentityUpdate);
        List<int> UpdateRange(List<TInputIdentityUpdate> listInputIdentityUpdate);
        void Delete(TInputIdentityDelete inputIdentityDelete);
        List<TOutput>? GetAll();
        TOutput? Get(int id);        
    }

    public interface IBaseService_1<TOutput> : IBaseService<BaseInputCreate_0, BaseInputCreateComplete_0, BaseInputInternalCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>
        where TOutput : BaseOutput<TOutput>
    { }

    public interface IBaseService_2<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : IBaseService<TInputCreate, BaseInputCreateComplete<TInputCreate, BaseInputInternalCreate_0>, BaseInputInternalCreate_0, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    { }
}