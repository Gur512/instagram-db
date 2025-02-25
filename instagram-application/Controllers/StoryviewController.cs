using instagram_application.BLL;
using instagram_application.Models;
using Microsoft.AspNetCore.Mvc;

namespace instagram_application.Controllers {
    public class StoryviewController : Controller {
        private readonly StoryviewServices _storyviewServices;

        public StoryviewController(StoryviewServices storyviewServices) {
            _storyviewServices = storyviewServices;
        }
    
        public IActionResult Index(int storyId) {
            Console.WriteLine($"Fetching viewers for story with ID: {storyId}");

            List<User> storyViewers = _storyviewServices.GetStoryViewers(storyId);

            Console.WriteLine($"Found {storyViewers.Count} viewers");

            if (storyViewers == null || !storyViewers.Any()) {
                ViewBag.Message = "No users have viewed this story yet.";
                return View(new List<User>());
            }

            return View(storyViewers);
        }
    }
}
