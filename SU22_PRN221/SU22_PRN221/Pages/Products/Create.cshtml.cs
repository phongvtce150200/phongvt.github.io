using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        [Obsolete]
        public CreateModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        [Obsolete]
        public async Task<IActionResult> OnPostAsync(IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if (image != null)
                {
                    try
                    {
                        string ext = Path.GetExtension(image.FileName);
                        if (ext == ".jpg" || ext == ".png" || ext == "jpeg" || ext == ".gif")
                        {
                            string Name = $"{Product.ProductName}_{image.FileName}";

                            string AbsoluteSaveDirectory = $"/Medias/{Product.ProductName}/";

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

                            Product.ImagePath = $"{AbsoluteSaveDirectory}{Name}";
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
                else
                {
                    Product.ImagePath = null;
                }
            }

            _context.products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
