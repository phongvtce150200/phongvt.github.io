using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221_FoodStore.Data;
using SU22_PRN221_FoodStore.Models;

namespace SU22_PRN221_FoodStore.Pages.Shared.Categories
{
    public class IndexModel : PageModel
    {
        private readonly SU22_PRN221_FoodStore.Data.ApplicationDbContext _context;

        public IndexModel(SU22_PRN221_FoodStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.categories.ToListAsync();
        }
    }
}
