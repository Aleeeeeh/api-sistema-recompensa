using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Entities;

namespace api_sistema_recompensas.Services;

public class AccountService(Context context)
{
    private readonly Context _context = context;

    public async Task<Account> CreateAccount(User user)
    {
        try
        {
            Account account = new()
            {
                User = user,
                Balance = 0
            };

            await _context.Account.AddAsync(account);

            return account;
        }
        catch (AccountException ex)
        {
            throw new AccountException("Erro criar conta.", ex);
        }
    }
}
