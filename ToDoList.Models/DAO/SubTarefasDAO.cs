using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.DAO;

namespace ToDoList.Models.DAO
{
    public class SubTarefasDAO
    {
        public SubTarefasDAO(TarefasContext context)
        {
            this.Contexto = context;
        }

        public SubTarefasDAO()
        {
        }

        private readonly TarefasContext Contexto;

        public List<SubTarefa> GetSubTarefasById(int id)
        {
            return Contexto.SubTarefas
                .Where(s => s.IdTarefa == id)
                .ToList();
        }

        public SubTarefa GetSubTarefaById(int id)
        {
            return Contexto.SubTarefas
                .Where(s => s.IdSubTarefa == id)
                .FirstOrDefault();
        }


        public void SalvarSubTarefa(SubTarefa subTarefa)
        {
            Contexto.Add(subTarefa);
            Contexto.SaveChanges();
        }

        public void AlterarSubTarefa(SubTarefa subTarefa)
        {
            Contexto.Update(subTarefa);
            Contexto.SaveChanges();
        }

        public void RemoverSubTarefa(SubTarefa subTarefa)
        {
            Contexto.Remove(subTarefa);
            Contexto.SaveChanges();
        }
    }

}
