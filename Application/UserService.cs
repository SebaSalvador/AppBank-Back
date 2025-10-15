using AppBank_Back.Core;
using AppBank_Back.Infrastructure;

namespace AppBank_Back.Application;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAllUsers()
    {
        // Lógica de negocio podría ir aquí
        return _userRepository.GetAll();
    }

    public User CreateUser(User user)
    {
        // Lógica de negocio: Validar el email, asegurar que el nombre no esté vacío, etc.
        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email))
        {
            throw new ArgumentException("User name and email cannot be empty.");
        }

        user.RegistrationDate = DateTime.UtcNow; // Usar UTC por estándar
        return _userRepository.Add(user);
    }
}