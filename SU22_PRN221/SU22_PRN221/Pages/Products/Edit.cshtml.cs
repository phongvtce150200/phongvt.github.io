using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        [Obsolete]
        public EditModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.products
                .Include(p => p.Category).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
           ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.

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

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.ProductId == id);
        }
    }
}
