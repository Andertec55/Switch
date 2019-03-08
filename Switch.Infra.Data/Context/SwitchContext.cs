using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Context // classe de configuracao inicial da classe de contexto
{
    public class SwitchContext : DbContext

    {
        public DbSet<Usuario> Usuarios { get; set; }
        public SwitchContext(DbContextOptions option) : base(option)
        {

        }

    }
}
