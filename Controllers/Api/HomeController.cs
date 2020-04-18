using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApp.DBAccess.Entities;
using TeamApp.Services.Interfaces;

namespace TeamApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IWordsServices _wordsServices;
        public HomeController(IWordsServices wordsServices)
        {
            _wordsServices = wordsServices;
        }

        [HttpGet("GetHome")]
        public List<Words> GetHome()
        {
            // var user = ;
            return _wordsServices.WordsList();

        }
    }
}