using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SU22_PRN221.Database;
using SU22_PRN221.Hubs;
using SU22_PRN221.Models;
using System.Collections.Generic;
using System.Linq;

namespace SU22_PRN221.Pages.Messages
{
    [Authorize(Roles = "Admin")]
    public class ReceptionistModel : PageModel
    {

        IHubContext<ChatHub> _chatHubContext;

        private readonly ApplicationDbContext _context;

        public ReceptionistModel(IHubContext<ChatHub> chatHubContext, ApplicationDbContext context)
        {
            _chatHubContext = chatHubContext;
            _context = context;
        }

        public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
        public string validatedUserId;

        public IActionResult OnGet(string userId)
        {

            if(userId != null)
            {
                User user = _context.Users.Find(userId);
                if(user != null)
                {
                    ChatMessages = _context.chatMessages.Include(cm => cm.User).Where(cm => cm.UserId == userId).ToList();
                    validatedUserId = userId;
                }
            }

            return Page();
        }

        public IActionResult OnPost(string userId, [FromBody] string content)
        {
            User user = _context.Users.Find(userId);
            if (user == null) return NotFound("User not found!");

            ChatMessage chatMessage = new ChatMessage()
            {
                Type = ChatMessage.Types.Receiver,
                UserId = user.Id,
                Content = content,
            };

            

            _context.chatMessages.Add(chatMessage);
            _context.SaveChanges();

            _chatHubContext.Clients.All.SendAsync($"administratorListenMessages-{userId}", new
            {
                content = chatMessage.Content,
                time = chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });
            _chatHubContext.Clients.User(user.Id).SendAsync("receiveMessage", new
            {
                content = chatMessage.Content,
                time = chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });

            return new OkResult();
        }

        
        
    }
}
