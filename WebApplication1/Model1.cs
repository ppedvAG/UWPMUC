namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                .Property(e => e.Aufgabe)
                .IsUnicode(false);

            modelBuilder.Entity<ToDo>()
                .Property(e => e.Bearbeiter)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
