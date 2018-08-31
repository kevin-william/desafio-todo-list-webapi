using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Models.DAO;
using ToDoList.Models.Negocio;

namespace ToDoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TarefasNegocio tarefasNegocio;

        public TarefasController(TarefasNegocio tarefasNegocio)
        {
            this.tarefasNegocio = tarefasNegocio;
        }

        // GET api/Tarefas
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<List<Tarefa>> Get()
        {            
            return tarefasNegocio.GetTarefas();
        }

        // GET api/Tarefas/5
        [HttpGet("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<Tarefa> Get(int id)
        {
            return tarefasNegocio.GetTarefa(id);
        }

        // POST api/Tarefas
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<JsonResult> Post([FromBody] Tarefa tarefa)
        {            
            tarefasNegocio.SalvarTarefa(tarefa);
            return new JsonResult(tarefa);
        }

        // PUT api/Tarefas/5
        [HttpPut("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public void Put(int id, [FromBody] Tarefa tarefa)
        {
            tarefasNegocio.AlterarTarefa(id, tarefa);
        }

        // DELETE api/Tarefas/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public void Delete(int id)
        {
            tarefasNegocio.RemoverTarefa(id);
        }
        
        [HttpGet("/api/Tarefas/percentualCompletas/")]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<int> GetSubTarefa()
        {
            double total = tarefasNegocio.GetTarefas().Count();
            double totalConcluidas = tarefasNegocio.GetTarefas().Where(t => t.Finalizado ==true).Count();
            double pct = (totalConcluidas / total)*100;
            return Convert.ToInt32(Math.Round(pct));
            
        }
        [HttpPut("/api/finalizarTarefa/")]
        [EnableCors("AllowSpecificOrigin")]
        public void Finalizar([FromBody] Tarefa t)
        {
            Tarefa tarefa = tarefasNegocio.GetTarefa(t.IdTarefa);
            tarefa.Finalizado = t.Finalizado;
            tarefasNegocio.AlterarTarefa(t.IdTarefa, tarefa);
        }
    }
}
