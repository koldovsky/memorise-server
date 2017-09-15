using System.Linq;
using System;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;


namespace MemoBll
{
    public class SignInBll
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public UserDTO GetUser(string login, string password)
        {
            User user = unitOfWork.Users.GetOneElementOrDefault(x => x.Login == login && x.Password == password);

            UserDTO userDTO;
            if (user != null)
            {
                userDTO = converterToDto.ConvertToUserDTO(user);
                return userDTO;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
