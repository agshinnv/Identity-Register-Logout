using FrontToBack.Data;
using FrontToBack.Helpers.Extentions;
using FrontToBack.Models;
using FrontToBack.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace FrontToBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.OrderByDescending(m=>m.Id)
                                                                 .ToListAsync();

            List<CategoryVM> model = categories.Select(m=>new CategoryVM { Id = m.Id, Name = m.Name })
                                               .ToList();              


            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            bool existCategory = await _context.Categories.AnyAsync(m=>m.Name.Trim() == category.Name.Trim());

            if(existCategory)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }


            if (!category.Image.CheckFileSize(500))
            {
                ModelState.AddModelError("Image", "Image size must be max 500 kb");
                return View();
            }

            if (!category.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "File type must be only image");
                return View();
            }



            string fileName = Guid.NewGuid().ToString() + "-" + category.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/images", fileName);

            await category.Image.SaveFileToLocalAsync(path);
            
            await _context.Categories.AddAsync(new Category { Name = category.Name, Image = fileName});
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _context.Categories.Where(m=>m.Id == id)
                                                         .Include(m=>m.Products)
                                                         .FirstOrDefaultAsync();      
            
            if(category is null) return NotFound();

            CategoryDetailVM model = new()
            {
                Name = category.Name,
                Image = category.Image,
                ProductCount = category.Products.Count()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _context.Categories.Where(m => m.Id == id)
                                                         .Include(m => m.Products)
                                                         .FirstOrDefaultAsync();

            if (category is null) return NotFound();

            _context.Categories.Remove(category);
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id is null) return BadRequest();

            Category category = await _context.Categories.Where(m => m.Id == id)
                                                         .FirstOrDefaultAsync();

            if (category is null) return NotFound();



            return View(new CategoryEditVM { Id = category.Id, Name = category.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id is null) return BadRequest();

            Category existCategory = await _context.Categories.Where(m => m.Id == id)
                                                              .FirstOrDefaultAsync();

            if (existCategory is null) return NotFound();

            existCategory.Name = category.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }


    }
}
