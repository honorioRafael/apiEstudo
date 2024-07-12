﻿using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.Models
{
    public class Brand : BaseEntry<Brand>
    {
        public string Name { get; set; }
        public virtual List<Product> ListProduct { get; set; }

        public Brand(string name)
        {
            Name = name;
        }

        public Brand() { }

        public static implicit operator OutputBrand(Brand brand)
        {
            return brand == null ? default : new OutputBrand(brand.Name).LoadInternalData(brand.Id, brand.CreationDate, brand.ChangeDate);
        }
    }
}