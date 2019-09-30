using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.DAL
{
    class ProjetoDAO
    {
        private static Context ctx = SingletonContext.getInstance();
        //Cadastro do projeto-
        public static void CadastrarProjeto(Projeto p) {
            ctx.Projetos.Add(p);


            ctx.SaveChanges();
        }

        public static List<Projeto> ListarProjetos() => ctx.Projetos.ToList();

        public static Projeto BuscarProjetoPorNome(string nome) {
            return ctx.Projetos.FirstOrDefault(x => x.Nome.Equals(nome));
        }

        public static List<Projeto> BuscarProjetoPorstatus(Projeto p)
        {
            return ctx.Projetos.Where(x => x.Status == p.Status).ToList();
        }

        public static bool RemoverProjeto(Projeto p) {
            try
            {
                ctx.Projetos.Remove(p);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AlterarProjeto(Projeto p) {
            try
            {
                ctx.Entry(p).State = EntityState.Modified;
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
