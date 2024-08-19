using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Services;

public class BalanceService(Context context, AccountService accountService, TokenService tokenService)
{
    private readonly Context _context = context;
    private readonly AccountService _accountService = accountService;
    private readonly TokenService _tokenService = tokenService;

    public async Task IncreaseBalance(int userId, int quantityToken, int bonus = 0)
    {
        Account? account = await _accountService.GetAccount(userId);

        if (account is null)
            throw new AccountException("Conta não encontrada");

        account.Balance += quantityToken + bonus;
        account.DateLastUpdate = DateTime.Now;

        _context.Account.Update(account);
        await _context.SaveChangesAsync();
    }
    public async Task WithDrawBalance(int userId, int quantityToken)
    {
        Account? account = await _accountService.GetAccount(userId);

        if (account is null)
            throw new AccountException("Conta não encontrada");

        if (account.Balance < quantityToken)
            throw new AccountException("Saldo insuficiente");

        account.Balance -= quantityToken;
        account.DateLastUpdate = DateTime.Now;

        _context.Account.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task<decimal> GetBalanceInToken(int userId)
    {
        return await _context.Account.Where(x => x.User.Id == userId).Select(x => x.Balance).FirstOrDefaultAsync();
    }

    public async Task<decimal> GetBalanceInReal(int userId)
    {
        decimal balance = await GetBalanceInToken(userId);
        Token? valueToken = await _tokenService.GetToken();

        return balance * valueToken.ValueInReal;
    }
}
