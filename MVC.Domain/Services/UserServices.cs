using Common.Utils.Utils;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Security;
using MVC.Domain.Dto;
using MVC.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Utils.Enums.Enums;

namespace MVC.Domain.Services
{
    public class UserServices:IUserServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IConfiguration _configuration;
        #endregion

        #region Builder
        public UserServices(IUnitOfWork unitOfWork )
        { //IConfiguration configuration
            _unitOfWork = unitOfWork;
            //_configuration = configuration;
        }
        #endregion
        #region Autentication
        public ResponseDto Login(UserDto user)
        {

            ResponseDto response = new ResponseDto();
            UserEntity result = _unitOfWork.UserRepository.FirstOrDefault(x => x.Email == user.UserName
                                                                            && x.Password == user.Password,
                                                                           r => r.RolUserEntities);
            if (result == null)
            {
                response.Message = "Usuario o contraseña inválida!";
                response.IsSuccess = false;
            }
            else
            {
                response.Result = result;
                response.IsSuccess = true;
                response.Message = "Usuario autenticado!";
            }
            return response;

        }
        #endregion

        #region Methods CRUD
        public List<UserEntity> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll().ToList();
        }



        //Registar un usuario para loguearse
        public async Task<ResponseDto> Register(UserDto data)
        {
            ResponseDto result = new ResponseDto();

            if (Utils.ValidateEmail(data.UserName))
            {
                if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.UserName) == null)
                {

                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdRol = RolUser.Estandar.GetHashCode(),
                        UserEntity = new UserEntity()
                        {
                            Email = data.UserName,
                            LastName = data.LastName,
                            Name = data.Name,
                            Password = data.Password
                        }
                    };

                    _unitOfWork.RolUserRepository.Insert(rolUser);
                    result.IsSuccess = await _unitOfWork.Save() > 0;
                }
                else
                    result.Message = "Email ya se encuestra registrado, utilizar otro!";
            }
            else
                result.Message = "Usuario con Email Inválido";

            return result;
        }


        #endregion
    }
}
