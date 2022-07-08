﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221_FoodStore.Data;
using SU22_PRN221_FoodStore.Models;

namespace SU22_PRN221_FoodStore.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly SU22_PRN221_FoodStore.Data.ApplicationDbContext _context;

        public DetailsModel(SU22_PRN221_FoodStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
