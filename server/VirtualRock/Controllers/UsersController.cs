using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VirtualRock.Domain.Models;
using VirtualRock.Domain.Services;
using VirtualRock.Resources;

namespace VirtualRock.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userResource = _mapper.Map<UserResource>(user);

            return Ok(userResource);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAsync()
        {
            var users = await _userService.GetAsync();

            var userResources = _mapper.Map<IEnumerable<UserResource>>(users);

            return Ok(userResources);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(resource);

            var result = await _userService.AddAsync(user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var userResource = _mapper.Map<UserResource>(result.Resource);

            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            var result = await _userService.DeleteAsync(user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            return Ok();
        }
    }
}

