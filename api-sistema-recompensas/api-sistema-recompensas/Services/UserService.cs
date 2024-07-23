using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using api_sistema_recompensas.Models.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Services;

public class UserService(Context context, IMapper mapper)
{
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<User> InsertUser(CreateUserDto dto)
    {
        await _context.Database.BeginTransactionAsync();

        try
        {
            User user = _mapper.Map<User>(dto);
            await _context.User.AddAsync(user);

            if (dto.UserType == UserType.FILHO)
            {
                AccountService accountService = new(_context);
                await accountService.CreateAccount(user);
            }

            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();

            return user;
        }
        catch (DbUpdateException ex)
        {
            await _context.Database.RollbackTransactionAsync();
            throw new DbUpdateException($"Erro ao gerar usuário/conta - {ex.Message}");
        }
        catch (UserException ex)
        {
            throw new UserException($"Erro ao cadastrar usuário - {ex.Message}");
        }
    }

    public async Task UpdateUser(UpdateUserDto dto, long id)
    {
        try
        {
            var user = await GetUserById(id);

            if (user is null)
                throw new UserException("Usuário não encontrado");

            User updateUser = _mapper.Map(dto, user);
            _context.User.Update(updateUser);
            await _context.SaveChangesAsync();
        }
        catch (UserException ex)
        {
            throw new UserException(ex.Message);
        }
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
            throw new UserException($"Erro ao buscar lista de usuários - {ex.Message}");
        }
    }
}
