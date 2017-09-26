using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System.Linq;

namespace MemoBll
{
	public class SignUpBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDTO converterToDto = new ConverterToDTO();

        //public bool IsUserEmailExists(string email)
        //{
        //    User user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Email == email);
        //    return user != null;
        //}

        //public bool IsUserLoginExists(string login)
        //{
        //    User user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Login == login);
        //    if (user != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool CreateUser(string login, string password, string email)
        //{
        //    if (login != string.Empty && password != string.Empty && email != string.Empty)
        //    {
        //        if (!IsUserEmailExists(email) && !IsUserLoginExists(login))
        //        {
        //            User user = new User
        //            {
        //                Email = email,
        //                Password = password,
        //                Login = login
        //            };
        //            unitOfWork.Users.Create(user);
        //            unitOfWork.Save();
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
