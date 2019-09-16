using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
