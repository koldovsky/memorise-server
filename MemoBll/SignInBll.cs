using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using MemoDTO;
using System;
using System.Linq;

namespace MemoBll
{
	public class SignInBll
    {
        IUnitOfWork unitOfWork;
        IConverterToDTO converterToDto;

        public SignInBll()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
            this.converterToDto = new ConverterToDTO();
        }

        public SignInBll(IUnitOfWork unitOfWork, IConverterToDTO converterToDto)
        {
            this.unitOfWork = unitOfWork;
            this.converterToDto = converterToDto;
        }

        //public UserDTO GetUser(string login, string password)
        //{
        //    User user = unitOfWork.Users
        //        .GetAll().FirstOrDefault(x => 
        //        x.Login == login && x.Password == password);

        //    return user != null 
        //        ? converterToDto.ConvertToUserDTO(user) 
        //        : throw new ArgumentNullException();
        //}
    }
}
