using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using DataAccess.Contexts;
using HireSphere.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HireSphere.ViewModels
{
    public class ConversationController(IConversationServices _customerService, ILogger<ConversationController> logger) : Controller
    {
        public IActionResult GetConversationById(int? conversationId)
        {
            if (!conversationId.HasValue) return BadRequest();
            var conversation = _customerService.GetConversationById(conversationId.Value);
            return conversation is null ? NotFound() : View(conversation);
        }

    }
}
