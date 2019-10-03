using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.Model
{
    [Table("Usuarios")]
    public class Usuario : Pessoa
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
            Logado = false;
        }

        // [Key]
        //public int UsuarioId { get; set; }
        public string Cargo { get; set; }
        public string Nickname { get; set; }
        public string Senha { get; set; }
        public Boolean Logado { get; set; }
        public override string ToString()
        {
            return Nickname;
        }
       
    }
}
