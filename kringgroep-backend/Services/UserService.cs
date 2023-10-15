using kringgroep_backend.Contexts;
using kringgroep_backend.Models;

namespace kringgroep_backend.Services;

public class UserService
{
    private readonly UserContext _userContext;

    public UserService(UserContext userContext)
    {
        _userContext = userContext;
    }

    public List<User> GetAll()
    {
        return _userContext.Users.ToList();
    }

    public User? Get(int id)
    {
        return _userContext.Users.Find(id);
    }

    public User Create(string name)
    {
        var user = new User(name);
        _userContext.Users.Add(user);
        _userContext.SaveChanges();
        return user;
    }
}