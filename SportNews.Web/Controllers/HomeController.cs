using Microsoft.AspNetCore.Mvc;
using SportNews;
using SportNews.Data;
using SportNews.Web.Models;
using System.Diagnostics;

namespace SportNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostRepository postRepository;


        public HomeController(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public IActionResult Index(int page = 1, int disciplineId=0)
        {                       
            var posts = disciplineId == 0 ? postRepository.GetPosts() : postRepository.GetPosts().Where(post => post.Discipline.Id == disciplineId);                                   

            var model = new PageModel<Post>(posts, page);

            return View("Index", model);
        }

        public IActionResult LoadByDiscipline(int id)
        {
            var model = postRepository.GetPosts().Where(x=>x.Discipline.Id==id).ToList();
            return View("Index", model);
        }
        
        public IActionResult Contacts()
        {
            return View();
        }
    }
}