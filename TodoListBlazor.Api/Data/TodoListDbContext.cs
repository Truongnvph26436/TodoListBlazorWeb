using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TodoListBlazor.Api.Enities;

namespace TodoListBlazor.Api.Data
{
    public class TodoListDbContext : IdentityDbContext<User, Role, Guid>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)//ghi đè lại
        {

        }
        public DbSet<Task> Tasks { set; get; }
    }
}
