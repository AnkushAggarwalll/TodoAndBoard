

using Microsoft.AspNetCore.Mvc;
using todoonboard_api.Helpers;
using todoonboard_api.Models;
using todoonboard_api.infoModels;
using todoonboard_api.Services;
using todoonboard_api.Context;
using EncryptionandDecryption;
using System.Collections.Generic;

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
        model.Password = Cryptography.Encrypt(model.Password);
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
    [Authorize]
    [HttpPost("assignBoard")]
    public IActionResult AssignBoard(UserBoardRequest req){
        var response = _userService.AssignBoard(req);
        if(response == null)
        return BadRequest(new {message = "user already assigned to this board"});
        return Ok(response);

    }
    [Authorize]
    [HttpGet("{id}")]
    public List<Boards> GetUserBoards(int id){
        var response = _userService.GetUserBoards(id);
        return response;
    }
}}