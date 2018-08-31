using System;

namespace ToDoList.Models
{
    public class SubTarefa
    {

        public int IdSubTarefa { get; set; }
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Finalizado { get; set; }
        public Tarefa Tarefa { get; set; }

    }
}
