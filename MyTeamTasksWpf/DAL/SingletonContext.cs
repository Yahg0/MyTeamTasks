using MyTeamTasksWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamTasksWpf.DAL
{
    class SingletonContext
    {
        private SingletonContext() { }

        private static Context ctx;

        public static Context getInstance()
        {
            if (ctx == null)
            {
                ctx = new Context();
            }
            return ctx;
        }
        
    }
}
