using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingItemService : BaseService<ShoppingItem, IShoppingItemRepository, InputCreateShoppingItem, InputUpdateShoppingItem, InputIdentityUpdateShoppingItem, InputIdentityDeleteShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>, IShoppingItemService
    {
        protected readonly IProductRepository _productRepository;
        public ShoppingItemService(IShoppingItemRepository contextInterface, IProductRepository productRepository, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        {
            _productRepository = productRepository;
        }

        public override List<long> CreateMultiple(List<InputCreateShoppingItem> listInputCreateShoppingItem)
        {
            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(ShoppingItem)), listInputCreateShoppingItem.Count);
            var id = idRange.FirstId;
            var shoppingItemToCreate = (from inputCreateShoppingItem in listInputCreateShoppingItem select new ShoppingItemDTO().Create(id++, inputCreateShoppingItem)).ToList();
            return _repository.CreateMultiple(shoppingItemToCreate);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateShoppingItem> listInputIdentityUpdateShoppingItem)
        {
            List<ShoppingItemDTO> shoppingItensToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateShoppingItem select i.Id).ToList());
            if (shoppingItensToBeUpdated.Count != listInputIdentityUpdateShoppingItem.Count)
                throw new NotFoundException("Shopping Item ID não localizado!");

            var updatedShoppingItens = (from inputIdentityUpdateShoppingItem in listInputIdentityUpdateShoppingItem
                                        let inputUpdateShoppingItem = inputIdentityUpdateShoppingItem.InputUpdate
                                        from shoppingItemToUpdate in shoppingItensToBeUpdated
                                        where shoppingItemToUpdate.InternalPropertiesDTO.Id == inputIdentityUpdateShoppingItem.Id
                                        select shoppingItemToUpdate.Update(inputUpdateShoppingItem)).ToList();
            return _repository.UpdateMultiple(updatedShoppingItens);
        }
    }
}
