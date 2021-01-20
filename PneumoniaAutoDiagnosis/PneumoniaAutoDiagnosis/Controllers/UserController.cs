using Microsoft.AspNetCore.Mvc;
using PneumoniaAutoDiagnosis.Models;
using PneumoniaAutoDiagnosis.Services;
using System.Collections.Generic;

namespace PneumoniaAutoDiagnosis.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserService _userService;

		public UserController(UserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public ActionResult<List<User>> Get() => _userService.Get();

		[HttpGet("{id:length(24)}", Name = "GetUser")]
		public ActionResult<User> Get(string id)
		{
			var User = _userService.Get(id);

			if (User == null)
			{
				return NotFound();
			}

			return User;
		}

		[HttpPost]
		public ActionResult<User> Create(User User)
		{
			_userService.Create(User);

			return CreatedAtRoute("GetBook", new { id = User.Id.ToString() }, User);
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, User bookIn)
		{
			var User = _userService.Get(id);

			if (User == null)
			{
				return NotFound();
			}

			_userService.Update(id, bookIn);

			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var User = _userService.Get(id);

			if (User == null)
			{
				return NotFound();
			}

			_userService.Delete(User.Id);

			return NoContent();
		}
	}
}

