using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNews.Data
{
    public class UserRepository
    {

        private List<User> users = new List<User>();

        public UserRepository()
        {
            users.Add(new User("Andrey Schekov") { Id = 1, Password = "1", Login = "1", Role = Role.Moderator });
            users.Add(new User("Maksim Zolotarev") { Id = 2, Password = "2", Login = "2", Role = Role.Moderator });
        }      

        public bool TryRegistrate(string name, string login, string password)
        {
            if(!users.Contains(users.Single(user => user.Login == login)))
            {
                users.Add(new User(name) { Id = users.Count + 1, Password = password, Login = login, Role = Role.Common });
                return true;
            }
            return false;
                


        }
        public bool Authentificate(string login, string password, out User user)
        {
            user = users.FirstOrDefault(x => x.Login == login && x.Password == password);
            
            if (user == null)
                return false;
            else 
                return true;
        }
    }
}
