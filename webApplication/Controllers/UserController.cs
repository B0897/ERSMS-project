using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApplication.Models;
namespace webApplication.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersList()
        {
            return await _context.User.ToListAsync();
        }

        [HttpGet("id/{ID}")]
        public async Task<ActionResult<User>> GetUserById(int ID)
        {
            try
            {
                var person = _context.User.Find(ID);
                if (person == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(person);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("paypal/{Login}")]
        public async Task<ActionResult<User>> GetUserPaypal(string login)
        {
            try
            {
                List<User> userList = await _context.User.ToListAsync();
                User user = userList.Find(x => x.Login == login);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user.Paypal);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            int idToAdd = (int)(from n in _context.User orderby n.ID descending select n.ID).FirstOrDefault();
            user.ID = idToAdd + 1;

            GoogleAuthenticator tp = new GoogleAuthenticator();
            string randomString = Transcoder.Base32Encode(tp.randomBytes);

            string ProvisionUrl = tp.UrlEncode(String.Format("otpauth://totp/{0}?secret={1}", "PasswordManager", randomString));
            string url = String.Format("http://chart.apis.google.com/chart?cht=qr&chs={0}x{1}&chl={2}", 200, 200, ProvisionUrl);

            string builder = "";
            foreach (byte b in tp.randomBytes)
            {
                builder = builder + b + " ";
            }
            user.HashedPassword = AES.Encrypt(user.HashedPassword, user.HashedPassword, "00000000000");
            user.Secret = builder;
            _context.User.Add(user);
            _context.SaveChanges();

            return Ok(url + " " + user.ID.ToString());
        }

        [HttpPost("OTP")]
        public async Task<ActionResult<Animal>> CheckOTP([FromForm]string OTP, [FromForm]string ID)
        {
            List<User> userList = _context.User.ToList();
            User user = userList.Find(x => x.ID == Int32.Parse(ID));
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
            if (OTP == tp.generateResponseCode(tp.getCurrentInterval(), b))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }


        [HttpDelete("(ID)")]
        public async Task<ActionResult<User>> DelUser(int ID)
        {
            try
            {
                var user = await _context.User.FindAsync(ID);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.User.Remove(user);
                    await _context.SaveChangesAsync();
                    return Ok();
                }

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult<User>> Edit(int ID, User editeduser)
        {
            try
            {
                var user = await _context.User.FindAsync(ID);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    editeduser.ID = user.ID;
                    _context.User.Remove(user);
                    _context.User.Add(editeduser);
                    await _context.SaveChangesAsync();
                    return Ok();
                }

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
