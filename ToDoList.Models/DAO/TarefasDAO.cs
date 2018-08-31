using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAO;

namespace ToDoList.Models.DAO
{
    public class TarefasDAO
    {
        private readonly TarefasContext Contexto;

        public TarefasDAO(TarefasContext context)
        {
            this.Contexto = context;
        }

        public TarefasDAO()
        {
        }

        public void SalvarTarefa(Tarefa tarefa)
        {
            Contexto.Add(tarefa);
            Contexto.SaveChanges();
        }

        public List<Tarefa> GetTarefas()
        {
            return Contexto.Tarefas
                .Include(t => t.SubTarefas)
                .Select(s => new Tarefa()
                {
                    Descricao = s.Descricao,
                    Finalizado = s.Finalizado,
                    IdTarefa = s.IdTarefa,
                    Titulo = s.Titulo,
                    SubTarefas = s.SubTarefas.ToList()
                })
                .ToList();
        }

        public Tarefa GetTarefaById(int id)
        {
            return Contexto.Tarefas
                .Include(t => t.SubTarefas)
                .Where(w => w.IdTarefa == id)
                .Select(s => new Tarefa()
                {
                    Descricao = s.Descricao,
                    Finalizado = s.Finalizado,
                    IdTarefa = s.IdTarefa,
                    Titulo = s.Titulo,
                    SubTarefas = s.SubTarefas.ToList()
                })
                .FirstOrDefault();
        }

        public void RemoverTarefa(Tarefa tarefa)
        {
            Contexto.Remove(tarefa);
            Contexto.SaveChanges();
        }

        public void AlterarTarefa(Tarefa tarefa)
        {
            Contexto.Update(tarefa);
            Contexto.SaveChanges();
        }
    }
}
