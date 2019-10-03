using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;
using MyTeamTasksWpf.Util;
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

namespace MyTeamTasksWpf.View.vTarefa
{
    /// <summary>
    /// Interaction logic for CriarTarefa.xaml
    /// </summary>
    public partial class AtualizarTarefa : Window
    {
        Tarefa t;
        Projeto p;
        Cliente c;
        Usuario assinatura;
        Usuario requisitante;
        DateTime criadoEm = DateTime.Now;

        public AtualizarTarefa()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbProjetos.ItemsSource = ProjetoDAO.ListarProjetos();
            //cbCliente.ItemsSource = ClienteDAO.ListarClientes()
            cbAssinatura.ItemsSource = UsuarioDAO.ListarUsuarios();
            cbRequisitante.ItemsSource = UsuarioDAO.ListarUsuarios();

            dtCriadoEm.Text = DateTime.Now.ToString();

            cbAssinatura.IsEnabled = ValidaLogin.GerenteLogado;

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
            txtNomeTarefa.Clear();
            txtTipo.Clear();
            txtStatus.Clear();
            txtPrioridade.Clear();
            txtResolucao.Clear();
            txtDesc.Clear();

            //CriarTarefa tela = new CriarTarefa();
            //tela.Show();
            //this.Close();
            
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtIdTarefa.Text.Equals(""))
            {
                t = TarefaDAO.BuscarTarefaPorId(Convert.ToInt32(txtIdTarefa.Text));
                if (t != null)
                {
                    txtIdTarefa.Text = t.TarefaId.ToString();
                    txtNomeTarefa.Text = t.Titulo;
                    txtTipo.Text = t.Tipo;
                    txtStatus.Text = t.Status;
                    txtPrioridade.Text = t.Prioridade.ToString();
                    txtResolucao.Text = t.Resolucao;
                    txtDesc.Text = t.Descricao;
                    //cbAssinatura.SelectedItem = t.Assinatura.Nickname.ToString();
                    //cbCliente.SelectedValue = t.Cliente.Nome;
                    //cbRequisitante.SelectedValue = t.Requisitante.Nickname;
                    dtCriadoEm.Text = t.CriadoEm.ToString();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Tarefa não encontrada !");
                }
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Informe o nome da tarefa antes de pesquisar !");
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtIdTarefa.Text.Equals(""))
            {
                t.TarefaId = Convert.ToInt32(txtIdTarefa.Text);

                if (TarefaDAO.EditarTarefa(t))
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                    MensagemDeConfirmacaoOuErro("Tarefa atualizada !");
                    LimparCampos();
                }
                else
                {
                    lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                    MensagemDeConfirmacaoOuErro("Erro! Tarefa não foi atualizada, revise os campos");
                }
            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Informe o ID da tarefa para buscar");
            }
        }
    }
}
