using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingService : BaseService<Shopping, IShoppingRepository, InputCreateShopping, InputCreateShoppingComplete, InputInternalCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>, IShoppingService
    {
        public ShoppingService(IShoppingRepository shoppingRepository, IShoppingItemRepository shoppingItemRepository, IEmployeeRepository employeeRepository, IProductRepository productRepository, IShoppingItemService shoppingItemService) : base(shoppingRepository)
        {
            _shoppingItemRepository = shoppingItemRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _shoppingItemService = shoppingItemService;
        }
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingItemService _shoppingItemService;

        #region Create
        public override List<int> CreateMultiple(List<InputCreateShopping> listInputCreateShopping)
        {
            if (listInputCreateShopping == null)
                throw new ArgumentNullException();
            List<Employee> listRelatedEmployee = _employeeRepository.GetListByListId((from i in listInputCreateShopping select i.EmployeeId).ToList());
            if (listRelatedEmployee.Count == 0)
                throw new InvalidArgumentException("Employee ID inválido!");

            var listCreate = (from i in listInputCreateShopping
                              let relatedEmployee = (from j in listRelatedEmployee where j.Id == i.EmployeeId select i).FirstOrDefault()
                              let index = listInputCreateShopping.IndexOf(i)
                              let createdItens = i.CreatedItens
                              select new
                              {
                                  InputCreate = i,
                                  Index = index,
                                  CreatedItens = createdItens
                              }).ToList();
            if ((from i in listCreate select i).Any(x => x.CreatedItens.Count == 0))
                throw new InvalidArgumentException("Insira um produto para criar uma compra.");
            if ((from i in listCreate select i).Any(x => x.InputCreate.Value < 0))
                throw new InvalidArgumentException("Valor inválido!");
                
            var shoppingToCreate = InternalCreate((from i in listCreate select new InputCreateShoppingComplete(i.InputCreate, new InputInternalCreateShopping(1))).ToList());
            List<int> listShoppingId = _repository.CreateMultiple(shoppingToCreate);

            var listCreateShoppingItem = (from i in listCreate
                                          let parentId = listShoppingId[i.Index]
                                          let createdItens = (from j in i.CreatedItens select new InputCreateShoppingItemComplete(j, new InputInternalCreateShoppingItem(parentId))).ToList()
                                          select createdItens).SelectMany(x => x).ToList();
            //if (_productRepository.GetListByListId((from i in listCreateShoppingItem select i.InputCreate.ProductId).ToList()).Count == 0)
            //    throw new InvalidArgumentException("Há um id de produto inválido na lista de criação.");

            CreateMultipleShoppingItens(listCreateShoppingItem);
            return listShoppingId;
        }

        #endregion

        #region Update        
        public int Update(InputIdentityUpdateShopping inputIdentityUpdateShopping)
        {
            if (inputIdentityUpdateShopping == null)
                throw new ArgumentNullException();

            if (_employeeRepository.Get(inputIdentityUpdateShopping.InputUpdate.EmployeeId) == null)
                throw new InvalidArgumentException("Employee ID inválido!");
            if (inputIdentityUpdateShopping.InputUpdate.Value < 0)
                throw new InvalidArgumentException("Valor inválido!");

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
                //CreateMultipleShoppingItens((from i in inputIdentityUpdateShopping.InputUpdate.CreatedItens select new InputCreateShoppingItem(OriginalShopping.Id, i.ProductId, i.Quantity)).ToList());
            }

            // produtos compra - Update
            if (inputIdentityUpdateShopping.InputUpdate.UpdatedItens != null)
            {
                if (inputIdentityUpdateShopping.InputUpdate.UpdatedItens.Any(x => _productRepository.Get(x.InputUpdate.ProductId) == null))
                    throw new InvalidArgumentException("Há um id de produto inválido na lista de criação.");
                if (inputIdentityUpdateShopping.InputUpdate.UpdatedItens.Any(x => x.InputUpdate.Quantity < 0))
                    throw new InvalidArgumentException("Há um produto com quantidade inválida.");
                UpdateMultipleShoppingItens(inputIdentityUpdateShopping.InputUpdate.UpdatedItens);
            }

            // produtos compra - Delete
            if (inputIdentityUpdateShopping.InputUpdate.DeletedItens != null)
            {
                if (inputIdentityUpdateShopping.InputUpdate.DeletedItens.Any(x => _productRepository.Get(x.Id) == null))
                    throw new InvalidArgumentException("Há um id de produto inválido na lista de criação.");
                DeleteMultipleShoppingItens(inputIdentityUpdateShopping.InputUpdate.DeletedItens);
            }

            //_repository.Update(new Shopping(inputIdentityUpdateShopping.InputUpdate.EmployeeId, inputIdentityUpdateShopping.InputUpdate.Value, OriginalShopping.ShippingStatusId, null, null).LoadInternalData(OriginalShopping.Id, OriginalShopping.CreationDate, OriginalShopping.ChangeDate).SetChangeDate());
            return base.Update(inputIdentityUpdateShopping);

        }
        #endregion

        #region Shipping
        public int UpdateShippingStatusApprove(InputApproveShippingStatus inputApproveShippingStatus)
        {
            if (inputApproveShippingStatus.Id < 0)
                throw new InvalidArgumentException("Shopping ID inválido!");

            var SelectedShopping = _repository.Get(inputApproveShippingStatus.Id);
            if (SelectedShopping == null)
                throw new InvalidArgumentException("Shopping ID inválido!");

            return 1;//_repository.Update(new Shopping(SelectedShopping.EmployeeId, SelectedShopping.Value, 2, null, null).LoadInternalData(SelectedShopping.Id, SelectedShopping.CreationDate, SelectedShopping.ChangeDate).SetChangeDate());
        }

        public int UpdateShippingStatusCancel(InputCancelShippingStatus inputCancelShippingStatus)
        {
            if (inputCancelShippingStatus.Id < 0)
                throw new InvalidArgumentException("Shopping ID inválido!");

            var SelectedShopping = _repository.Get(inputCancelShippingStatus.Id);
            if (SelectedShopping == null)
                throw new InvalidArgumentException("Shopping ID inválido!");

            return 1;// base.Update(new InputIdentityUpdateShopping(,));
            //return _repository.Update(new Shopping(SelectedShopping.EmployeeId, SelectedShopping.Value, 3, null, null).LoadInternalData(SelectedShopping.Id, SelectedShopping.CreationDate, SelectedShopping.ChangeDate).SetChangeDate()); ;
        }

        private void CreateMultipleShoppingItens(List<InputCreateShoppingItemComplete> inputCreateShoppingItem)
        {
            if (inputCreateShoppingItem.Any(x => _productRepository.Get(x.InputCreate.ProductId) == null))
                throw new NotFoundException("Há um id de produto inválido na lista de criação!");

            _shoppingItemService.CreateMultiple(inputCreateShoppingItem);
        }

        private void UpdateMultipleShoppingItens(List<InputIdentityUpdateShoppingItem> inputIdentityUpdateShoppingitem)
        {
            if (inputIdentityUpdateShoppingitem.Any(x => _shoppingItemRepository.Get(x.Id) == null))
                throw new InvalidArgumentException("Há um id inválido na lista de alteração.");
            if (inputIdentityUpdateShoppingitem.Any(x => _productRepository.Get(x.InputUpdate.ProductId) == null))
                throw new InvalidArgumentException("Há um id de produto inválido na lista de alteração.");
            
            _shoppingItemService.UpdateRange(inputIdentityUpdateShoppingitem);            
        }

        private void DeleteMultipleShoppingItens(List<InputIdentityDeleteShoppingItem> inputIdentityDeleteShoppingItems)
        {
            _shoppingItemRepository.DeleteMultiple((from item in inputIdentityDeleteShoppingItems
                                                    select _shoppingItemRepository.Get(item.Id)).ToList());
        }
        #endregion
    }
}
