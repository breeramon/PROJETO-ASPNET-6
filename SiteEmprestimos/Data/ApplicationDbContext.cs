using Microsoft.EntityFrameworkCore;
using SiteEmprestimos.Models;

namespace SiteEmprestimos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmprestimosModel> Emprestimo { get; set; }
    }
}
