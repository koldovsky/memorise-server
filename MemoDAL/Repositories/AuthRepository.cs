using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MemoDAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private IUnitOfWork unitOfWork;

        public AuthRepository()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public AuthRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> FindAsync(UserLoginInfo loginInfo)
        {
            User user = await unitOfWork.Users.FindAsync(loginInfo);
            return user;
        }

        public async Task<IdentityUser> FindClient(string userId)
        {
            IdentityUser user = await unitOfWork.Users.FindByIdAsync(userId);
            return user;
        }

        public async Task<IdentityResult> CreateAsync(User user)
        {
            var result = await unitOfWork.Users.CreateAsync(user);
            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await unitOfWork.Users.AddLoginAsync(userId, login);
            return result;
        }
    }
}
