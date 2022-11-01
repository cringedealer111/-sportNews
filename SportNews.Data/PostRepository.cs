namespace SportNews.Data
{
    public class PostRepository
    {
        private List<Post> posts;
        
        public PostRepository()
        {

            posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Месси блистает в «ПСЖ»: продвигает, обостряет, " +
                    "забивает. Больше никто не думает, что он топ только в «Барсе»",
                    Author = new User("Schelkov Andrey"),
                    Description = "После сложного дебютного сезона " +
                    "в Париже Лионель Месси возвращается на топовый " +
                    "уровень и по результативности. Он лучший ассистент" +
                    " топ-5 лиг (9 ассистов, столько же у Кевина де Брюйне)," +
                    " набил 6+9 по гол+пас (1,4 результативных действия в " +
                    "пересчете на 90 минут), больше него набрали лишь Эрлинг" +
                    " Холанд (17+3), Роберт Левандовски (12+4) и Неймар (9+7).",
                    Created = DateTime.Now,
                    Image = "https://s5o.ru/storage/simple/ru/edt/fb/15/8c/b4/rue1e3da00729.jpg",
                    Discipline = Discipline.GetById(1)
                },
                new Post
                {
                    Id = 2,
                    Title = "Русский талант превратился в хрусталь. Кравцов получил три травмы за четыре матча НХЛ!",
                    Author = new User("Schelkov Andrey"),
                    Description="Сложно понять, что за проклятие преследует Виталия Кравцова." +
                    " К концу октября у него четыре проведённых матча в НХЛ и сразу три травмы." +
                    " В первом случае явно перестарался Виктор Хедман из «Тампы», который " +
                    "слишком сильно нажал на голову русского форварда. Обстоятельства второго" +
                    " повреждения не были известны — о нём объявил главный тренер «Рейнджерс» " +
                    "Жерар Галлан, из-за него Виталий пропустил одну игру с «Айлендерс».",
                    Image = "https://img.championat.com/s/735x490/news/big/a/d/u-vitaliya-kravcova-tri-travmy_16671269161184557244.jpg",
                    Discipline = Discipline.GetById(2)
                }
            };

        }
        public void CreatePost(string title, string description,string imageLink, User user, int disciplineId)
        {
            if(user == null || title == null)
                throw new ArgumentNullException();

            var post = new Post(posts.Count + 1, title, DateTime.Now, description, user, imageLink, Discipline.GetById(disciplineId));

            posts.Add(post);
        }
        public List<Post> GetPosts()
        {
            return posts.OrderByDescending(x => x.Created).ToList();
        }
    }
}