using System.Web.Mvc;
using MemoDAL;
using MemoDAL.EF;
using Microsoft.AspNet.Identity;
using MemoDAL.Entities;

namespace MemoRise.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            unitOfWork.Answers.GetAll();

            string[] roles = { "Customer", "Admin", "Moderator" };
            if (!unitOfWork.Roles.RoleExists(roles[0]))
            {
                foreach (var role in roles)
                {
                    unitOfWork.Roles.Create(new Role { Name = role });
                }
                UserProfile up = new UserProfile { IsBlocked = false };

                User user = new User
                {
                    UserName = "user1",
                    Email = "user1@gmail.com",
                    UserProfile = up
                };
                var result = await unitOfWork.Users.CreateAsync(user, "123123");
                if (result.Succeeded)
                    result = unitOfWork.Users.AddToRole(user.Id, "Customer");

            }

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
