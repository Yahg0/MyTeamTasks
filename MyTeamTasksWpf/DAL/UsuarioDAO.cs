using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        public static Usuario BuscarUsuarioPorNome(string nome) {
            return ctx.Usuarios.FirstOrDefault(x => x.Nickname.Equals(nome));
        }


        public static bool RemoverUsuario(Usuario u)
        {

            try
            {              
                ctx.Usuarios.Remove(u);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public static bool AlterarUsuario(Usuario u)
        {           
            try
            {
                ctx.Entry(u).State = EntityState.Modified;                
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
