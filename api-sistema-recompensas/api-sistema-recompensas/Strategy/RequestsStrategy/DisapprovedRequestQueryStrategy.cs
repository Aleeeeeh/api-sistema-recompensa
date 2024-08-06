using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using api_sistema_recompensas.Models.Enums;
using api_sistema_recompensas.Strategy.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Strategy.RequestsStrategy;

public class DisapprovedRequestQueryStrategy(Context context) : IRequestQueryStrategy<Request>
{
    private readonly Context _context = context;
    public async Task<PaginacaoDto<Request>> ExecuteQuery(DateTime initialDate, DateTime finalDate, int page, int pageSize)
    {
        List<Request> requests = await _context.Request
            .Where(x => x.UpdateDate.Date >= initialDate.Date && x.UpdateDate.Date <= finalDate.Date
                && x.StatusRequest == StatusRequest.REJEITADO)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        int totalRegistros = requests.Count;
        int totalPaginas = (int)Math.Ceiling(totalRegistros / (double)pageSize);

        return new PaginacaoDto<Request>
        {
            TotalPages = totalRegistros,
            TotalRecords = totalPaginas,
            CurrentPage = page,
            PageSize = pageSize,
            Results = requests
        };
    }
}
