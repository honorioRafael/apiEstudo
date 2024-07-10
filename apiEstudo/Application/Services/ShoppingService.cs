using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShoppingService : BaseService<Shopping, IShoppingRepository, InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>, IShoppingService
    {
        public ShoppingService(IShoppingRepository shoppingRepository, IShoppingItemRepository shoppingItemRepository, IEmployeeRepository employeeRepository) : base(shoppingRepository)
        {
            _shoppingItemRepository = shoppingItemRepository;
            _employeeRepository = employeeRepository;
        }
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public override long Create(InputCreateShopping inputCreateShopping)
        {
            if (inputCreateShopping == null)
                throw new ArgumentNullException();
            if (_employeeRepository.Get(inputCreateShopping.EmployeeId) == null)
                throw new InvalidArgumentException("Employee ID inválido!");
            if (inputCreateShopping.Products == null) throw new InvalidArgumentException("Insira um produto para criar uma compra.");

            var ShopId = _repository.Create(new Shopping(inputCreateShopping.EmployeeId, null, inputCreateShopping.Value, null).SetCreationDate());

            CreateMultiple(Convert.ToInt32(ShopId), inputCreateShopping.Products);
            return ShopId;
        }

        private void CreateMultiple(int shopId, List<InputCreateShoppingItem> inputCreateShoppingItem)
        {
            if (inputCreateShoppingItem.Any(x => _repository.Get(x.ProductId) == null))
                throw new InvalidArgumentException("Há um id de produto inválido.");

            _shoppingItemRepository.CreateMultiple(
                (from product in inputCreateShoppingItem
                 select new ShoppingItem(shopId, product.ProductId, product.Quantity, null, null).SetCreationDate()).ToList());
        }

        //public override long Update(InputIdentityUpdateShopping inputIdentityUpdateShopping)
        //{

        //}
    }
}
