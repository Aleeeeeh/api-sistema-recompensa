using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Services;

public class TokenService(Context context, IMapper mapper)
{
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Token> CreateToken(TokenDto dto)
    {
        try
        {
            var tokenExists = await GetToken();

            if (tokenExists != null)
            {
                throw new TokenException("Não é permitido criar mais de um token");
            }

            Token token = _mapper.Map<Token>(dto);
            await _context.Token.AddAsync(token);
            await _context.SaveChangesAsync();

            return token;
        }
        catch (TokenException ex)
        {
            throw new TokenException(ex.Message);
        }
    }

    public async Task SetToken(TokenDto dto)
    {
        try
        {
            var token = await GetToken();

            if (token is null)
                throw new TokenException("Token não encontrado");

            token.ValueInReal = dto.ValueInReal;

            _context.Token.Update(token);
            await _context.SaveChangesAsync();
        }
        catch (TokenException ex)
        {
            throw new TokenException(ex.Message);
        }
    }

    public async Task<Token?> GetToken()
    {
        return await _context.Token.FirstOrDefaultAsync();
    }
}
