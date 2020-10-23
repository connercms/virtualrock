using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualRock.Core.Services;
using VirtualRock.Core.Models;
using AutoMapper;
using VirtualRock.API.Resources;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualRock.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResource>>> Get()
        {
            var users = await _userService.GetAllUsers();

            var userResources = _mapper.Map<IEnumerable<UserResource>>(users);

            return Ok(userResources);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> Get(int id)
        {
            var user = await _userService.GetUserById(id);

            var userResource = _mapper.Map<UserResource>(user);

            return Ok(userResource);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<UserResource>> Post([FromBody] SaveUserResource saveUserResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // TODO: Refine

            var userToCreate = _mapper.Map<SaveUserResource, User>(saveUserResource);

            var newUser = await _userService.CreateUser(userToCreate);

            var user = await _userService.GetUserById(newUser.Id);

            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResource>> Put(int id, [FromBody] SaveUserResource saveUserResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // TODO: Refine

            var userToBeUpdated = await _userService.GetUserById(id);

            if (userToBeUpdated == null)
                return NotFound();

            var user = _mapper.Map<SaveUserResource, User>(saveUserResource);

            await _userService.UpdateUser(userToBeUpdated, user);

            var updatedUser = await _userService.GetUserById(id);

            var updatedUserResource = _mapper.Map<User, SaveUserResource>(updatedUser);

            return Ok(updatedUserResource);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            await _userService.DeleteUser(user);

            return NoContent();
        }
    }
}
