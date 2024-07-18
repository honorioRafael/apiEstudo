using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;
using Study.Domain.Interface.Repository;

namespace Study.Domain.Service
{
    public class ShoppingItemService : BaseService<ShoppingItem, IShoppingItemRepository, InputCreateShoppingItem, InputUpdateShoppingItem, InputIdentityUpdateShoppingItem, InputIdentityDeleteShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>, IShoppingItemService
    {
        protected readonly IProductRepository _productRepository;
        public ShoppingItemService(IShoppingItemRepository contextInterface, IProductRepository productRepository, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        {
            _productRepository = productRepository;
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateShoppingItem> listInputIdentityUpdateShoppingItem)
        {
            List<ShoppingItemDTO> shoppingItensToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateShoppingItem select i.Id).ToList());
            if (shoppingItensToBeUpdated.Count != listInputIdentityUpdateShoppingItem.Count)
                throw new NotFoundException("Shopping Item ID não localizado!");

            var updatedShoppingItens = (from inputIdentityUpdateShoppingItem in listInputIdentityUpdateShoppingItem
                                        let inputUpdateShoppingItem = inputIdentityUpdateShoppingItem.InputUpdate
                                        let shoppingItemToUpdate = (from j in shoppingItensToBeUpdated where j.InternalPropertiesDTO.Id == inputIdentityUpdateShoppingItem.Id select j).FirstOrDefault()
                                        select shoppingItemToUpdate.Update(inputUpdateShoppingItem)).ToList();
            return _repository.UpdateMultiple(updatedShoppingItens);
        }
    }
}
