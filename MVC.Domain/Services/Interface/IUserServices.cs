using Infraestructure.Entity.Models.Security;
using MVC.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Services.Interface
{
    public interface IUserServices
    {
        #region Autentication
        ResponseDto Login(UserDto user);
        #endregion
        #region Methods CRUD
        List<UserEntity> GetAll();
         Task<ResponseDto> Register(UserDto data);
        #endregion
    }
}
