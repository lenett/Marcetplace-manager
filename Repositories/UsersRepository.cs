using Microsoft.AspNetCore.Identity;
using MM.Areas.Identity.Models;
using MM.Areas.Identity.ViewModels;

namespace MM.Repositories
{
    public interface IUser
    {
        public Task<string> GetCurrentUserIdByNameAsync(string userName);
        public Task<IdentityResult> CreateUserAsync(UserManager<User> userManager, User user, RegisterViewModel model);
        public Task<string> GetCurrentUserIdAsync(HttpContext httpContext);
    }

    public class UsersRepository:IUser
    {
        private readonly UserManager<User> _userManager;

        public UsersRepository(UserManager<User> userManager)
        {
            _userManager=userManager;
        }

        public async Task<string> GetCurrentUserIdByNameAsync(string userName)
        {
            User currentUser = await _userManager.FindByNameAsync(userName);
            return currentUser.Id;
        }
        
        public async Task<IdentityResult> CreateUserAsync(UserManager<User> userManager, User user, RegisterViewModel model)
        {
            return await userManager.CreateAsync(user, model.Password);
        }

        public async Task<string> GetCurrentUserIdAsync(HttpContext httpContext)
        {
            string currentUserId = httpContext.Session.GetString("currentUserId");
            if (currentUserId==null)
            {
                string currentUser = httpContext.User.Identity.Name;
                currentUserId =  await GetCurrentUserIdByNameAsync(currentUser);
                httpContext.Session.SetString("currentUserId", currentUserId);
            }

            return currentUserId;
        }
    }
}
