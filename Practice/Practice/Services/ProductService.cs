using Microsoft.EntityFrameworkCore;
using Practice.Controllers;
using Practice.Data;
using Practice.Helpers.Extentions;
using Practice.Helpers.Requests;
using Practice.Models;
using Practice.Services.Interfaces;
using Practice.ViewModels.Products;

namespace Practice.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductService(AppDbContext context, 
                              IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.Category)
                                          .Include(m => m.ProductImages)
                                          .ToListAsync();
        }

        public async Task<List<Product>> GetAllPaginateAsync(int page, int take = 4)
        {
            return await _context.Products.Include(m => m.Category)
                                          .Include(m => m.ProductImages)
                                          .Skip((page - 1) * take)
                                          .Take(take)
                                          .ToListAsync();
        }

        public async Task<List<Product>> GetAllWithImagesAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Where(m => !m.SoftDeleted)
                                          .Include(m => m.Category)
                                          .Include(m => m.ProductImages)
                                          .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public List<ProductVM> GetMappedDatas(List<Product> products)
        {
            return products.Select(m => new ProductVM
            {

                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Image = m.ProductImages.FirstOrDefault(m=>m.IsMain).Name,
                Category = m.Category.Name

            }).ToList();
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductImageAsync(DeleteProductImageRequest request)
        {
            var product = await _context.Products.Where(m=>m.Id == request.ProductId)
                                                 .Include(m => m.ProductImages)
                                                 .FirstOrDefaultAsync();

            var image = product.ProductImages.FirstOrDefault(m=>m.Id == request.ImageId);

            string path = _env.GenerateFilePath("img",image.Name);

            path.DeleteFileFromLocal();

            product.ProductImages.Remove(image);

            await _context.SaveChangesAsync();

        }

        public async Task EditAsync(Product product, ProductEditVM editedProduct)
        {
            if(editedProduct.NewImages != null)
            {
                foreach (var item in editedProduct.NewImages)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;
                    string path = _env.GenerateFilePath("img", fileName);
                    await item.SaveFileToLocalAsync(path);
                    product.ProductImages.Add(new ProductImage { Name = fileName });
                }

                
            }
            product.Name = editedProduct.Name;
            product.Description = editedProduct.Description;
            product.CategoryId = editedProduct.CategoryId;
            product.Price = decimal.Parse(editedProduct.Price.Replace(".",","));

            await _context.SaveChangesAsync();

        }

        public async Task SetMainImage(Product product, int id)
        {
            var existImages = product.ProductImages.Where(m => m.IsMain == true);

            foreach (var item in existImages)
            {
                item.IsMain = false;
            }

            product.ProductImages.FirstOrDefault(m=>m.Id == id).IsMain = true;
            
            await _context.SaveChangesAsync();
        }
    }
}
