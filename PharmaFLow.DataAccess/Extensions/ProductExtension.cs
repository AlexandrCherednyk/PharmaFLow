using PharmaFlow.Infrastructure.Dtos.Requests;

namespace PharmaFLow.DataAccess.Extensions;

public static class ProductExtension
{
    public static List<ProductDto> ToProductDtoList(this List<ProductPersistence> productList)
    {
        return productList.ConvertAll(p => p.ToProductrDto());
    }

    public static ProductDto ToProductrDto(this ProductPersistence prduct)
    {
        return new()
        {
            ID = prduct.ID,
            Name = prduct.Name,
            Description = prduct.Description,
            Price = prduct.Price,
            Count = prduct.Count,
            PathToFile = prduct.PathToFile,
            Type = prduct.Type!.ToProductrTypeDto(),
            Manufacturer = prduct.Manufacturer!.ToProductrManufacturerDto(),
            Characteristics = prduct.Characteristics.ConvertAll(c => c.ToProductrCharacteristicDto()),
        };
    }

    public static List<ProductTypeDto> ToProductTypeDtoList(this List<ProductTypePersistence> typeList)
    {
        return typeList.ConvertAll(t => t.ToProductrTypeDto());
    }

    public static ProductTypeDto ToProductrTypeDto(this ProductTypePersistence Type)
    {
        return new()
        {
            ID = Type.ID,
            Name = Type.Name,
        };
    }

    public static List<ProductManufacturerDto> ToProductrManufacturerDtoList(this List<ProductManufacturerPersistence> manufacturerList)
    {
        return manufacturerList.ConvertAll(m => m.ToProductrManufacturerDto());
    }

    public static ProductManufacturerDto ToProductrManufacturerDto(this ProductManufacturerPersistence manufacturer)
    {
        return new()
        {
            ID = manufacturer.ID,
            Name = manufacturer.Name,
        };
    }

    public static ProductCharacteristicDto ToProductrCharacteristicDto(this ProductCharacteristicPersistence characteristic)
    {
        return new()
        {
            ID = characteristic.ID,
            Name = characteristic.Name,
            Value = characteristic.Value,
        };
    }

    public static List<ProductCharacteristicPersistence> ToProductCharacteristicPersistenceList(this List<CreateProductCharacteristicRequest> characteristicList)
    {
        return characteristicList.ConvertAll(p => p.ToProductCharacteristicPersistence());
    }

    public static ProductCharacteristicPersistence ToProductCharacteristicPersistence(this CreateProductCharacteristicRequest characteristic)
    {
        return new()
        {
            Name = characteristic.Name,
            Value = characteristic.Value,
        };
    }
}
