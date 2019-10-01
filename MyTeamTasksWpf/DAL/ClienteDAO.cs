using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.DAL
{
    class ClienteDAO
    {
        private static Context ctx = SingletonContext.getInstance();  


        public static void CadastrarCliente(Cliente c) {
            ctx.Clientes.Add(c);
            ctx.SaveChanges();
        }


        public static List<Cliente> ListarClientes() => ctx.Clientes.ToList();

        public static Cliente BuscarClientePorNome(string nome)
        {
            return ctx.Clientes.FirstOrDefault(x => x.Nome.Equals(nome));
        }

        public static bool RemoverCliente(Cliente c)
        {
            try
            {
                ctx.Clientes.Remove(c);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public static bool AlterarCliente(Cliente c)
        {
            try
            {
                ctx.Entry(c).State = EntityState.Modified;
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

