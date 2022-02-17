

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using todoonboard_api.Helpers;
using todoonboard_api.Models;
using todoonboard_api.infoModels;
using System.Collections.Generic;
using todoonboard_api.Context;
using System.Linq;
using System;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);

    User InsertUser(UserRequest user);
}
namespace todoonboard_api.Services{

public class UserService : IUserService
{
    private readonly AppSettings _appSettings;
    private readonly DBContext _context;

    public UserService(IOptions<AppSettings> appSettings, DBContext context)
    {
       _appSettings = appSettings.Value;
       _context = context;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public User InsertUser(UserRequest userRequest){
        var user = new User(userRequest);
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
}