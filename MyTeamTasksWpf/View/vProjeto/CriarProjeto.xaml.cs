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

namespace MyTeamTasksWpf.View.vProjeto
{
    /// <summary>
    /// Interaction logic for CriarProjeto.xaml
    /// </summary>
    public partial class CriarProjeto : Window
    {
        Projeto p;
        Cliente c;

        public CriarProjeto()
        {
            InitializeComponent();
        }

        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNome.Text.Equals("") &&
                !txtStatus.Text.Equals(""))
            {
                c = new Cliente()
                {
                    Nome = cbClientes.SelectedValue.ToString()
                };
                p = new Projeto()            
                {
                    Nome = txtNome.Text,
                    Status = txtStatus.Text,
                    
                };
                p.Cliente = c;//Atribui cliente ao projeto

                ProjetoDAO.CadastrarProjeto(p);

                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                MensagemDeConfirmacaoOuErro("Projeto cadastrado !");
                LimparCampos();
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha todos os campos antes de cadastrar !");
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNome.Text.Equals("") &&
                !txtStatus.Text.Equals("") &&
                !cbClientes.SelectedValue.Equals(""))
            {
                p.Nome = txtNome.Text;
                p.Status = txtStatus.Text;
                p.Cliente.Nome = cbClientes.SelectedValue.ToString();

                if (ProjetoDAO.AlterarProjeto(p))
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    MensagemDeConfirmacaoOuErro("Projeto alterado !");
                    LimparCampos();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Erro! Projeto não alterado, revise os campos");
                }
            }
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNome.Equals(""))
            {
                p = ProjetoDAO.BuscarProjetoPorNome(txtNome.Text);
                if (p != null)
                {
                    txtId.Text = p.ProjetoId.ToString();
                    txtNome.Text = p.Nome;
                    txtStatus.Text = p.Status;
                    
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Projeto não encontrado !");
                }
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Informe o nome do projeto antes de pesquisar !");
            }
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem certeza de que deseja remover este projeto ?",
                   "Gerenciar projetos",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                if (ProjetoDAO.RemoverProjeto(p))
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    MensagemDeConfirmacaoOuErro("Projeto removido !");
                    LimparCampos();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Não foi possivel remover o projeto selecionado, revise os campos !");
                }
            }
        }

        private void BtnAtualizarGrid_Click(object sender, RoutedEventArgs e)
        {
            dglista.ItemsSource = ProjetoDAO.ListarProjetos();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbClientes.ItemsSource = ClienteDAO.ListarClientes();
            dglista.ItemsSource = ProjetoDAO.ListarProjetos();

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
            txtNome.Clear();
            txtStatus.Clear();
            cbClientes.SelectedValue = "";
        }
    }
}
