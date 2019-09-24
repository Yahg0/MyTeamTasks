using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.DAL
{
    class TarefaDAO
    {
        private static Context ctx = SingletonContext.getInstance();

        public static void CadastrarTarefa(Tarefa t)
        {
            ctx.Tarefas.Add(t);
            ctx.SaveChanges();
        }

        public static List<Tarefa> ListarTarefas() => ctx.Tarefas.ToList();

        public static List<Tarefa> BuscarTarefaPorStatus(Tarefa t)
        {
            return ctx.Tarefas.Where(x => x.Status == t.Status).ToList();
        }

        public static bool RemoverTarefa(Tarefa t) {
            try
            {
                ctx.Tarefas.Remove(t);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool EditarTarefa(Tarefa t) {
            try
            {
                ctx.Entry(t).State = EntityState.Modified;
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
