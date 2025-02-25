using instagram_application.BLL;
using instagram_application.Models;
using Microsoft.AspNetCore.Mvc;

namespace instagram_application.Controllers {
    public class UserController : Controller {
        private readonly UserServices _userServices;
        private readonly FollowServices _followServices;
        private readonly PostServices _postServices;
        private readonly StoryviewServices _storyviewServices;

        public UserController(UserServices userServices, FollowServices followServices, PostServices postServices, StoryviewServices storyviewServices) {
            _userServices = userServices;
            _followServices = followServices;
            _postServices = postServices;
            _storyviewServices = storyviewServices;
        }

        public IActionResult Index() {
            List<User> users = _userServices.GetUsers();
            return View(users);
        }

        public IActionResult Profile(int id, string postIdToLike) {
            Console.WriteLine("Profile ID: " + id);

            User user = _userServices.GetUserById(id);

            if (user == null) {
                TempData["ErrorMessage"] = "User not found!";
                return RedirectToAction("Index", "Home"); 
            }

            user.Posts = _postServices.GetPosts(id);
            foreach (Post post in user.Posts) {
                post.Comments = _userServices.GetComments(post.PostId);
                foreach (Comment comment in post.Comments) {
                    if (comment.UserId.HasValue) {
                        var commentUser = _userServices.GetUserById(comment.UserId.Value);
                        Console.WriteLine($"Comment by: {commentUser.UserName}");
                    } else {
                        Console.WriteLine("Comment has no associated user.");
                    }
                }
            }

            user.Posts = _userServices.GetImages(id);
            user.Stories = _userServices.GetStories(id);
            foreach(Story story in user.Stories) {
                if (story.ExpirationTime <= DateTime.Now) {
                    ViewBag.IsExpired = true; 
                } else {
                    ViewBag.IsExpired = false;
                }
            }

            List<User> followers = _followServices.GetFollowers(id);
            List<User> following = _followServices.GetFollowing(id);

            ViewBag.Followers = followers;
            ViewBag.Following = following;

            if (postIdToLike != null && postIdToLike != "") {
                Post postToLike = user.Posts.FirstOrDefault(p => p.PostId == postIdToLike);
                if (postToLike != null) {
                    _postServices.AddLikeToPost(postIdToLike, id);
                    TempData["SuccessMessage"] = "You liked the post!";
                }
            }

            return View(user);
        }

        public IActionResult Storyview(int storyId) {
            List<User> viewers = _storyviewServices.GetStoryViewers(storyId);

            if (viewers == null || !viewers.Any()) {
                TempData["ErrorMessage"] = "No users have viewed this story yet.";
                return RedirectToAction("Profile", new { id = User.Identity.Name });
            }

            ViewBag.Viewers = viewers;

            return View();
        }

        public IActionResult CreateDM() {
            var users = _userServices.GetUsers(); 
            return View(users);  
        }
    }
}
