using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MM.Areas.Goods.Models;
using MM.Models;
using System.IO;
using MM.Areas.Goods.ViewModels;
using MM.Data;
using Microsoft.AspNetCore.Authorization;

namespace MM.Areas.Goods.Controllers
{
    [Authorize]
    [Area("Goods")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsModel profuctModel)
        {

            Products product = new Products();
            //if (profuctModel.Picture != null)
            //{
            //    byte[] imageData = null;
            //    // считываем переданный файл в массив байтов
            //    using (var binaryReader = new BinaryReader(profuctModel.Picture.OpenReadStream()))
            //    {
            //        imageData = binaryReader.ReadBytes((int)profuctModel.Picture.Length);
            //    }
            //    // установка массива байтов
            //    profuctModel.Picture = imageData;
            //}
            product.Name = profuctModel.Name;
            product.Description = profuctModel.Description;
            

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Products product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Products product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

    }
}
