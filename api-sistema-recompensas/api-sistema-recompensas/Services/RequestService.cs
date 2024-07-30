using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using api_sistema_recompensas.Models.Enums;
using api_sistema_recompensas.Strategy.Contracts;
using api_sistema_recompensas.Strategy.RequestsStrategy;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Services;

public class RequestService(Context context, IMapper mapper)
{
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Request> OpenRequest(CreateRequestDto dto)
    {
        try
        {
            Request request = _mapper.Map<Request>(dto);
            request.StatusRequest = StatusRequest.PENDENTE;
            request.CreationDate = DateTime.Now;
            request.UpdateDate = DateTime.Now;
            request.UserIdApprover = null;
            await _context.Request.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }
        catch (RequestException ex)
        {
            throw new RequestException(ex.Message);
        }
    }

    public async Task RespondToRequest(RequestAnalysisDto dto)
    {
        try
        {
            Request? requestExist = await GetRequestById(dto.IdRequest);

            if (requestExist is null)
                throw new RequestException("Solicitação não encontrada");

            Request request = _mapper.Map(dto, requestExist);
            request.UpdateDate = DateTime.Now;
            _context.Request.Update(request);
            await _context.SaveChangesAsync();
        }
        catch (RequestException ex)
        {
            throw new RequestException(ex.Message);
        }
    }

    public async Task<Request?> GetRequestById(long id)
    {
        return await _context.Request.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    private Dictionary<int, IRequestQueryStrategy<Request>> _strategies = new()
    {
        { (int)StatusRequest.PENDENTE, new PendingRequestQueryStrategy(context) },
        { (int)StatusRequest.APROVADO, new ApprovedRequestQueryStrategy(context) },
        { (int)StatusRequest.REJEITADO, new DisapprovedRequestQueryStrategy(context) }
    };

    public async Task<PaginacaoDto<Request>> GetRequestsBySituationAndDate(int situacao, DateTime data, int pagina, int tamanhoPagina)
    {
        if (_strategies.TryGetValue(situacao, out var strategy))
        {
            return await strategy.ExecuteQuery(data, pagina, tamanhoPagina);
        }
        else
        {
            throw new ArgumentException("Situação não reconhecida.", nameof(situacao));
        }
    }
}
