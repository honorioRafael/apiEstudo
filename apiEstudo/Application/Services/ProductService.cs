﻿//using apiEstudo.Application.ServicesInterfaces;
//using apiEstudo.Domain.Models;
//using apiEstudo.Infraestrutura.RepositoriesInterfaces;

//namespace apiEstudo.Application.Services
//{
//    public class ProductService : BaseService<Product, IProductRepository, ProductDTO>, IProductService
//    {
//        public ProductService(IProductRepository contextInterface) : base(contextInterface)
//        { }

//        public bool Create(ProductCreateViewModel view)
//        {
//            if (view == null) return false;

//            var Entity = new Product(view.Name, view.Quantity, view.BrandId, null);
//            _repository.Create(Entity);
//            return true;
//        }

//        public bool Update(ProductUpdateViewModel view)
//        {
//            if (view == null) return false;
//            Product item = _repository.Get(view.Id);
//            if (item == null) return false;

//            item.Name = view.Name;
//            item.Quantity = view.Quantity;
//            item.BrandId = view.BrandId;

//            _repository.Update(item);
//            return true;
//        }
//    }
//}
