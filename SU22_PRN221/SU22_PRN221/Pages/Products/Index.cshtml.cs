using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;

namespace SU22_PRN221.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        public IndexModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.products
                .Include(p => p.Category).ToListAsync();
        }
    }
}
