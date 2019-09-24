using MyTeamTasksWpf.View.vTarefa;
using MyTeamTasksWpf.View.vAdmin;
using MyTeamTasksWpf.View.vDashboard;
using System.Windows;

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

        private void BtnConfigurações_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
