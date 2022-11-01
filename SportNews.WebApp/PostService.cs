using SportNews.Data;
using SportNews;

namespace SportNews.WebApp
{
    public class PostService
    {
        private readonly PostRepository postRepository;

        public PostService(PostRepository postRepository)
        {
            this.postRepository = postRepository;                
        }

        public IEnumerable<Post> GetAllByDiscipline(Discipline discipline)
        {
            var posts = postRepository.GetPosts();
            return posts.Where(post => discipline.Id == post.Discipline.Id);
        }

        public IEnumerable<Post> GetAllByQuery(string query)
        {
            var posts = postRepository.GetPosts();
            return posts.Where(post => post.Title.Contains(query) || post.Author.Name.Contains(query));
        }
    }
}
