using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ToDoList.DAO;
using ToDoList.Models;
using ToDoList.Models.DAO;

namespace ToDoList.Test
{
    [TestClass]
    public class TarefasDAOTest
    {
        private TarefasDAO TarefasDAO;

        [TestInitialize]
        public void Setup()
        {
            TarefasDAO = new TarefasDAO();
        }

        [TestMethod]
        public void TestarSalvarTarefaValida()
        {

            var conexao = new SqliteConnection("DataSource=:memory:");
            conexao.Open();

            var opcoes = new DbContextOptionsBuilder<TarefasContext>()
                .UseSqlite(conexao)
                .Options;

            try
            {
                using (var contexto = new TarefasContext(opcoes))
                {
                    contexto.Database.EnsureCreated();
                }

                using (var contexto = new TarefasContext(opcoes))
                {
                    Tarefa tarefa = new Tarefa { Descricao = "Descrição teste", Finalizado = false, Titulo = "Título teste" };
                    TarefasDAO.SalvarTarefa(tarefa);
                }
                using (var contexto = new TarefasContext(opcoes))
                {
                    Assert.AreEqual(1, contexto.Tarefas.Count());
                    Assert.AreEqual("Descrição teste", contexto.Tarefas.FirstOrDefault().Descricao);
                    Assert.AreEqual("Título teste", contexto.Tarefas.FirstOrDefault().Titulo);
                }
            }
            finally
            {
                conexao.Close();
            }
            

            




            //Tarefa tarefa = new Tarefa {DataTarefa = DateTime.Now, Descricao = "Tarefa teste", Finalizado = false, Titulo="titulo teste"};            
            //TarefasDAO.SalvarTarefa(tarefa);
            //using (var contexto = new TarefasContext())
            //{
            //    Tarefa tarefaNoBanco =  contexto.Tarefas.LastOrDefault();
            //    Assert.AreEqual(tarefaNoBanco.Descricao, tarefa.Descricao);
            //    Assert.AreEqual(tarefaNoBanco.Titulo, tarefa.Titulo);
            //}
        }

        //public void TestarAlterarTarefa()
        //{
        //    using (var contexto = new TarefasContext())
        //    {
        //        Tarefa tarefaParaAlterar = contexto.Tarefas.LastOrDefault();
        //        tarefaParaAlterar.Titulo = "Titulo teste alterado";
        //        tarefaParaAlterar.Descricao = "Descricao teste alterada";
        //        TarefasDAO.AlterarTarefa(tarefaParaAlterar);
        //        Tarefa tarefaAlterada = contexto.Tarefas.Where(t => t.IdTarefa == tarefaParaAlterar.IdTarefa).FirstOrDefault();
        //        Assert.AreEqual(tarefaAlterada.Descricao, tarefaParaAlterar.Descricao);
        //        Assert.AreEqual(tarefaAlterada.Titulo, tarefaParaAlterar.Titulo);
        //    }            
        //}
        
        //[TestMethod]
        //[ExpectedException(typeof(DbUpdateConcurrencyException))]
        //public void TestarRemoverTarefa()
        //{
        //    using (var contexto = new TarefasContext())
        //    {
        //        Tarefa tarefa = contexto.Tarefas.FirstOrDefault();
        //        contexto.Remove(tarefa);
        //        contexto.SaveChanges();
        //        contexto.Remove(tarefa);
        //        contexto.SaveChanges();
        //    }                
        //}
    }
}
