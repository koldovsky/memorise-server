using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    class SingUp
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public bool IsUserEmailExists(string email)
        {
            User user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Email == email);
            if(user != null)
            {
                return true;
            }
            return false;
        }

        public bool IsUserLoginExists(string login)
        {
            User user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool CreateUser(string login, string password, string email)
        {
            if (login != string.Empty && password != string.Empty && email != string.Empty)
            {
                if (!IsUserEmailExists(email) && !IsUserLoginExists(login))
                {
                    User user = new User
                    {
                        Email = email,
                        Password = password,
                        Login = login
                    };
                    unitOfWork.Users.Create(user);
                    unitOfWork.Save();
                    unitOfWork.Dispose();
                    return true;
                }
            }
            return false;
        }
    }
}
