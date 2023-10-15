namespace kringgroep_backend.Models;

public class User
{

    public User(string name)
    {
        Name = name;
    }
    public int UserId { get; set; }
    public string Name { get; set; }
}