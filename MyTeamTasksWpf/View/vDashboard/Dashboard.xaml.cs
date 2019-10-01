using MyTeamTasksWpf.View.vTarefa;
using MyTeamTasksWpf.View.vAdmin;
using MyTeamTasksWpf.View.vProjeto;
using System.Windows;
using System.Windows.Media;
using System;
using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
using LiveCharts;


namespace MyTeamTasksWpf.View.vDashboard
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        Usuario u;

        public SeriesCollection SeriesCollection { get; private set; }

        private void BtnProjeto_Click(object sender, RoutedEventArgs e)
        {
            ProjetoMenu projetoMenu = new ProjetoMenu();
            projetoMenu.Show();
            this.Close();
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

        private void BtnConfigurações_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbUserLogado.Content = "";
            u = LoginDAO.GetUsuarioLogado();
            lbUserLogado.Content = u.Nickname;
            lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
            u.Logado = false;

            int users = UsuarioDAO.ListarUsuarios().Count;

            Pizza.Value = users;


        }

    }
}
