using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using BloggingSystem.Data;
using BloggingSystem.Model;
using BloggingSystem.WebApi.Models;

namespace BloggingSystem.WebApi.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinNameLength = 6;
        private const int MaxNameLength = 30;
        private const int Sha1Length = 40;
        private const int SessionKeyLength = 50;
        private const string ValidUsernameCharacters =
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.";
        private const string ValidNicknameCharacters =
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.- ";
        private const string SessionKeyCharacters =
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        private static readonly Random rand = new Random();

        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystmContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateNickname(model.Displayname);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameToLower = model.Username.ToLower();
                    var nicknameToLower = model.Displayname.ToLower();
                    User user = context.Users.FirstOrDefault(usr => usr.Username == usernameToLower ||
                                                                    usr.Displayname == nicknameToLower);
                    if (user != null)
                    {
                        throw new InvalidOperationException("User exists");
                    }

                    user = new User()
                    {
                        Username = usernameToLower,
                        Displayname = model.Displayname,
                        AuthCode = model.AuthCode
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    user.SessionKey = this.GenerateSessionKey(user.Id);
                    context.SaveChanges();

                    LoggedUserModel loggedModel = new LoggedUserModel()
                    {
                        Displayname = user.Displayname,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }

            });
            return responseMsg;
        }

        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystmContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameToLower = model.Username.ToLower();
                    var user = context.Users.FirstOrDefault(usr => usr.Username == usernameToLower &&
                                                                   usr.AuthCode == model.AuthCode);
                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel()
                    {
                        Displayname = user.Displayname,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                    return response;
                }

            });
            return responseMsg;
        }

        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystmContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);

                    user.SessionKey = null;
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            });
            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder sessionKeyBuilder = new StringBuilder(SessionKeyLength);
            sessionKeyBuilder.Append(userId);
            while (sessionKeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyCharacters.Length);
                sessionKeyBuilder.Append(SessionKeyCharacters[index]);
            }
            return sessionKeyBuilder.ToString();
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (MinNameLength > username.Length || username.Length > MaxNameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Username must be between {0} and {1} symbols",
                    MinNameLength, MaxNameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(string.Format("Username must contain valid characters"));
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (MinNameLength > nickname.Length || nickname.Length > MaxNameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Nickname must be between {0} and {1} symbols",
                    MinNameLength, MaxNameLength));
            }
            else if (nickname.Any(ch => !ValidNicknameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(string.Format("Nickname must contain valid characters"));
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("The password should be encrypted");
            }
        }
    }
}
