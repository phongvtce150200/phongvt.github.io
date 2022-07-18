using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SU22_PRN221.Database;
using SU22_PRN221.Models;
using System.Collections.Generic;
using System.Linq;

namespace SU22_PRN221.Pages.Messages
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        ApplicationDbContext _context;

        public ChatController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("LoadUsers")]
        public IActionResult LoadUsers()
        {
            var userMessages = _context.chatMessages.Include(cm => cm.User).AsEnumerable().GroupBy(c => c.UserId);
            List<User> userList = new List<User>();
            foreach(var userMessage in userMessages)
            {
                userList.Add(_context.Users.Find(userMessage.Key));
            }

            return Ok(userList.Select(user => new
            {
                username=user.UserName,
                userId=user.Id,
            }));

        }

    }
}
