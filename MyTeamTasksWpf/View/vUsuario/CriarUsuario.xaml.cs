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
            //lbMensagem.Content = "";

            if (!txtCargo.Text.Equals("") &&
                !txtNickName.Text.Equals("") &&
                !txtSenha.Text.Equals(""))
            {
                u = new Usuario()
                {
                    Cargo = txtCargo.Text,
                    Nickname = txtNickName.Text,
                    Senha = txtSenha.Text
                };

                UsuarioDAO.CadastrarUsuario(u);

                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                MensagemDeConfirmacaoOuErro("Usuario inserido !");
                LimparCampos();

            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha todos os campos antes de inserir !");
            }

        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNickName.Text.Equals(""))
            {
                u = UsuarioDAO.BuscarUsuarioPorNome(txtNickName.Text);
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

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem certeza de que deseja remover este usuario ?",
                   "Gerenciar usuarios",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                if (UsuarioDAO.RemoverUsuario(u))
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    MensagemDeConfirmacaoOuErro("Usuario removido !");
                    LimparCampos();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Não foi possivel remover o usuario selecionado, revise os campos !");
                }
            }
        }
       
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {            
            if (!txtCargo.Text.Equals("") &&
                !txtNickName.Text.Equals("") &&
                !txtSenha.Text.Equals(""))
            {
                u.Cargo = txtCargo.Text;
                u.Nickname = txtNickName.Text;
                u.Senha = txtSenha.Text;               
                
                if (UsuarioDAO.AlterarUsuario(u))
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    MensagemDeConfirmacaoOuErro("Usuario alterado !");
                    LimparCampos();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Erro! Usuario não alterado, revise os campos");
                }
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha os campos antes de editar !");
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

        public void LimparCampos() {
            txtId.Clear();
            txtCargo.Clear();
            txtNickName.Clear();
            txtSenha.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dglista.ItemsSource = UsuarioDAO.ListarUsuarios();
        }

        private void BtnAtualizarGrid_Click(object sender, RoutedEventArgs e)
        {
            dglista.ItemsSource = UsuarioDAO.ListarUsuarios();
        }
    }
}
