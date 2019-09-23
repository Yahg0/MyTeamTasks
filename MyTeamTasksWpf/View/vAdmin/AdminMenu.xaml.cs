using MyTeamTasksWpf.View.Tarefa;
using MyTeamTasksWpf.View.vDashboard;
using MyTeamTasksWpf.View.vProjeto;
using MyTeamTasksWpf.View.vTarefa;
using MyTeamTasksWpf.View.vUsuario;
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
