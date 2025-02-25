using instagram_application.BLL;
using instagram_application.Models;
using Microsoft.AspNetCore.Mvc;

namespace instagram_application.Controllers {
    public class PostController : Controller {
        private readonly PostServices _postServices;

        public PostController(PostServices postServices) {
            _postServices = postServices;
        }

        public IActionResult Index() {
            List<Post> posts = _postServices.GetPosts();
            return View(posts);
        }
    }
}
