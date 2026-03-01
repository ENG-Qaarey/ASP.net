using FRST_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRST_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
	private readonly IReadOnlyList<User> _users;

	public UsersController(IReadOnlyList<User> users)
	{
		_users = users;
	}

	[HttpGet]
	public ActionResult<IEnumerable<User>> GetAll()
	{
		return Ok(_users);
	}

	[HttpGet("{id:int}")]
	public ActionResult<User> GetById(int id)
	{
		var user = _users.FirstOrDefault(u => u.Id == id);
		if (user is null)
		{
			return NotFound();
		}

		return Ok(user);
	}
}
