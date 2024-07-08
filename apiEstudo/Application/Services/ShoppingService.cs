using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingService : BaseService<Shopping, IShoppingRepository, InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>, IShoppingService
    {
        public ShoppingService(IShoppingRepository contextInterface) : base(contextInterface)
        { }

        public override long Create(InputCreateShopping inputCreate)
        {
            if (inputCreate == null) throw new ArgumentNullException();
            return _repository.Create(new Shopping(inputCreate.EmployeeId, inputCreate.ProductId, inputCreate.Value, DateTime.Now, null, null).SetCreationDate());
        }

        public override long Update(InputIdentityUpdateShopping inputIdentityUpdate)
        {
            var OriginalItem = _repository.Get(inputIdentityUpdate.Id);
            if (OriginalItem == null) throw new NotFoundException();
            return _repository.Update(new Shopping(inputIdentityUpdate.InputUpdate.EmployeeId,
                inputIdentityUpdate.InputUpdate.ProductId,
                inputIdentityUpdate.InputUpdate.Value, OriginalItem.TransationDate, null, null).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }
    }
}
