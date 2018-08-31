using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DAO;
using ToDoList.Models.DAO;

namespace ToDoList.Models.Negocio
{
    public class TarefasNegocio
    {

        private readonly TarefasDAO tarefasDAO;
        private readonly SubTarefasDAO subTarefasDAO;

        public TarefasNegocio(TarefasDAO tarefasDAO, SubTarefasDAO subTarefasDAO)
        {
            this.tarefasDAO = tarefasDAO;
            this.subTarefasDAO = subTarefasDAO;
        }        

        public List<Tarefa> GetTarefas()
        {
            List<Tarefa> Tarefas = tarefasDAO.GetTarefas();
            foreach (Tarefa tarefa in Tarefas)
            {
                tarefa.SubTarefas = subTarefasDAO.GetSubTarefasById(tarefa.IdTarefa);
            }
            return Tarefas;
        }

        public void SalvarTarefa(Tarefa tarefa) {
            tarefasDAO.SalvarTarefa(tarefa);
        }

        public void AlterarTarefa(int id, Tarefa tarefa)
        {
            Tarefa tarefaPersistida =  tarefasDAO.GetTarefaById(id);
            tarefaPersistida.Descricao = tarefa.Descricao;
            tarefaPersistida.Titulo = tarefa.Titulo;
            tarefaPersistida.Finalizado = tarefa.Finalizado;

            tarefasDAO.AlterarTarefa(tarefaPersistida);
        }

        public void RemoverTarefa(int id)
        {
            Tarefa tarefa = tarefasDAO.GetTarefaById(id);
            tarefasDAO.RemoverTarefa(tarefa);
        }

        public Tarefa GetTarefa(int id)
        {
            Tarefa tarefa = tarefasDAO.GetTarefaById(id);
            tarefa.SubTarefas = subTarefasDAO.GetSubTarefasById(id);
            return tarefa;
        }

    }
}
