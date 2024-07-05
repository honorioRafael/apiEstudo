//using apiEstudo.Application.ServicesInterfaces;
//using apiEstudo.Domain.Models;
//using apiEstudo.Infraestrutura.RepositoriesInterfaces;

//namespace apiEstudo.Application.Services
//{
//    public class ShoppingService : BaseService<Shopping, IShoppingRepository, ShoppingDTO>, IShoppingService
//    {
//        public ShoppingService(IShoppingRepository contextInterface) : base(contextInterface)
//        { }

//        public bool Create(ShoppingCreateViewModel view)
//        {
//            if (view == null) return false;
//            var Entity = new Shopping(view.EmployeeId, view.ProductId, view.Value, DateTime.Now, null, null);
//            _repository.Create(Entity);

//            return true;
//        }
//    }
//}
