using instagram_application.BLL;
using instagram_application.Models;
using Microsoft.AspNetCore.Mvc;

namespace instagram_application.Controllers {
    public class StoryController : Controller {
        private readonly StoryServices _storyServices;

        public StoryController(StoryServices storyServices) {
            _storyServices = storyServices;
        }

        public IActionResult Index() {
            List<Story> stories = _storyServices.GetStories();
            return View(stories);
        }

    }
}
