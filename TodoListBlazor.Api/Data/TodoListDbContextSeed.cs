using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TodoListBlazor.Api.Enities;
using Task = System.Threading.Tasks.Task;
using TodoListBlazor.Api.Enums;

namespace TodoListBlazor.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "Ông nội",
                    Email = "admin01@gmail.com",
                    PhoneNumber = "0375045625",
                    UserName = "admin",
                    
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);
            }
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Enities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same task 1",
                    CreateDate = DateTime.Now,
                    Priority = Enums.Priority.High,
                    Status = Status.Open
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
