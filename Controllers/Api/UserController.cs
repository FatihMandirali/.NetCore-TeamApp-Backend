using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApp.Models.Models;
using TeamApp.Services.Interfaces;

namespace TeamApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersServices _userService;

        public UserController(IUsersServices userService)
        {
            _userService = userService;
        }

        [HttpGet("UserList")]
        public async Task<object> UserList()
        {
            var users = await _userService.GetUserList();
            var models = users.Adapt<List<UsersRM>>();
            // var model = new ContentObject<ContentRM> { ContentList = contents, Pagination = contentList.Pagination };
            if (users == null)
            {
                return ResponseModel<object>.Create(null, FriendlyMessageModel.Create("İçerik Bulunamadı", "Henüz sisteme kayıtlı kullanıcı bulunmamaktadır."));
            }
            return ResponseModel<object>.Create(models);
        }

        [HttpPost("PostCreateUser")]
        public async Task<UserNameResponse> PostCreateUser([FromForm]UserCreate userCreate)
        {
             // var user = ;
                return await _userService.AddUser(userCreate);
           
        }
    }
}