using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Models.Negocio;

namespace ToDoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTarefasController : ControllerBase
    {

        private readonly SubTarefasNegocio subTarefasNegocio;

        public SubTarefasController(SubTarefasNegocio subTarefasNegocio)
        {
            this.subTarefasNegocio = subTarefasNegocio;
        }

        // GET api/SubTarefas/5
        [HttpGet("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<List<SubTarefa>> GetSubTarefas(int id)
        {
            return subTarefasNegocio.GetSubTarefasById(id);
        }

        // GET api/SubTarefas/5
        [HttpGet("/api/subtarefa/{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<SubTarefa> GetSubTarefa(int id)
        {
            return subTarefasNegocio.GetSubTarefaById(id);
        }

        // POST api/SubTarefas
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public ActionResult<JsonResult> Post([FromBody] SubTarefa subTarefa)
        {
            subTarefasNegocio.SalvarSubTarefa(subTarefa);
            return new JsonResult(subTarefa);
        }

        // PUT api/SubTarefas/5
        [HttpPut("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public void Put(int id, [FromBody] SubTarefa subTarefa)
        {
            subTarefasNegocio.AlterarSubTarefa(id, subTarefa);
        }

        // DELETE api/SubTarefas/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public void Delete(int id)
        {
            subTarefasNegocio.RemoverSubTarefa(id);
        }
        
        [HttpPut("/api/finalizarSubtarefa/{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public void Finalizar(int id, [FromBody] SubTarefa s)
        {
            SubTarefa subTarefa = subTarefasNegocio.GetSubTarefaById(s.IdSubTarefa);
            subTarefa.Finalizado = s.Finalizado;
            subTarefasNegocio.AlterarSubTarefa(id, subTarefa);
        }
    }
}
