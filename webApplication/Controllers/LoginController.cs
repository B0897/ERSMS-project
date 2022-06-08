using Microsoft.AspNetCore.Mvc;
using webApplication.Models;

namespace webApplication.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginContext _context;
        private UserContext _context2;

        public LoginController(LoginContext context, UserContext context2)
        {
            _context = context;
            _context2 = context2;
        }

        [HttpPost]
        public async Task<ActionResult<Login>> CheckUser(Login log)
        {
            List<User> userList = _context2.User.ToList();
            User user = userList.Find(x => x.Login == log.login);
            var decryptedPassword = AES.Decrypt(user.HashedPassword, log.password, "00000000000");
            byte[] b = new byte[10];
            string[] subs = user.Secret.Split(' ');
            int i = 0;
            foreach (var sub in subs)
            {
                if (i == 10) break;
                b[i] = Convert.ToByte(Convert.ToInt32(sub));
                i++;
            }
            GoogleAuthenticator tp = new GoogleAuthenticator();
            if (decryptedPassword == log.password&&log.code == tp.generateResponseCode(tp.getCurrentInterval(), b))
            {
                return Ok(user.ID);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
