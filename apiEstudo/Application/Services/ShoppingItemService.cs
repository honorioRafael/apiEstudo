using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingItemService : BaseService<ShoppingItem, IShoppingItemRepository, InputCreateShoppingItem, InputCreateShoppingItemComplete, InputInternalCreateShoppingItem, InputUpdateShoppingItem, InputIdentityUpdateShoppingItem, InputIdentityDeleteShoppingItem, OutputShoppingItem>, IShoppingItemService
    {
        protected readonly IProductRepository _productRepository;
        public ShoppingItemService(IShoppingItemRepository contextInterface, IProductRepository productRepository) : base(contextInterface)
        { 
            _productRepository = productRepository;
        }

        public override List<int> CreateMultiple(List<InputCreateShoppingItemComplete> listInputCreateComplete)
        {
            var shoppingItemToCreate = InternalCreate(listInputCreateComplete);
            return _repository.CreateMultiple(shoppingItemToCreate);
        }
    }
}
