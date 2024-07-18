using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;
using Study.Domain.DTO;
using Study.Domain.Models;
using Study.Domain.Interface.Repository;

namespace Study.Domain.Service
{
    public class ShoppingService : BaseService<Shopping, IShoppingRepository, InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>, IShoppingService
    {
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingItemService _shoppingItemService;

        public ShoppingService(IShoppingRepository shoppingRepository, IShoppingItemRepository shoppingItemRepository, IEmployeeRepository employeeRepository, IProductRepository productRepository, IShoppingItemService shoppingItemService, IIdControlRepository idControlRepository) : base(shoppingRepository, idControlRepository)
        {
            _shoppingItemRepository = shoppingItemRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _shoppingItemService = shoppingItemService;
        }

        #region Create
        public override List<long> CreateMultiple(List<InputCreateShopping> listInputCreateShopping)
        {
            if (listInputCreateShopping == null)
                throw new ArgumentNullException();
            if ((from i in listInputCreateShopping select i).Any(x => x.CreatedItens.Count == 0))
                throw new InvalidArgumentException("Insira um produto para criar uma compra.");
            if ((from i in listInputCreateShopping select i).Any(x => x.Value < 0))
                throw new InvalidArgumentException("Valor inválido!");
            List<EmployeeDTO> listRelatedEmployee = _employeeRepository.GetListByListId((from i in listInputCreateShopping select i.EmployeeId).ToList());
            if (listRelatedEmployee.Count == 0)
                throw new InvalidArgumentException("Employee ID inválido!");


            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(Shopping)), listInputCreateShopping.Count);
            var id = idRange.FirstId;

            var shoppingToCreate = (from inputCreateShopping in listInputCreateShopping
                                    select new ShoppingDTO().Create(id++, inputCreateShopping, new ShoppingInternalPropertiesDTO(1))).ToList();
            List<long> listShoppingId = _repository.CreateMultiple(shoppingToCreate);

            /* var listCreateShoppingItem = (from i in listCreate
                                           let parentId = 1// listShoppingId[i.Index]
                                           let createdItens = (from j in i.CreatedItens select new InputCreateShoppingItemComplete(j, new InputInternalCreateShoppingItem(parentId))).ToList()
                                           select createdItens).SelectMany(x => x).ToList();
            */
            return listShoppingId;
        }

        #endregion

        #region Update        
        public override List<long> UpdateMultiple(List<InputIdentityUpdateShopping> listInputIdentityUpdateShopping)
        {
            if (listInputIdentityUpdateShopping.Count == 0)
                throw new ArgumentNullException();

            List<EmployeeDTO>? listRelatedEmployees = _employeeRepository.GetListByListId((from i in listInputIdentityUpdateShopping
                                                                                           select i.InputUpdate.EmployeeId).ToList());
            if (listRelatedEmployees == null || listRelatedEmployees.Count == 0)
                throw new InvalidArgumentException("Há um ID de funcionário inválido!");

            if (listInputIdentityUpdateShopping.Any(x => x.InputUpdate.Value < 0))
                throw new InvalidArgumentException("Hã um valor inválido!");

            List<ShoppingDTO> shoppingsToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateShopping select i.Id).ToList());
            if (shoppingsToBeUpdated.Count != listInputIdentityUpdateShopping.Count)
                throw new InvalidArgumentException("Há um ID de compra inválido!");

            /*foreach (var inputIdentityUpdateShopping in listInputIdentityUpdateShopping)
            {
                // produtos compra - Create
                if (inputIdentityUpdateShopping.InputUpdate.CreatedItens != null)
                {
                    if (inputIdentityUpdateShopping.InputUpdate.CreatedItens.Any(x => _productRepository.Get(x.ProductId) == null))
                        throw new InvalidArgumentException("Há um id de produto inválido na lista de criação.");
                    if (inputIdentityUpdateShopping.InputUpdate.CreatedItens.Any(x => x.Quantity < 0))
                        throw new InvalidArgumentException("Há um produto com quantidade inválida.");
                    List<InputCreateShoppingItemComplete> listInputCreateShoppingItemComplete = (from i in inputIdentityUpdateShopping.InputUpdate.CreatedItens
                                                                                                 select new InputCreateShoppingItemComplete(i, new InputInternalCreateShoppingItem(inputIdentityUpdateShopping.Id))).ToList();
                    CreateMultipleShoppingItens(listInputCreateShoppingItemComplete);
                }

                // produtos compra - Update
                if (inputIdentityUpdateShopping.InputUpdate.UpdatedItens != null)
                {
                    List<Product>? listRelatedProducts = _productRepository.GetListByListId((from i in inputIdentityUpdateShopping.InputUpdate.UpdatedItens select i.InputUpdate.ProductId).ToList());
                    if (listRelatedProducts == null || listRelatedProducts.Count == 0)
                        throw new InvalidArgumentException("Há um id de produto inválido na lista de alteração!");
                    if (inputIdentityUpdateShopping.InputUpdate.UpdatedItens.Any(x => x.InputUpdate.Quantity < 0))
                        throw new InvalidArgumentException("Há um produto com quantidade inválida.");
                    UpdateMultipleShoppingItens(inputIdentityUpdateShopping.InputUpdate.UpdatedItens);
                }

                // produtos compra - Delete
                if (inputIdentityUpdateShopping.InputUpdate.DeletedItens != null)
                {
                    List<ShoppingItem>? listRelatedProducts = _shoppingItemRepository.GetListByListId((from i in inputIdentityUpdateShopping.InputUpdate.DeletedItens select i.Id).ToList());
                    if (listRelatedProducts == null || listRelatedProducts.Count == 0)
                        throw new InvalidArgumentException("Há um ID de produto inválido na lista de deleção.");
                    DeleteMultipleShoppingItens(inputIdentityUpdateShopping.InputUpdate.DeletedItens);
                }
            }*/

            var updatedShoppings = (from inputIdentityUpdateShopping in listInputIdentityUpdateShopping
                                    let inputUpdateShopping = inputIdentityUpdateShopping.InputUpdate
                                    let shoppingToUpdate = (from j in shoppingsToBeUpdated where j.InternalPropertiesDTO.Id == inputIdentityUpdateShopping.Id select j).FirstOrDefault()
                                    select shoppingToUpdate.Update(inputUpdateShopping)).ToList();
            return _repository.UpdateMultiple(updatedShoppings);
        }
        #endregion

        #region Shipping
        public List<long> UpdateShippingStatusApprove(List<InputApproveShippingStatus> listInputApproveShippingStatus)
        {
            if (listInputApproveShippingStatus.Any(x => x.Id < 0))
                throw new InvalidArgumentException("Há um shopping ID inválido!");

            List<ShoppingDTO> originalShoppings = _repository.GetListByListId((from i in listInputApproveShippingStatus select i.Id).ToList());
            if (originalShoppings.Count != listInputApproveShippingStatus.Count)
                throw new InvalidArgumentException("Há um shopping ID inválido!");

            return _repository.UpdateMultiple((from i in listInputApproveShippingStatus
                                               let listOg = originalShoppings
                                               from og in listOg
                                               select new ShoppingDTO().Create(og.InternalPropertiesDTO.Id, new ShoppingExternalPropertiesDTO(og.ExternalPropertiesDTO.EmployeeId, og.ExternalPropertiesDTO.Value), new ShoppingInternalPropertiesDTO(2).LoadInternalData(og.InternalPropertiesDTO.Id, og.InternalPropertiesDTO.CreationDate, og.InternalPropertiesDTO.ChangeDate))).ToList());
        }

        public List<long> UpdateShippingStatusCancel(List<InputCancelShippingStatus> listInputCancelShippingStatus)
        {
            if (listInputCancelShippingStatus.Any(x => x.Id < 0))
                throw new InvalidArgumentException("Há um shopping ID inválido!");

            List<ShoppingDTO> originalShoppings = _repository.GetListByListId((from i in listInputCancelShippingStatus select i.Id).ToList());
            if (originalShoppings.Count != listInputCancelShippingStatus.Count)
                throw new InvalidArgumentException("Há um shopping ID inválido!");

            return _repository.UpdateMultiple((from i in listInputCancelShippingStatus
                                               let listOg = originalShoppings
                                               from og in listOg
                                               select new ShoppingDTO().Create(og.InternalPropertiesDTO.Id, new ShoppingExternalPropertiesDTO(og.ExternalPropertiesDTO.EmployeeId, og.ExternalPropertiesDTO.Value), new ShoppingInternalPropertiesDTO(3).LoadInternalData(og.InternalPropertiesDTO.Id, og.InternalPropertiesDTO.CreationDate, og.InternalPropertiesDTO.ChangeDate))).ToList());
        }
        #endregion

        #region ShoppingItens
        private void CreateMultipleShoppingItens(long shopId, List<InputCreateShoppingItem> listInputCreateShoppingItem)
        {
            List<ProductDTO>? listRelatedProducts = _productRepository.GetListByListId((from i in listInputCreateShoppingItem select i.ProductId).ToList());
            if (listRelatedProducts == null || listRelatedProducts.Count != listInputCreateShoppingItem.Count)
                throw new InvalidArgumentException("Há um ID de produto inválido na lista de criação!");
            ShoppingDTO shopping = _repository.Get(shopId);
            if (shopping == null)
                throw new InvalidArgumentException("O ID da compra é inválido!");

            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(ShoppingItem)), listInputCreateShoppingItem.Count);
            var id = idRange.FirstId;
            var shoppingItemToCreate = (from inputCreateShoppingItem in listInputCreateShoppingItem select new ShoppingItemDTO().Create(id++, inputCreateShoppingItem, new ShoppingItemInternalPropertiesDTO(shopId))).ToList();

            _shoppingItemRepository.CreateMultiple(shoppingItemToCreate);
        }

        private void UpdateMultipleShoppingItens(List<InputIdentityUpdateShoppingItem> inputIdentityUpdateShoppingitem)
        {
            //List<Product>? listRelatedProducts = _productRepository.GetListByListId((from i in inputIdentityUpdateShoppingitem select i.InputUpdate.ProductId).ToList());
            //if (listRelatedProducts == null || listRelatedProducts.Count == 0)
            //    throw new NotFoundException("Há um id inválido na lista de alteração.");

            //_shoppingItemService.UpdateMultiple(inputIdentityUpdateShoppingitem);
        }

        private void DeleteMultipleShoppingItens(List<InputIdentityDeleteShoppingItem> inputIdentityDeleteShoppingItems)
        {
            _shoppingItemRepository.DeleteMultiple((from item in inputIdentityDeleteShoppingItems
                                                    select _shoppingItemRepository.Get(item.Id)).ToList());
        }
        #endregion
    }
}
