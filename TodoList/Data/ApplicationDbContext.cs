﻿using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        
        public DbSet<TodoItems> todoItems { get; set; }  
        public DbSet<Users> users { get; set; }  
    }
}
