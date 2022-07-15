using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SU22_PRN221.Models;
using System.Collections.Generic;
using System.Linq;

namespace SU22_PRN221.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly SU22_PRN221.Database.ApplicationDbContext _context;

        public IndexModel(SU22_PRN221.Database.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }
        public void OnGet()
        {
            Users = _context.users.ToList();
        }
    }
}
