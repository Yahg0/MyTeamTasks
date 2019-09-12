using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.DAL
{
    class UsuarioDAO
    {
        private static Context ctx = SingletonContext.getInstance();

        public static void CadastrarUsuario(Usuario u) {
            ctx.Usuarios.Add(u);
            ctx.SaveChanges();
            Console.WriteLine(u);
        }

        public static List<Usuario> ListarUsuarios() => ctx.Usuarios.ToList();

        public static Usuario BuscarUsuarioPorNome(Usuario u) {
            return ctx.Usuarios.SingleOrDefault(x => x.Nickname.Equals(u.Nickname));
        }

        public static void RemoverUsuario(Usuario u) {

            //Busca primeiro e depois remove
            BuscarUsuarioPorNome(u);
            ctx.Usuarios.Remove(u);
            ctx.SaveChanges();
        }
    }
}
