using System.Threading.Tasks;
using MemoDAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MemoDAL.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> FindAsync(UserLoginInfo loginInfo);
        Task<IdentityUser> FindClient(string userId);
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
    }
}
