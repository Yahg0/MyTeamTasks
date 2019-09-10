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
    class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int UsuarioId { get; set; }
        public string Cargo { get; set; }
        public string Nickname { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return "ID: " +UsuarioId+
                "\nCargo: " +Cargo+
                "\nNickname: " + Nickname;
        }
    }
}
