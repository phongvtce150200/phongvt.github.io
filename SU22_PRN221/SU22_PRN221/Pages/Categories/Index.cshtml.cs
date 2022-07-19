using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;
        private readonly INotyfService _notyf;
        public IndexModel(SU22_PRN221.Database.ApplicationDbContext context,INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
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
            var check = _context.categories.FirstOrDefault(x => x.CategoryName == categoryName);
            if (check == null)
            {
                _context.Add(addCate);
                _context.SaveChanges();
                _notyf.Success("Create Category Successfully");
                return RedirectToPage("Index");
            }
            _notyf.Warning("Category is exists");
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete(int id)
        {
            var cate = _context.categories.Find(id);
            _context.categories.Remove(cate);
            _context.SaveChanges();
            _notyf.Success("Delete Category Successfully");
            return RedirectToPage("Index");
        }

        public IActionResult OnGetFind(int id)
        {
            var cate = _context.categories.Find(id);
            _notyf.Success("Find Category Successfully");
            return new JsonResult(cate);
        }
        public IActionResult OnPostUpdate(int id,string categoryName)
        {
            var cate = _context.categories.Find(id);
            cate.CategoryName = categoryName;
            cate.CreatedDate = DateTime.Now;
            cate.IsActive = true;
            var check = _context.categories.FirstOrDefault(x => x.CategoryName == categoryName);
            if (check == null)
            {
                _context.SaveChanges();
                _notyf.Success("Update Category Successfully");
                return RedirectToPage("Index");
            }
            _notyf.Warning("Category is exists");
            return RedirectToPage("Index");
        }

        public void OnPostSearchDate(DateTime startdate, DateTime enddate)
        {

            //Category = (from x in _context.categories where (x.CreatedDate <= startdate) && (x.CreatedDate >= enddate) select x).ToList();
            Category = _context.categories.Where(x => x.CreatedDate >= startdate && x.CreatedDate <= enddate).ToList();

        }
    }
}
