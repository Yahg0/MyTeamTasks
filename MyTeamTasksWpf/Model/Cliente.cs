using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.Model
{
    [Table("Clientes")]
    class Cliente : Pessoa
    {
        public Cliente()
        {
            CriadoEm = DateTime.Now;
        }

        //[Key]
        //public int ClienteId { get; set; }
        public List<Projeto> Projetos { get; set; }

        public override string ToString()
        {
            return Nome;
        }

    }
    
}
