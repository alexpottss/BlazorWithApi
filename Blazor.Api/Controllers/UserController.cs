using Blazor.Api.Data;
using Blazor.Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDBContext _userDBcontext;
        public UserController(UserDBContext userDBContext) => _userDBcontext = userDBContext;

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userDBcontext.Users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id) 
        { 
            return await _userDBcontext.Users.Where(x => x.Id == id).SingleOrDefaultAsync(); 
        }
       
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await _userDBcontext.Users.AddAsync(user);
            await _userDBcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id  = user.Id }, user);
        }
        
        [HttpPut]
        public async Task<ActionResult> Update(User user)
        {
            _userDBcontext.Users.Update(user);  
            await _userDBcontext.SaveChangesAsync();
            return Ok();    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userGetByIdResult = await GetById(id);
            if (userGetByIdResult.Value is null) { return NotFound(); }

            _userDBcontext.Remove(userGetByIdResult.Value);
            await _userDBcontext.SaveChangesAsync();
            return Ok();    

        }
    }
}
