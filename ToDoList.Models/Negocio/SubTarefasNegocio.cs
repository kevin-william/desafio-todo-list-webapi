using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DAO;
using ToDoList.Models.DAO;

namespace ToDoList.Models.Negocio
{
    public class SubTarefasNegocio
    {
        public SubTarefasNegocio(SubTarefasDAO subTarefasDAO)
        {
            this.subTarefasDAO = subTarefasDAO;
        }

        private readonly SubTarefasDAO subTarefasDAO;        

        public List<SubTarefa> GetSubTarefasById(int id)
        {
            return subTarefasDAO.GetSubTarefasById(id);
        }

        public SubTarefa GetSubTarefaById(int id)
        {
            return subTarefasDAO.GetSubTarefaById(id);
        }

        public void AlterarSubTarefa(int id, SubTarefa subTarefa)
        {
            subTarefasDAO.AlterarSubTarefa(subTarefa);
        }
        public void SalvarSubTarefa(SubTarefa subTarefa)
        {                        
            subTarefasDAO.SalvarSubTarefa(subTarefa);
        }
        public void RemoverSubTarefa(int id)
        {            
            SubTarefa subTarefa = GetSubTarefaById(id);
            subTarefasDAO.RemoverSubTarefa(subTarefa);
        }

    }
}
