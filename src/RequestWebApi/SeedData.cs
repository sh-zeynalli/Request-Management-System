using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RequestData;
using RequestData.Entities;


namespace RequestWebApi;

public static class SeedData
{
    private static Category category = new Category() { Id = -1, CategoryName = "seed" };
    private static RequestStatus status = new RequestStatus() { Id = -1, Status = "seed" };
    private static UserRole role = new UserRole() { Id = -1, Rolename = "seed" };
    private static User user = new User() { Id = -1, Username = "seeduser", CreatedAt = DateTime.UtcNow, IsActive = true, CreatedById = -1, UserRoleId = -1 };
    private static Request request = new Request {Id = -1, Body = "seedbody", CategoryId = -1, CreatedAt = DateTime.UtcNow, FromUserId = -1, Header = "seedHeader", RequestStatusId = -1};
    public static void SeedDb(this WebApplication a)
    {
        IServiceScope scope = a.Services.CreateScope();
        IServiceProvider provider = scope.ServiceProvider;
        var context = provider.GetRequiredService<DataContext>();
        // if (context.Database.IsRelational())
        // {
        //     context.Database.Migr();
        // }
        // else
        // {
        //     context.Database.EnsureDeleted();
        //     context.Database.EnsureCreated();
        // }

        // if (a.Environment.IsDevelopment())
        // {
        //     context.PopulateData();
        // }
    }

    private static void PopulateData(this DataContext context)
    {
        if (context.Categories.Count() == 0)
        {
            context.Categories.Add(category);
        }
        if (context.Users.Count() == 0)
        {
            context.Users.Add(user);
        }
        if (context.UserRoles.Count() == 0)
        {
            context.UserRoles.Add(role);
        }
        if (context.RequestStatus.Count() == 0)
        {
            context.RequestStatus.Add(status);
        }
        if (context.Requests.Count() == 0)
        {
            context.Requests.Add(request);
        }
        context.SaveChanges();
    }
}
