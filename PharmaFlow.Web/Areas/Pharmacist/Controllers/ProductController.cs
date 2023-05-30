using PharmaFlow.Web.Areas.Pharmacist.ViewModels.Product;

namespace PharmaFlow.Web.Areas.Pharmacist.Controllers;

[Authorize(Roles = "Admin, Manager, Pharmacist")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(
        IProductRepository productRepository,
        IWebHostEnvironment webHostEnvironment)
    {
        _productRepository = productRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductList()
    {
        try
        {
            List<ProductDto> products = await _productRepository.GetProductListAsync();

            List<ProductViewModel> response = products.ToProductViewModelList();

            return View("ProductPanel", response);
        }
        catch (Exception)
        {
            return View("~/Views/Error.cshtml");
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> CreateProductPanel()
    {
        List<ProductTypeViewModel> types = (await _productRepository.GetProductTypeListAsync()).ToProductrTypeViewModelList();
        List<ProductManufacturerViewModel> manufacturers = (await _productRepository.GetProductManufacturerListAsync()).ToProductManufacturerViewModelList();

        ViewBag.Types = types;
        ViewBag.Manufacturers = manufacturers;

        return View("CreateProductPanel");
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> CreateProduct(CreateProductViewModel product)
    {
        if (!ModelState.IsValid)
        {
            List<ProductTypeViewModel> types = (await _productRepository.GetProductTypeListAsync()).ToProductrTypeViewModelList();
            List<ProductManufacturerViewModel> manufacturers = (await _productRepository.GetProductManufacturerListAsync()).ToProductManufacturerViewModelList();

            ViewBag.Types = types;
            ViewBag.Manufacturers = manufacturers;

            ViewBag.CreateProductErrorMessage = "Невірні дані.";
            return View("CreateProductPanel", product);
        }

        try
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(wwwRootPath, @"images");
            var extension = Path.GetExtension(product.Image.FileName);

            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                product.Image.CopyTo(fileStreams);
            }

            string imageUrl = @"\images\" + fileName + extension;

            CreateProductRequest request = new()
            {
                Name = product.Name,
                Description = product.Description,
                TypeID = product.TypeID,
                ManufacturerID = product.ManufacturerID,
                Price = product.Price,
                PathToFile = imageUrl,
            };

            foreach (ProductCharacteristicViewModel characteristic in product.Characteristics)
            {
                request.Characteristics.Add(characteristic.ToCreateProductCharacteristicRequest());
            }

            await _productRepository.CreateProductAsync(request);

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            return View("CreateProductPanel", product);
        }
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProductPanel(Guid ID)
    {
        try
        {
            CreateProductViewModel product = (await _productRepository.GetProductByIDAsync(ID)).ToCreateProductViewModel();

            List<ProductTypeViewModel> types = (await _productRepository.GetProductTypeListAsync()).ToProductrTypeViewModelList();
            List<ProductManufacturerViewModel> manufacturers = (await _productRepository.GetProductManufacturerListAsync()).ToProductManufacturerViewModelList();

            ViewBag.Types = types;
            ViewBag.Manufacturers = manufacturers;

            return View("UpdateProductPanel", product);
        }
        catch (Exception)
        {
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct(CreateProductViewModel product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.UpdateProductErrorMessage = "Невірні дані.";
            return RedirectToAction("UpdateProductPanel", "Product", new { area = "Pharmacist" });
        }

        try
        {
            string imageUrl = GetPathValue(product);

            CreateProductRequest request = new()
            {
                ID = product.ID,
                Count = product.Count,
                Name = product.Name,
                Description = product.Description,
                TypeID = product.TypeID,
                ManufacturerID = product.ManufacturerID,
                Price = product.Price,
                PathToFile = imageUrl,
            };

            await _productRepository.UpdateProductAsync(request);

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            return View("UpdateProductPanel", product);
        }
    }

    private string GetPathValue(CreateProductViewModel product)
    {
        if (product.Image is not null)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(wwwRootPath, @"images");
            var extension = Path.GetExtension(product.Image.FileName);

            var oldImagePath = Path.Combine(wwwRootPath, product.PathToFile.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                product.Image.CopyTo(fileStreams);
            }

            return @"\images\" + fileName + extension;
        }
        else
        {
            return product.PathToFile;
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> RemoveProduct(Guid ID)
    {
        try
        {
            ProductViewModel product = (await _productRepository.GetProductByIDAsync(ID)).ToProductrViewModel();

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var oldImagePath = Path.Combine(wwwRootPath, product.PathToFile!.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            await _productRepository.RemoveProductByIDAsync(ID);

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (Exception)
        {
            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public IActionResult GetProductCharacteristicPanel()
    {
        return View("CharacteristicManagerPanel", new CreateProductTypeOrManufacturerViewModel());
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> AddProductType(CreateProductTypeOrManufacturerViewModel request)
    {
        if (request.Type is null)
        {
            ViewBag.AddTypeErrorMessage = "Введіть назву продукту.";
            return View("CharacteristicManagerPanel", new CreateProductTypeOrManufacturerViewModel());
        }

        try
        {
            await _productRepository.CreateProductTypeAsync(request.Type!.Name.Trim());

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (InvalidOperationException)
        {
            ViewBag.AddTypeErrorMessage = "Тип продукту з такою назвою вже існує.";
            return View("CharacteristicManagerPanel", new CreateProductTypeOrManufacturerViewModel());
        }
        catch (Exception)
        {
            return View("CharacteristicManagerPanel", new CreateProductTypeOrManufacturerViewModel());
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> AddProductManufacturer(CreateProductTypeOrManufacturerViewModel request)
    {
        if (request.Manufacturer is null)
        {
            ViewBag.AddManufacturerErrorMessage = "Введіть назву виробника.";
            return View("CharacteristicManagerPanel", new CreateProductTypeOrManufacturerViewModel());
        }

        try
        {
            await _productRepository.CreateProductManufacturerAsync(request.Manufacturer!.Name.Trim());

            return RedirectToAction("GetProductList", "Product", new { area = "Pharmacist" });
        }
        catch (InvalidOperationException)
        {
            ViewBag.AddManufacturerErrorMessage = "Виробник продукту з такою назвою вже існує.";
            return View("CharacteristicManagerPanel", new CreateProductTypeOrManufacturerViewModel());
        }
        catch (Exception)
        {
            return View("CharacteristicManagerPanel", new CreateProductTypeOrManufacturerViewModel());
        }
    }
}
