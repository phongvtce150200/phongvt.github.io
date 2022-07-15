using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        public IndexModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; }

        public async Task OnGetAsync()
        {
            Category = await _context.categories.ToListAsync();
        }

        public IActionResult OnPostCreate(string categoryName)
        {
            var addCate = new Category
            {
                CategoryName = categoryName
            };
            _context.Add(addCate);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete(int id)
        {
            var cate = _context.categories.Find(id);
            _context.categories.Remove(cate);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFind(int id)
        {
            var cate = _context.categories.Find(id);
            return new JsonResult(cate);
        }
        public IActionResult OnPostUpdate(int id,string categoryName)
        {
            var cate = _context.categories.Find(id);
            cate.CategoryName = categoryName;
            cate.CreatedDate = DateTime.Now;
            cate.IsActive = true;
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
