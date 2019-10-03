using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
using System.Data.Entity;
namespace MyTeamTasksWpf.Utils
{
    class ValidaLogin
    {
        private ValidaLogin()
        {
            Usuario = new Usuario();
        }

        private static Context ctx = SingletonContext.getInstance();
        private static Usuario Usuario { get; set; }
        public static Usuario AlteraStatusLogin(Usuario u)
        {
            ctx.Entry(u).State = EntityState.Modified;
            u.Logado = true;
            ctx.SaveChanges();
            Usuario = UsuarioDAO.BuscarUsuarioPorNome(u.Nickname);
            return Usuario;
        }
        public static Usuario GetUsuarioLogado()
        {
            return Usuario;
        }
        public static void LogoutUsuario()
        {
            ctx.Entry(Usuario).State = EntityState.Modified;
            Usuario.Logado = false;
            ctx.SaveChanges();
            Usuario = null;
        }
    }
}
