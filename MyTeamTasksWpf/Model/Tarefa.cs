using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.Model
{
    [Table("Tarefas")]
    class Tarefa
    {
        public Tarefa()
        {
            CriadoEm = DateTime.Now; 
        }
        [Key]
        public int TarefaId { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string Resolucao { get; set; }
        public string Descricao { get; set; }
        public Usuario Assinatura { get; set; }
        public Usuario Requisitante { get; set; }
        public Projeto Projeto { get; set; }        
        //public Cliente Cliente { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return "ID: " +TarefaId+
                "\nTitulo: " +Titulo+
                "\nDescricao: " +Descricao+
                "\nTipo: " +Tipo+
                "\nStatus: " +Status+
                "\nPrioridade: " +Prioridade+
                "\nResolução: " +Resolucao+
                "\nAssinatura: " +Assinatura.Nickname+
                "\nRequisitante: " +Requisitante.Nickname+
                "\nProjeto: " +Projeto.Nome;

        }
    }
}
