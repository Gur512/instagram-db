using Microsoft.AspNetCore.Mvc;

namespace instagram_application.Controllers {
    public class ImageController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
