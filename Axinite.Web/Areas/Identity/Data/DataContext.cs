using Axinite.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Axinite.Web.Data;

public class DataContext : IdentityDbContext<AxiniteWebUser>
{
    DbSet<FilmEntity> Films { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
