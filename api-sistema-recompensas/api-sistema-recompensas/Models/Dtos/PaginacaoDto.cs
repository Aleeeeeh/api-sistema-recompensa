namespace api_sistema_recompensas.Models.Dtos;

public class PaginacaoDto<T>
{
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public List<T>? Results { get; set; }
}
