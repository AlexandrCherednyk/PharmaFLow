using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Product;

namespace PharmaFlow.Web.Extensions;

public static class ProductExtension
{
    public static List<ProductViewModel> ToProductViewModelList(this List<ProductDto> productList)
    {
        return productList.ConvertAll(p => p.ToProductrViewModel());
    }

    public static ProductViewModel ToProductrViewModel(this ProductDto prduct)
    {
        return new()
        {
            ID = prduct.ID,
            Name = prduct.Name,
            Description = prduct.Description,
            Price = prduct.Price,
            Count = prduct.Count,
            PathToFile = prduct.PathToFile,
            Type = prduct.Type.ToProductrTypeViewModel(),
            Manufacturer = prduct.Manufacturer.ToProductrManufacturerViewModel(),
            Characteristics = prduct.Characteristics.ConvertAll(c => c.ToProductrCharacteristicViewModel()),
        };
    }

    public static CreateProductViewModel ToCreateProductViewModel(this ProductDto prduct)
    {
        return new()
        {
            ID = prduct.ID,
            Name = prduct.Name,
            Description = prduct.Description,
            Price = prduct.Price,
            Count = prduct.Count,
            PathToFile = prduct.PathToFile,
            TypeID = prduct.Type.ID,
            ManufacturerID = prduct.Manufacturer.ID,
            Characteristics = prduct.Characteristics.ConvertAll(c => c.ToProductrCharacteristicViewModel()),
        };
    }

    public static List<ProductTypeViewModel> ToProductrTypeViewModelList(this List<ProductTypeDto> typeList)
    {
        return typeList.ConvertAll(t => t.ToProductrTypeViewModel());
    }

    public static ProductTypeViewModel ToProductrTypeViewModel(this ProductTypeDto Type)
    {
        return new()
        {
            ID = Type.ID,
            Name = Type.Name,
        };
    }

    public static List<ProductManufacturerViewModel> ToProductManufacturerViewModelList(this List<ProductManufacturerDto> manufacturerList)
    {
        return manufacturerList.ConvertAll(m => m.ToProductrManufacturerViewModel());
    }

    public static ProductManufacturerViewModel ToProductrManufacturerViewModel(this ProductManufacturerDto manufacturer)
    {
        return new()
        {
            ID = manufacturer.ID,
            Name = manufacturer.Name,
        };
    }

    public static ProductCharacteristicViewModel ToProductrCharacteristicViewModel(this ProductCharacteristicDto characteristic)
    {
        return new()
        {
            ID = characteristic.ID,
            Name = characteristic.Name,
            Value = characteristic.Value,
        };
    }
}
