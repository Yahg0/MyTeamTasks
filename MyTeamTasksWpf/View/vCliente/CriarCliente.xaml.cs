using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
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

namespace MyTeamTasksWpf.View.vCliente
{
    /// <summary>
    /// Lógica interna para CriarCliente.xaml
    /// </summary>
    public partial class CriarCliente : Window
    {
        Cliente c;
        public CriarCliente()
        {
            InitializeComponent();
        }


        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
            //lbMensagem.Content = "";


            if (!txtNome.Text.Equals(""))
            {
                c = new Cliente()
                {
                    Nome = txtNome.Text
                };

                ClienteDAO.CadastrarCliente(c);

                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                MensagemDeConfirmacaoOuErro("Cliente inserido !");
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
            if (!txtNome.Text.Equals(""))
            {
                c = ClienteDAO.BuscarClientePorNome(txtNome.Text);
                if (c != null)
                {
                    txtId.Text = c.ClienteId.ToString();
                    txtNome.Text = c.Nome;


                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Cliente não encontrado !");
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
                if (ClienteDAO.RemoverCliente(c))
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    MensagemDeConfirmacaoOuErro("Cliente removido !");
                    LimparCampos();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Não foi possivel remover o cliente selecionado, revise os campos !");
                }
            }
        }



        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNome.Text.Equals(""))
            {
                c.Nome = txtNome.Text;
                if (ClienteDAO.AlterarCliente(c))
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    MensagemDeConfirmacaoOuErro("Cliente alterado !");
                    LimparCampos();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Erro! CLiente não alterado, revise os campos");
                }
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha os campos antes de editar !");
            }
        }



        private void BtnAtualizarGrid_Click(object sender, RoutedEventArgs e)
        {
            dglista.ItemsSource = ClienteDAO.ListarClientes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dglista.ItemsSource = ClienteDAO.ListarClientes();
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
            txtId.Clear();
            txtNome.Clear();
        }
    }
}
