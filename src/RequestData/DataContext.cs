using Microsoft.EntityFrameworkCore;
using RequestData.Entities;

namespace RequestData;

public class DataContext : DbContext

{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Request> Requests => Set<Request>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<RequestStatus> RequestStatus => Set<RequestStatus>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
