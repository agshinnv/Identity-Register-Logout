using Practice.Helpers.Requests;
using Practice.Models;
using Practice.ViewModels.Products;

namespace Practice.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllWithImagesAsync();
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        List<ProductVM> GetMappedDatas(List<Product> products);
        Task<List<Product>> GetAllPaginateAsync(int page, int take = 4);
        Task<int> GetCountAsync();
        Task CreateAsync(Product product);
        Task DeleteAsync(Product product);
        Task DeleteProductImageAsync(DeleteProductImageRequest request);
        Task EditAsync(Product product,ProductEditVM editedProduct);
        Task SetMainImage(Product product, int id);
        
    }
}
