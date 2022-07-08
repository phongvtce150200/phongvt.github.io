using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SU22_PRN221_FoodStore.Data;
using SU22_PRN221_FoodStore.Models;

namespace SU22_PRN221_FoodStore.Pages.Shared.Categories
{
    public class CreateModel : PageModel
    {
        private readonly SU22_PRN221_FoodStore.Data.ApplicationDbContext _context;

        public CreateModel(SU22_PRN221_FoodStore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
