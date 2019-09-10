using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.Model
{
    [Table("Projetos")]
    class Projeto
    {
        public Projeto()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return "ID: " + ProjetoId +
                "\nNome: " + Nome +
                "\nStatus: " + Status +
                "\nCliente: " + Cliente.Nome;
        }
    }
}
