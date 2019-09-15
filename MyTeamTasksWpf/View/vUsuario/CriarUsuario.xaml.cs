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
using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;

namespace MyTeamTasksWpf.View.vUsuario
{
    /// <summary>
    /// Interaction logic for CriarUsuario.xaml
    /// </summary>
    public partial class CriarUsuario : Window
    {
        Usuario u;

        public CriarUsuario()
        {
            InitializeComponent();
        }

        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
            u = new Usuario();

            lbMensagem.Content = "";

            if (!txtCargo.Text.Equals("") &&
                !txtNickName.Text.Equals("") &&
                !txtSenha.Text.Equals(""))
            {
                u.Cargo = txtCargo.Text;
                u.Nickname = txtNickName.Text;
                u.Senha = txtSenha.Text;

                UsuarioDAO.CadastrarUsuario(u);

                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                //lbMensagem.Content = "Usuario inserido !";
                MensagemDeConfirmacaoOuErro("Usuario inserido !");

            }
            else
            {
                //MessageBox.Show("Preencha todos os campos antes de inserir !", 
                //    "Campos vazios encontrados", 
                //    MessageBoxButton.OK, MessageBoxImage.Error);
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha todos os campos antes de inserir !");
            }

        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNickName.Text.Equals("")){
                u.Nickname = txtNickName.Text;

                u = UsuarioDAO.BuscarUsuarioPorNome(u);

                if (u != null)
                {
                    txtId.Text = u.UsuarioId.ToString();
                    txtCargo.Text = u.Cargo;
                    txtNickName.Text = u.Nickname;
                    txtSenha.Text = u.Senha;
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Usuario não encontrado !");
                }
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha o nickname antes de pesquisar !");
            }
        }

        private void MensagemDeConfirmacaoOuErro(String message, int Interval = 3000)
        {
            Timer timer = new Timer();
            timer.Interval = Interval;//Atribui intervalo em milisegundos
            lbMensagem.Dispatcher.Invoke(new Action(() => lbMensagem.Content = message));//Atribui a mensagem na label
            lbMensagem.Dispatcher.Invoke(new Action(() => lbMensagem.Visibility = Visibility.Visible));//Seta a label como visivel

            timer.Elapsed += (s, en) => {
                lbMensagem.Dispatcher.Invoke(new Action(() => lbMensagem.Visibility = Visibility.Hidden));//Esconde a label com os milisegundos setados na Interval
                timer.Stop(); // Para o timer
            };
            timer.Start(); // Inicia o timer
        }
    }
}
