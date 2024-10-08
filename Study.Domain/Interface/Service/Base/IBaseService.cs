﻿using Study.Arguments.Arguments.Base;

namespace Study.Domain.Interface.Service
{
    public interface IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        long Create(TInputCreate inputCreate);
        List<long> CreateMultiple(List<TInputCreate> listInputCreate);
        long Update(TInputIdentityUpdate inputIdentityUpdate);
        List<long> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate);
        void Delete(TInputIdentityDelete inputIdentityDelete);
        void DeleteMultiple(List<TInputIdentityDelete> inputIdentityDelete);
        List<TOutput>? GetAll();
        TOutput? Get(long id);
    }

    public interface IBaseService_1<TOutput> : IBaseService<BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>
        where TOutput : BaseOutput<TOutput>
    { }

    public interface IBaseService_2<TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput> : IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, BaseInputIdentityDelete_0, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TOutput : BaseOutput<TOutput>
    { }
}