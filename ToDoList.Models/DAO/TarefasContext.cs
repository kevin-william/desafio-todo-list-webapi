using ToDoList.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ToDoList.DAO
{
    public class TarefasContext: DbContext
    {

        public TarefasContext(){ }
        public TarefasContext(DbContextOptions<TarefasContext> contexto)
            :base(contexto)
        { }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<SubTarefa> SubTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SubTarefa>()
                .HasKey(st => new { st.IdSubTarefa });

            modelBuilder
                .Entity<Tarefa>()
                .HasKey(t => new { t.IdTarefa });

            modelBuilder.Entity<SubTarefa>()
            .HasOne<Tarefa>(st => st.Tarefa)
            .WithMany(t => t.SubTarefas)
            .HasForeignKey(st => st.IdTarefa);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ToDoList;Trusted_Connection=true;");
        //    }
        //}
    }
}
