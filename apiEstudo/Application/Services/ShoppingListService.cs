using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingListService : BaseService<ShoppingList, IShoppingListRepository, InputCreateShoppingList, InputUpdateShoppingList, InputIdentityUpdateShoppingList, InputIdentityDeleteShoppingList, OutputShoppingList>, IShoppingListService
    {
        public ShoppingListService(IShoppingListRepository contextInterface) : base(contextInterface)
        {
        }

        public List<int> CreateMultiple(int shopId, List<InputCreateShoppingList> listInputCreate)
        {
            return _repository.CreateMultiple(
                (from product in listInputCreate
                 select new ShoppingList(shopId, product.ProductId, product.Quantity, null, null)
                 .SetCreationDate()).ToList());            
        }
    }
}
