using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.Util
{
    class ValidaLogin
    {
        public static string user { get; set; }
        //private ValidaLogin()
        //{
        //    Usuario = new Usuario();
        //}

        //private static Context ctx = SingletonContext.getInstance();
        //private static Usuario Usuario { get; set; }
        //public static Usuario AlteraStatusLogin(Usuario u)
        //{
        //    ctx.Entry(u).State = EntityState.Modified;
        //    u.Logado = "Sim";
        //    ctx.SaveChanges();
        //    Usuario = UsuarioDAO.BuscarUsuarioPorNome(u.Nickname);
        //    return Usuario;
        //}
        //public static Usuario GetUsuarioLogado()
        //{
        //    return Usuario;
        //}
        //public static void LogoutUsuario()
        //{
        //    ctx.Entry(Usuario).State = EntityState.Modified;
        //    Usuario.Logado = "Não";
        //    ctx.SaveChanges();
        //    Usuario = null;
        //}
    }
}
