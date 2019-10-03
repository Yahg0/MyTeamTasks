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
    public partial class CriarTarefa : Window
    {
        Tarefa t;
        Projeto p;
        Cliente c;
        Usuario assinatura;
        Usuario requisitante;
        DateTime criadoEm = DateTime.Now;

        public CriarTarefa()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbProjetos.ItemsSource = ProjetoDAO.ListarProjetos();
            cbCliente.ItemsSource = ClienteDAO.ListarClientes();
            cbAssinatura.ItemsSource = UsuarioDAO.ListarUsuarios();
            cbRequisitante.ItemsSource = UsuarioDAO.ListarUsuarios();

            dtCriadoEm.Text = DateTime.Now.ToString();

            cbAssinatura.IsEnabled = ValidaLogin.GerenteLogado;

        }

        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
      
            if (!txtNomeTarefa.Text.Equals("")&&
                !txtTipo.Text.Equals("") &&
                !cbRequisitante.SelectedValue.Equals("")
                )
            {
            
                t = new Tarefa()
                {
                    Titulo = txtNomeTarefa.Text,
                    Tipo = txtTipo.Text,
                    Status = txtStatus.Text,
                    Prioridade = txtPrioridade.Text,
                    Resolucao = txtResolucao.Text,
                    Descricao = txtDesc.Text
                };
                p = new Projeto() {
                    Nome = cbProjetos.SelectedValue.ToString(),
                };//Validar aqui, cliente vazio estoura exceção
                c = new Cliente() {
                    Nome = cbCliente.SelectedValue.ToString(),
                };
                assinatura = new Usuario() {
                    Nickname = cbAssinatura.SelectedValue.ToString(),                    
                };
                requisitante = new Usuario() {
                    Nickname = cbRequisitante.SelectedValue.ToString(),
                };
                p = ProjetoDAO.BuscarProjetoPorNome(p.Nome);
                t.Projeto = p;

                c = ClienteDAO.BuscarClientePorNome(c.Nome);
                t.Cliente = c;

                assinatura = UsuarioDAO.BuscarUsuarioPorNome(assinatura.Nome);
                t.Assinatura = assinatura;

                requisitante = UsuarioDAO.BuscarUsuarioPorNome(requisitante.Nome);
                t.Requisitante = requisitante;

                t.CriadoEm = DateTime.Now;
                

                TarefaDAO.CadastrarTarefa(t);

                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkGreen);
                MensagemDeConfirmacaoOuErro("Tarefa criada !");
                LimparCampos();

            }
            else
            {
                lbMensagem.Foreground = new SolidColorBrush(Colors.DarkRed);
                MensagemDeConfirmacaoOuErro("Preencha os campos obrigatórios para criar uma tarefa !");
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
    }
}
