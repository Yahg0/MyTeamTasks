using MyTeamTasksWpf.View.vTarefa;
using MyTeamTasksWpf.View.vDashboard;
using MyTeamTasksWpf.View.vProjeto;
using MyTeamTasksWpf.View.vUsuario;
using System.Windows;
using MyTeamTasksWpf.View.vCliente;

namespace MyTeamTasksWpf.View.vAdmin
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

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

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            CriarCliente criarCliente = new CriarCliente();
            criarCliente.Show();            
        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            CriarUsuario criarUsuario = new CriarUsuario();
            criarUsuario.Show();
        }

        private void BtnProjetos_Click(object sender, RoutedEventArgs e)
        {
            CriarProjeto criarProjeto = new CriarProjeto();
            criarProjeto.Show();
            
        }
    }
}
