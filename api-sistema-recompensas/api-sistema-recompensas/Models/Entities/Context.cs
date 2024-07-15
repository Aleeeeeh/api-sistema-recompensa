using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Models.Entities;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{

}
