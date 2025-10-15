using AppBank_Back.Core;

namespace AppBank_Back.Infrastructure;

public class UserRepository
{
    private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", RegistrationDate = DateTime.UtcNow }
    };

    public List<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public User Add(User user)
    {
        user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(user);
        return user;
    }

    // Puedes agregar más métodos aquí (Update, Delete, etc.)
}