using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
using MyTeamTasksWpf.View.vDashboard;
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

        public string userLogado;

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtUser.Text.Equals("") && !txtSenha.Password.Equals(""))
            {
                u = LoginDAO.AutenticarUsuario(txtUser.Text, txtSenha.Password);
                userLogado = txtUser.Text;

                if (u != null)
                {
                    Dashboard dashboard = new Dashboard();
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
