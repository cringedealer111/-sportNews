using Microsoft.AspNetCore.Mvc;
using SportNews;
using SportNews.Data;
using SportNews.Web;

namespace SportNews.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly PostRepository postRepository;
        public AdministrationController(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetUser(out User user))
            {
                if(user.Role == Role.Moderator)
                {
                    return View("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddPost(string title, string description, string imageLink, int disciplineId)
        {
            HttpContext.Session.TryGetUser(out User user);
            postRepository.CreatePost(title, description, imageLink, user, disciplineId);
            return RedirectToAction("Index", "Home");
        }
    }
}
