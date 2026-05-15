using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Belosludtseva.Classes.Database;
using TaskManager_Belosludtseva.Models;

namespace TaskManager_Belosludtseva.Context
{
    public class TasksContext : DbContext
    {
        public DbSet<Tasks> Tasks {  get; set; }

        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, Config.version);
        }
    }
}
