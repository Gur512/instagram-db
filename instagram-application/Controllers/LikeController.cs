using instagram_application.BLL;
using instagram_application.DAL;
using instagram_application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace instagram_application.Controllers {
    public class LikeController : Controller {
        private readonly InstagramDatabaseContext _context;
        private readonly UserRepository _userRepository;
        private readonly PostServices _postServices;

        public LikeController(InstagramDatabaseContext context, UserRepository userRepository, PostServices postServices) {
            _context = context;
            _userRepository = userRepository;
            _postServices = postServices;
        }

        [HttpGet]
        public IActionResult GetLikes(string postId) {
            int likeCount = _postServices.GetLikes(postId).Count;
            return Json(new { count = likeCount });
        }
        [HttpPost]
        public IActionResult LikePost(string postId) {
            string username = User.Identity.Name;
            int userId = _userRepository.GetUserIdByUsername(username);

            if (userId == 0) {
                return Content("User not found");
            }

            // Check if the user already liked the post
            Like existingLike = _context.Likes
                .FirstOrDefault(like => like.PostId == postId && like.UserId == userId);

            if (existingLike == null) {
                // Add the like if not already present
                _postServices.AddLikeToPost(postId, userId);
            }

            // Retrieve the updated post with like count
            Post post = _postServices.GetPostById(postId);

            if (post == null) {
                return NotFound("Post not found");
            }

            // Return to the profile page with the updated like count
            return RedirectToAction("Profile", "User", new { id = userId });
        }
    }
}
