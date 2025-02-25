using instagram_application.BLL;
using instagram_application.DAL;
using instagram_application.Models;
using Microsoft.AspNetCore.Mvc;

namespace instagram_application.Controllers {
    public class DirectMessageController : Controller {
        private readonly DirectMessageServices _messageService;
        private readonly UserServices _userService;

        public DirectMessageController(DirectMessageServices messageService, UserServices userService) {
            _messageService = messageService;
            _userService = userService;
        }

        public IActionResult Index(int receiverId) {
            string username = User.Identity.Name;
            int senderId = _userService.GetUserIdByUsername(username); 

            List<DirectMessage> messages = _messageService.GetDirectMessages(senderId, receiverId);
            if (messages == null || messages.Count == 0) {
                TempData["ErrorMessage"] = "No conversation found.";
            }

            ViewBag.ReceiverUserId = receiverId;
            return View(messages);
        }

        public IActionResult SelectReceiver() {
            List<User> users = _userService.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult SendMessage(int receiverId) {
            ViewBag.ReceiverId = receiverId;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(int receiverid, string messageText) {
            if (receiverid == 0 || string.IsNullOrEmpty(messageText)) {
                TempData["ErrorMessage"] = "Please select a user and enter a message.";
                return RedirectToAction("SendMessage");
            }

            string username = User.Identity.Name;
            int senderId = _userService.GetUserIdByUsername(username);

            if (senderId == 0 || receiverid == 0) {
                return NotFound("User not found.");
            }

            _messageService.SendMessage(senderId, receiverid, messageText);

            return RedirectToAction("Index", "DirectMessage", new { receiverId = receiverid });
        }
    }
}
