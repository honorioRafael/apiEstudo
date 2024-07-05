﻿using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class Brand : BaseEntry<Brand>, IBaseModel<Brand>
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Brand(string name)
        {
            Name = name;    
            CreationDate = DateTime.Now;    
        }

        public static implicit operator BrandDTO(Brand marca)
        {
            return marca == null ? default : new BrandDTO { Id = marca.Id, Name = marca.Name };
        }
    }   
}
