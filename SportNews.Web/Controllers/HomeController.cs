using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportNews;
using SportNews.Data;
using SportNews.Web.Models;
using SportNews.WebApp;
using System.Diagnostics;
using System.Reflection;

namespace SportNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostRepository postRepository;
        private readonly PostService postService;
        private readonly UserRepository userRepository;

        public HomeController(PostRepository postRepository, UserRepository userRepository, PostService postService)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
            this.postService = postService;
        }
        
        
        public IActionResult Index(string? query, int page = 1, int disciplineId=0)
        {
            if (HttpContext.Session.TryGetUser(out var user))
            {
                HttpContext.Session.Set(userRepository.GetById(user.Id));
            }

            var posts = query != null ? postService.GetAllByQuery(query).ToList() : disciplineId == 0 ? postRepository.GetPosts() : postRepository.GetPosts().Where(post => post.Discipline?.Id == disciplineId);           
            var model = new PageModel<Post>(posts, page, disciplineId, query);

            return View(model);
                       

        }

        //public IActionResult LoadByDiscipline(int id)
        //{
        //    var model = postRepository.GetPosts().Where(x=>x.Discipline.Id==id).ToList();
        //    return View("Index", model);
        //}
        
        public IActionResult Contacts()
        {
            return View();
        }
    }
}