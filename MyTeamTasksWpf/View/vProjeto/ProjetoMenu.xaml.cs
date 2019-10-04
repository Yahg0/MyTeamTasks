using MyTeamTasksWpf.View.vTarefa;
using MyTeamTasksWpf.View.vAdmin;
using MyTeamTasksWpf.View.vDashboard;
using System.Windows;
using MyTeamTasksWpf.DAL;
using System.Windows.Media;
using MyTeamTasksWpf.Util;

namespace MyTeamTasksWpf.View.vProjeto
{
    /// <summary>
    /// Interaction logic for ProjetoMenu.xaml
    /// </summary>
    public partial class ProjetoMenu : Window
    {
        //private string nickname;
        public ProjetoMenu()
        {
            InitializeComponent();
        }

        //public ProjetoMenu(string nickname)
        //{
        //    InitializeComponent();            
        //    this.nickname = nickname;
        //    lbUserLogado.Content = nickname;
        //}

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

        private void DgProjetos_Loaded(object sender, RoutedEventArgs e)
        {
            dgProjetos.ItemsSource = ProjetoDAO.ListarProjetos();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
            lbUserLogado.Content = ValidaLogin.user;
            btnConfigurações.IsEnabled = ValidaLogin.adminLogado;
        }
    }
}
