using MyTeamTasksWpf.View.Tarefa;
using MyTeamTasksWpf.View.vDashboard;
using MyTeamTasksWpf.View.vTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyTeamTasksWpf.View.vProjeto
{
    /// <summary>
    /// Interaction logic for ProjetoMenu.xaml
    /// </summary>
    public partial class ProjetoMenu : Window
    {
        public ProjetoMenu()
        {
            InitializeComponent();
        }

        private void BtnTarefas_Click(object sender, RoutedEventArgs e)
        {
            TarefaMenu tarefaMenu = new TarefaMenu();
            tarefaMenu.Show();
            this.Close();
        }

        private void BtnCriar_Click(object sender, RoutedEventArgs e)
        {
            CriarTarefa criarTarefa = new CriarTarefa();
            criarTarefa.Show();
        }

        private void BtnProjeto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDashboard_Click_1(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
