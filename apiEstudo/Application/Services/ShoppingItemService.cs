using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingItemService : BaseService<ShoppingItem, IShoppingItemRepository, InputCreateShoppingItem, InputCreateShoppingItemComplete, InputInternalCreateShoppingItem, InputUpdateShoppingItem, InputIdentityUpdateShoppingItem, InputIdentityDeleteShoppingItem, OutputShoppingItem>, IShoppingItemService
    {
        public ShoppingItemService(IShoppingItemRepository contextInterface) : base(contextInterface)
        { }

        public override List<int> CreateMultiple(List<InputCreateShoppingItemComplete> listInputCreateComplete)
        {
            return _repository.CreateMultiple(listInputCreateComplete);
        }
    }
}
