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

            ctx.SaveChanges();

            return u;
        }

    }
}
