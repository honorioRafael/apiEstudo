using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingService : BaseService<Shopping, IShoppingRepository, InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>, IShoppingService
    {
        public ShoppingService(IShoppingRepository shoppingRepository, IShoppingItemRepository shoppingItemRepository, IEmployeeRepository employeeRepository, IProductRepository productRepository) : base(shoppingRepository)
        {
            _shoppingItemRepository = shoppingItemRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
        }
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;

        public override long Create(InputCreateShopping inputCreateShopping)
        {
            if (inputCreateShopping == null)
                throw new ArgumentNullException();
            if (_employeeRepository.Get(inputCreateShopping.EmployeeId) == null)
                throw new InvalidArgumentException("Employee ID inválido!");
            if (inputCreateShopping.CreatedItens == null)
                throw new InvalidArgumentException("Insira um produto para criar uma compra.");
            if (inputCreateShopping.Value < 0)
                throw new InvalidArgumentException("Valor inválido!");

            var ShopId = _repository.Create(new Shopping(inputCreateShopping.EmployeeId, null, inputCreateShopping.Value, null).SetCreationDate());

            CreateMultipleShoppingItens(Convert.ToInt32(ShopId), inputCreateShopping.CreatedItens);
            return ShopId;
        }

        public override long Update(InputIdentityUpdateShopping inputIdentityUpdateShopping)
        {
            if (inputIdentityUpdateShopping == null) 
                throw new ArgumentNullException();

            var OriginalShopping = _repository.Get(inputIdentityUpdateShopping.Id);
            if (OriginalShopping == null)
                throw new NotFoundException();
            if (_employeeRepository.Get(inputIdentityUpdateShopping.InputUpdate.EmployeeId) == null)
                throw new InvalidArgumentException("Employee ID inválido!");
            if (inputIdentityUpdateShopping.InputUpdate.Value < 0)
                throw new InvalidArgumentException("Valor inválido!");

            // produtos compra - Create
            if (inputIdentityUpdateShopping.InputUpdate.CreatedItens != null)
            {
                CreateMultipleShoppingItens(OriginalShopping.Id, inputIdentityUpdateShopping.InputUpdate.CreatedItens);
            }           

            // produtos compra - Update
            if (inputIdentityUpdateShopping.InputUpdate.UpdatedItens != null)
            {
                UpdateMultipleShoppingItens(inputIdentityUpdateShopping.InputUpdate.UpdatedItens);
            }

            // produtos compra - Delete
            if (inputIdentityUpdateShopping.InputUpdate.DeletedItens != null)
            {
                DeleteMultipleShoppingItens(inputIdentityUpdateShopping.InputUpdate.DeletedItens);
            }

            _repository.Update(new Shopping(inputIdentityUpdateShopping.InputUpdate.EmployeeId, null, inputIdentityUpdateShopping.InputUpdate.Value, null).LoadInternalData(OriginalShopping.Id, OriginalShopping.CreationDate, OriginalShopping.ChangeDate).SetChangeDate());            
            return OriginalShopping.Id;

        }

        private void CreateMultipleShoppingItens(int shopId, List<InputCreateShoppingItem> inputCreateShoppingItem)
        {
            if (inputCreateShoppingItem.Any(x => _productRepository.Get(x.ProductId) == null))
                throw new InvalidArgumentException("Há um id de produto inválido na lista de criação.");
            if (inputCreateShoppingItem.Any(x => x.Quantity < 0))
                throw new InvalidArgumentException("Há um produto com quantidade inválida.");

            _shoppingItemRepository.CreateMultiple(
                (from product in inputCreateShoppingItem
                    select new ShoppingItem(shopId, product.ProductId, product.Quantity, null, null).SetCreationDate()).ToList());
        }

        private void UpdateMultipleShoppingItens(List<InputIdentityUpdateShoppingItem> inputIdentityUpdateShoppingitem)
        {
            if (inputIdentityUpdateShoppingitem.Any(x => _shoppingItemRepository.Get(x.Id) == null))
                throw new InvalidArgumentException("Há um id inválido na lista de alteração.");
            if (inputIdentityUpdateShoppingitem.Any(x => _productRepository.Get(x.InputUpdate.ProductId) == null))
                throw new InvalidArgumentException("Há um id de produto inválido na lista de alteração.");
            if (inputIdentityUpdateShoppingitem.Any(x => x.InputUpdate.Quantity < 0))
                throw new InvalidArgumentException("Há um produto com quantidade inválida.");

            _shoppingItemRepository.UpdateMultiple((from item in inputIdentityUpdateShoppingitem
                                                    let originalItem = _shoppingItemRepository.Get(item.Id)
                                                    select new ShoppingItem(originalItem.ShoppingId, item.InputUpdate.ProductId, item.InputUpdate.Quantity, null, null).LoadInternalData(originalItem.Id, originalItem.CreationDate, originalItem.ChangeDate).SetChangeDate()).ToList());
        }

        private void DeleteMultipleShoppingItens(List<InputIdentityDeleteShoppingItem> inputIdentityDeleteShoppingItems)
        {
            if (inputIdentityDeleteShoppingItems.Any(x => _shoppingItemRepository.Get(x.Id) == null))
                throw new InvalidArgumentException("Há um id inválido na lista de exclusão.");

            _shoppingItemRepository.DeleteMultiple((from item in inputIdentityDeleteShoppingItems
                                                    select _shoppingItemRepository.Get(item.Id)).ToList());
        }
    }
}
