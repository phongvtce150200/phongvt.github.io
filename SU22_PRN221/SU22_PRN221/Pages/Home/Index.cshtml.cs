using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;
using System.Collections.Generic;
using System.Linq;

namespace SU22_PRN221.Pages.Home
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
            Categories = _context.categories.ToList();
            Products = _context.products.Include(p => p.Category).ToList();
        }
    }
}
