

using Microsoft.AspNetCore.Mvc;
using todoonboard_api.Helpers;
using todoonboard_api.Models;
using todoonboard_api.infoModels;
using todoonboard_api.Services;
using todoonboard_api.Context;


namespace todoonboard_api.Controllers{
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private readonly DBContext _context;
    public UsersController(IUserService userService, DBContext context)
    {
        _userService = userService;
        _context = context;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpPost("create")]
    public IActionResult Create(UserRequest user){
        var response = _userService.InsertUser(user);
        if(response == null)
        return BadRequest(new {message = "something bad happened"});
        return Ok(user);
    }
}}