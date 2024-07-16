﻿using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;

namespace apiEstudo.Domain.DTOs
{
    public class ProductDTO : BaseDTO<InputCreateProduct, InputUpdateProduct, OutputProduct, ProductDTO, ProductExternalPropertiesDTO, ProductInternalPropertiesDTO, ProductAuxiliaryPropertiesDTO>
    {
        public ProductDTO() { }

        public static implicit operator OutputProduct(ProductDTO dto)
        {
            return dto == null ? default : new OutputProduct(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.Quantity, dto.ExternalPropertiesDTO.BrandId, null).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator ProductDTO(OutputProduct output)
        {
            return output == null ? default : new ProductDTO().Create(output.Id,
                new ProductExternalPropertiesDTO(output.Name, output.Quantity, output.BrandId),
                new ProductInternalPropertiesDTO().LoadInternalData(output.Id, output.CreationDate, output.ChangeDate));
        }
    }
}
