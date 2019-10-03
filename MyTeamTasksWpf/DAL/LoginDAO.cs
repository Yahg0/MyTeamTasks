using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.DAL
{
    class LoginDAO
    {
        private static Context ctx = SingletonContext.getInstance();        

        public static Usuario AutenticarUsuario(string nome, string senha)
        {
            Usuario u;
            u = ctx.Usuarios.FirstOrDefault(x => x.Nickname.Equals(nome));
            u = ctx.Usuarios.FirstOrDefault(x => x.Senha.Equals(senha));

            AlteraStatusLogin(u);

            ctx.SaveChanges();

            return u;
        }

        public static Usuario AlteraStatusLogin(Usuario u)
        {
            ctx.Entry(u).State = EntityState.Modified;
            u.Logado = true;
            ctx.SaveChanges();
            return u;
        }
        public static Usuario GetUsuarioLogado()
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Logado == true);
        }
    }
}
