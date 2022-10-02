using Infraestructure.Entity.Models.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Domain.Services.Interface;
using System.Collections.Generic;

namespace CrudUsuarios.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        #region Attribute
        private readonly IUserServices _userServices;
        //private readonly IRolServices _rolServices;
        #endregion

        #region Builder
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
            //_rolServices = rolServices;
        }
        #endregion
        public IActionResult Index()
        {
            List<UserEntity> users = _userServices.GetAll();
            return View(users);
        }
    }
}
