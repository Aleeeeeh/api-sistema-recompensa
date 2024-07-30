namespace api_sistema_recompensas.Models.Dtos;

public class PaginacaoDto<T>
{
    public int TotalRegistros { get; set; }
    public int TotalPaginas { get; set; }
    public int PaginaAtual { get; set; }
    public int TamanhoPagina { get; set; }
    public List<T>? Resultados { get; set; }
}
