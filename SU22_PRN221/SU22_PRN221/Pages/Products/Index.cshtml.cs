using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;
        private readonly INotyfService _notyf;
        public IndexModel(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        public IList<Product> Product { get; set; }

        [BindProperty]
        public Product Product2 { get; set; }

        public async Task OnGetAsync()
        {
            Product = await _context.products
                .Include(p => p.Category).ToListAsync();

        }
        [Obsolete]
        public async Task<IActionResult> OnPostCreate(IFormFile image, string ProductName, decimal Price, string Description, int CategoryId)
        {
            if (!ModelState.IsValid)
            {
                _notyf.Error("Required Fields Cant Be Null");
                return Page();
            }
            else
            {
                var check = _context.products.FirstOrDefault(x => x.ProductName == ProductName);
                if (check == null) return RedirectToPage("Index");
                if (image != null)
                {
                    try
                    {
                        string ext = Path.GetExtension(image.FileName);
                        if (ext == ".jpg" || ext == ".png" || ext == "jpeg" || ext == ".gif")
                        {
                            string Name = $"{ProductName}_{image.FileName}";

                            string AbsoluteSaveDirectory = $"/Medias/{ProductName}/";

                            string AbsoluteSaveFullPath = Directory.GetCurrentDirectory().Replace("\\", "/") + "/wwwroot" + AbsoluteSaveDirectory + Name;

                            //var AbsoluteSaveFullPath = Path.Combine(_environment.WebRootPath, AbsoluteSaveDirectory, image.FileName);

                            if (Directory.Exists(Path.GetDirectoryName(AbsoluteSaveFullPath)) == false)
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(AbsoluteSaveFullPath));
                            }

                            using (FileStream stream = new FileStream(AbsoluteSaveFullPath, FileMode.Create))
                            {
                                image.CopyTo(stream);
                            }

                            Product prod = new Product
                            {
                                ProductName = ProductName,
                                Price = Price,
                                Description = Description,
                                CategoryId = CategoryId,
                                ImagePath = $"{AbsoluteSaveDirectory}{Name}"
                            };

                            _context.products.Add(prod);
                        }
                    }
                    catch
                    {
                        _notyf.Warning("Some things may be wrong, please check again ");
                        return Page();
                    }

                }
            }
            await _context.SaveChangesAsync();
            _notyf.Success("Create Product Successfully");
            return RedirectToPage("./Index");
        }
    }
}
