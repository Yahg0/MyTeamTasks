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

namespace MyTeamTasksWpf.View.vDashboard
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private string nickname;
        Usuario u;

        public Dashboard()
        {
            InitializeComponent();
        }
        public Dashboard(Usuario u)
        {
            InitializeComponent();
            nickname = u.Nickname;
            lbUserLogado.Content = nickname;
        }

       

        public SeriesCollection SeriesCollection { get; private set; }

        private void BtnProjeto_Click(object sender, RoutedEventArgs e)
        {
            ProjetoMenu projetoMenu = new ProjetoMenu(nickname);
            projetoMenu.Show();
            this.Close();
        }

        private void BtnTarefas_Click(object sender, RoutedEventArgs e)
        {
            TarefaMenu tarefaMenu = new TarefaMenu(nickname);
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

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            
            Console.WriteLine("Nome do user" + login.txtUser.Text);
            u = new Usuario();

            u.Nickname = nickname;
            
            u = LoginDAO.GetUsuarioLogado();
            //lbUserLogado.Content = u.Nickname;
            lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
            //u.Logado = false;

            //Validação de usuario logado
            try
            {
                if (nickname.Equals("Admin"))
                {
                    btnConfigurações.IsEnabled = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erro");
            }
           

            int users = UsuarioDAO.ListarUsuarios().Count;

            Pizza.Value = users;


        }

        

    }
}
