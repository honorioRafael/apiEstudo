﻿using apiEstudo.Application.Arguments;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        public long Create(TInputCreate inputCreate);
        public long Update(TInputIdentityUpdate inputIdentityUpdate);
        public void Delete(TInputIdentityDelete inputIdentityDelete);
        public List<TOutput>? GetAll();
        public TOutput? Get(int id);
        List<TOutput>? GetListByListId(List<int> listId);
    }

    public interface IBaseService_1<TOutput> : IBaseService<BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>
        where TOutput : BaseOutput<TOutput>
    { }
}