using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SU22_PRN221.Database;

namespace SU22_PRN221.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public void OnGet()
        {
        }
    }
}
