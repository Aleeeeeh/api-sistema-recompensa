using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using api_sistema_recompensas.Models.Enums;
using api_sistema_recompensas.Strategy.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Strategy.RequestsStrategy;

public class PendingRequestQueryStrategy(Context context) : IRequestQueryStrategy<Request>
{
    private readonly Context _context = context;

    public async Task<PaginacaoDto<Request>> ExecuteQuery(DateTime data, int pagina, int tamanhoPagina)
    {
        List<Request> requests = await _context.Request
            .Where(x => x.CreationDate.Date == data.Date && x.StatusRequest == StatusRequest.PENDENTE)
            .Skip((pagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToListAsync();

        int totalRegistros = requests.Count;
        int totalPaginas = (int)Math.Ceiling(totalRegistros / (double)tamanhoPagina);

        return new PaginacaoDto<Request>
        {
            TotalRegistros = totalRegistros,
            TotalPaginas = totalPaginas,
            PaginaAtual = pagina,
            TamanhoPagina = tamanhoPagina,
            Resultados = requests
        };
    }
}
