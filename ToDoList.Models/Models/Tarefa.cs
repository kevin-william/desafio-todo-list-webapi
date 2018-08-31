using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class Tarefa
    {
        public Tarefa()
        {
            SubTarefas = new List<SubTarefa>();
        }
        public int IdTarefa { get; set; }
        public List<SubTarefa> SubTarefas { get; set;}
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Finalizado { get; set; }

        public override string ToString()
        {
            return $"Tarefa => Título: {Titulo}, Descricao: {Descricao}, Número de Subtarefas: {SubTarefas.Count}";
        }
    }
    
}
