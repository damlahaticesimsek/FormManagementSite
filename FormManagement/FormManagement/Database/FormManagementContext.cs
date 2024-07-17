using Microsoft.EntityFrameworkCore;

public class FormManagementContext : DbContext
{
    public FormManagementContext(DbContextOptions<FormManagementContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<FormModel> FormModels { get; set; }
    public DbSet<Field> Fields { get; set; }
}
