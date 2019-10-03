using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
using MyTeamTasksWpf.Util;
using MyTeamTasksWpf.View.vAdmin;
using MyTeamTasksWpf.View.vDashboard;
using MyTeamTasksWpf.View.vProjeto;
using MyTeamTasksWpf.View.vTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyTeamTasksWpf.View.vLogin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Usuario u;
        
        public Login()
        {
            InitializeComponent();
        }
        public string userLogado { get; set; }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtUser.Text.Equals("") && !txtSenha.Password.Equals(""))
            {
                Dashboard dashboard = new Dashboard();
                ProjetoMenu pm = new ProjetoMenu();
                TarefaMenu tm = new TarefaMenu();
                AdminMenu am = new AdminMenu();
                CriarTarefa ct = new CriarTarefa();


                u = LoginDAO.AutenticarUsuario(txtUser.Text, txtSenha.Password);
                u.Nickname = txtUser.Text;

                if (u != null)
                {
                    u = UsuarioDAO.BuscarUsuarioPorNome(txtUser.Text);
                    if (u.Cargo.Equals("Gerente de projetos") || u.Cargo.Equals("Administrador"))
                    {
                        ValidaLogin.GerenteLogado = true;
                    }
                }

                #region Validações de acesso                
                //Valida se admin logado, se sim, habilita botão de configuração do sistema
                if (!txtUser.Text.Equals("admin"))
                {                    
                    //Desabilita botão de config quando não é adm
                    dashboard.btnConfigurações.IsEnabled = false;
                    pm.btnConfigurações.IsEnabled = false;
                    tm.btnConfigurações.IsEnabled = false;
                    am.btnConfigurações.IsEnabled = false;

                    //Atribui o valor do txtUser em uma variavel estatica
                    ValidaLogin.user = txtUser.Text;
                    ValidaLogin.adminLogado = false;

                    //Insere nome do user logado na label branca do menu superior
                    dashboard.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    dashboard.lbUserLogado.Content = ValidaLogin.user;

                    pm.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    pm.lbUserLogado.Content = ValidaLogin.user;

                    tm.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    tm.lbUserLogado.Content = ValidaLogin.user;


                    am.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    am.lbUserLogado.Content = ValidaLogin.user;
                }
                else
                {
                    //Habilita botão de config quando é adm
                    dashboard.btnConfigurações.IsEnabled = true;
                    pm.btnConfigurações.IsEnabled = true;
                    tm.btnConfigurações.IsEnabled = true;
                    am.btnConfigurações.IsEnabled = true;

                    ValidaLogin.user = txtUser.Text;
                    ValidaLogin.adminLogado = true;

                    dashboard.btnConfigurações.IsEnabled = true;

                    dashboard.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    dashboard.lbUserLogado.Content = ValidaLogin.user;

                    pm.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    pm.lbUserLogado.Content = ValidaLogin.user;

                    tm.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    tm.lbUserLogado.Content = ValidaLogin.user;


                    am.lbUserLogado.Foreground = new SolidColorBrush(Colors.White);
                    am.lbUserLogado.Content = ValidaLogin.user;
                }
               
                #endregion

                if (u != null)
                {
                
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    LimparCampos();
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Credenciais incorretas !");
                }
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha o LOGIN e SENHA para entrar !");
            }
            
        }

        private void MensagemDeConfirmacaoOuErro(String message, int Interval = 3000)
        {
            Timer timer = new Timer();
            timer.Interval = Interval;//Atribui intervalo em milisegundos
            lbMensagem.Dispatcher.Invoke(new Action(() => lbMensagem.Content = message));//Atribui a mensagem na label
            lbMensagem.Dispatcher.Invoke(new Action(() => lbMensagem.Visibility = Visibility.Visible));//Seta a label como visivel

            timer.Elapsed += (s, en) =>
            {
                lbMensagem.Dispatcher.Invoke(new Action(() => lbMensagem.Visibility = Visibility.Hidden));//Esconde a label com os milisegundos setados na Interval
                timer.Stop(); // Para o timer
            };
            timer.Start(); // Inicia o timer
        }

        public void LimparCampos()
        {
            txtUser.Clear();
            txtSenha.Clear();
        }
    }
}
