using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using api_sistema_recompensas.Models.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Services;

public class TaskService(Context context, IMapper mapper)
{
    private readonly Context _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<SystemTask> CreateTask(CreateTaskDto dto)
    {
        try
        {
            SystemTask task = _mapper.Map<SystemTask>(dto);
            await _context.SystemTask.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }
        catch (TaskException ex)
        {
            throw new TaskException(ex.Message);
        }
    }

    public async Task ChangeTask(long id, UpdateTaskDto dto)
    {
        try
        {
            SystemTask? taskExists = await GetTaskById(id);

            if (taskExists is null)
                throw new TaskException("Tarefa não encontrada");

            SystemTask task = _mapper.Map(dto, taskExists);
            _context.SystemTask.Update(task);
            await _context.SaveChangesAsync();
        }
        catch (TaskException ex)
        {
            throw new TaskException(ex.Message);
        }
    }

    public async Task DisableTask(long id)
    {
        SystemTask? task = await GetTaskById(id);

        if (task is null)
            throw new TaskException("Tarefa não encontrada");

        task.Situation = TaskSituation.INATIVO;
        _context.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task ActivateTask(long id)
    {
        SystemTask? task = await GetTaskById(id);

        if (task is null)
            throw new TaskException("Tarefa não encontrada");

        task.Situation = TaskSituation.ATIVO;
        _context.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task<SystemTask?> GetTaskById(long id)
    {
        return await _context.SystemTask.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<SystemTask>> GetTasks()
    {
        return await _context.SystemTask.ToListAsync();
    }
}
