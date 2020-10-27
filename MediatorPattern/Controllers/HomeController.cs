using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorPattern.App.Queries.Product;
using MediatorPattern.App.Queries.Users;
using MediatorPattern.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorPattern.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly PostgreDbContext _postgreDB;
        private readonly IMediator _mediator;

        public HomeController(PostgreDbContext postgreDbContext,IMediator mediator)
        {
            _postgreDB = postgreDbContext;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> User(UserRequest request)
        {
            var result = await _mediator.Send(request);
            if (result==null)
            {
                return NotFound("Data not found");
            }
            return Ok(result.User);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Product(ProductRequest request)
        {
            var result = await _mediator.Send(request);
            if (result == null)
            {
                return NotFound("Data not found");
            }
            return Ok(result.Product);
        }
    }
}