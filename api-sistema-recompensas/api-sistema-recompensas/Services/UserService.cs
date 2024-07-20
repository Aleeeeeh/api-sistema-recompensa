using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Services;

public class UserService(Context context, IMapper mapper)
{
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<User> InsertUser(CreateUserDto userDto)
    {
        try
        {
            User user = _mapper.Map<User>(userDto);
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        catch (UserException ex)
        {
            throw new UserException("Erro ao cadastrar usuário.", ex);
        }
    }

    public async Task UpdateUser(UpdateUserDto userDto, long id)
    {
        var user = await GetUserById(id) ?? throw new UserException("Usuário não encontrado.");

        User createUser = _mapper.Map(userDto, user);
        _context.User.Update(createUser);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserById(long id)
    {
        return await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>?> GetUsers()
    {
        try
        {
            return await _context.User.ToListAsync();
        }
        catch (UserException ex)
        {
            throw new UserException("Erro ao buscar lista de usuários", ex);
        }
    }
}
