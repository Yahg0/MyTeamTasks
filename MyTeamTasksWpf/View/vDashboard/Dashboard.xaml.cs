using MyTeamTasksWpf.View.vTarefa;
using MyTeamTasksWpf.View.vAdmin;
using MyTeamTasksWpf.View.vProjeto;
using System.Windows;
using System.Windows.Media;
using System;
using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
using LiveCharts;
using MyTeamTasksWpf.View.vLogin;
using MyTeamTasksWpf.Util;

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
            lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
            lbUserLogado.Content = ValidaLogin.user;
            btnConfigurações.IsEnabled = ValidaLogin.adminLogado;

            int users = UsuarioDAO.ListarUsuarios().Count;
            int projetos = ProjetoDAO.ListarProjetos().Count;
            int tarefas = TarefaDAO.ListarTarefas().Count;

            GraficoUsuarios.Value = users;            
            GraficoProjetos.Value = projetos;
            GraficoTarefas.Value = tarefas;




        }

    }
}
