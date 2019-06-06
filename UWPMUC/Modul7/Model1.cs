namespace WebApplication1
{
    using Microsoft.EntityFrameworkCore;
    using System;
   
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using UWPMUC.Modul06;

    public partial class Model1 : DbContext
    {
      

        public virtual DbSet<ToDo> ToDo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todo.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
