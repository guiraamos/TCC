using Microsoft.AspNetCore.Mvc;
using MsAuthenticateService.AuthenticationDB;
using MsAuthenticateService.Entiities;

namespace MsAuthenticateService.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        [HttpPost]
        public bool Authenticate(string username, string password)
        {
            string userLine = UserDAO.GetUserByUsername(username);
            if (userLine != null)
            {
                string[] userSplited = userLine.Split(';');
                User user = new User(userSplited[0], userSplited[1]);
                return user.Password == password;
            }
            return false;
        }
    }
}
