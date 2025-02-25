using instagram_application.BLL;
using instagram_application.Models;
using Microsoft.AspNetCore.Mvc;

namespace instagram_application.Controllers {
    public class CommentController : Controller {
        private readonly CommentServices _commentServices;
        private readonly UserServices _userservices;

        public CommentController(CommentServices commentServices, UserServices userRepository) {
            _commentServices = commentServices;
            _userservices = userRepository;
        }

        [HttpGet]
        public IActionResult AddComment(string postId) {
            List<Comment> comments = _commentServices.GetCommentsByPostId(postId);
            return PartialView("_CommentView", comments);
        }

        [HttpPost]
        public IActionResult AddComment(string postId, string commentText) {
            if (string.IsNullOrEmpty(commentText)) {
                TempData["ErrorMessage"] = "Comment cannot be empty.";
                return RedirectToAction("Profile", new { id = User.Identity.Name });
            }

            int userId = _userservices.GetUserIdByUsername(User.Identity.Name);

            if (userId == 0) {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Profile", new { id = User.Identity.Name });
            }

            Comment newComment = new Comment {
                PostId = postId,
                UserId = userId,
                CommentText = commentText,
            };

            try {
                _commentServices.AddComment(newComment);  // Add the comment to DB
                TempData["SuccessMessage"] = "Comment added successfully!";
            }
            catch (Exception ex) {
                TempData["ErrorMessage"] = "Error while adding comment: " + ex.Message;
            }

            // Now, reload the post's comments and return to the profile view
            List<Comment> comments = _commentServices.GetCommentsByPostId(postId);
            return PartialView("_CommentView", comments);  // Return the updated comment section
        }
    }
}
