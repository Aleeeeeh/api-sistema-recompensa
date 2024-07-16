using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;

namespace api_sistema_recompensas.Services;

public class UserService(Context context)
{
    private readonly Context _context = context;

    public async Task<User> InsertUser(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        catch (UserException ex)
        {
            throw new UserException("Erro ao cadastrar usuário.", ex);
        }
    }

    public async Task UpdateUser(UserUpdateDto dto)
    {
        throw new NotSupportedException();
    }
}
