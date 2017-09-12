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
    class SingIn
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        ConverterToDto converterToDto = new ConverterToDto();

        public UserDTO GetUser(string login, string password)
        {
            User user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Login == login && x.Password == password);

            UserDTO userDTO;
            if (user != null)
            {
                userDTO = converterToDto.ConvertToUserDTO(user);
                return userDTO;
            }
            userDTO = new UserDTO();
            userDTO.Login = string.Empty;
            return userDTO;
        }
    }
}
