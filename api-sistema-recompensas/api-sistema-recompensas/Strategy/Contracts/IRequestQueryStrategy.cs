using api_sistema_recompensas.Models.Dtos;

namespace api_sistema_recompensas.Strategy.Contracts;

public interface IRequestQueryStrategy<T>
{
    Task<PaginacaoDto<T>> ExecuteQuery(DateTime initialDate, DateTime finalDate, int page, int pageSize);
}
