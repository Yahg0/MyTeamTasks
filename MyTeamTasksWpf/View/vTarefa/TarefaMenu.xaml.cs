using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.View.vTarefa;
using MyTeamTasksWpf.View.vAdmin;
using MyTeamTasksWpf.View.vDashboard;
using MyTeamTasksWpf.View.vProjeto;
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

namespace MyTeamTasksWpf.View.vTarefa
{
    /// <summary>
    /// Interaction logic for TarefaMenu.xaml
    /// </summary>
    public partial class TarefaMenu : Window
    {
        public TarefaMenu()
        {
            InitializeComponent();
        }
        
 
        private void BtnProjeto_Click(object sender, RoutedEventArgs e)
        {
            ProjetoMenu projetoMenu = new ProjetoMenu();
            projetoMenu.Show();
            this.Close();
        }

        private void BtnCriar_Click(object sender, RoutedEventArgs e)
        {
            CriarTarefa criarTarefa = new CriarTarefa();
            criarTarefa.Show();
        }

        private void BtnTarefas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void BtnConfigurações_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgTarefas.ItemsSource = TarefaDAO.ListarTarefas();
        }

    }
}
