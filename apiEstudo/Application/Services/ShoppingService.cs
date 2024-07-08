using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Application.Services;

namespace apiEstudo.Application.Services
{
    public class ShoppingService : BaseService<Shopping, IShoppingRepository, InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>, IShoppingService
    {
        public ShoppingService(IShoppingRepository contextInterface, IShoppingListService listContext) : base(contextInterface)
        {
            _listContext = listContext;
        }
        private readonly IShoppingListService _listContext;
     
        public override long Create(InputCreateShopping inputCreate)
        {
            if (inputCreate == null) throw new ArgumentNullException();
            var ShopId = _repository.Create(new Shopping(inputCreate.EmployeeId, null, inputCreate.Value, null).SetCreationDate());

            _listContext.CreateMultiple(Convert.ToInt32(ShopId), inputCreate.Products);
            return ShopId;
        }
    }
}
