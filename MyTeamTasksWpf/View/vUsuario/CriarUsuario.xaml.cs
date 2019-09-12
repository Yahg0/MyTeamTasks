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
using MyTeamTasksWpf.DAL;
using MyTeamTasksWpf.Model;

namespace MyTeamTasksWpf.View.vUsuario
{
    /// <summary>
    /// Interaction logic for CriarUsuario.xaml
    /// </summary>
    public partial class CriarUsuario : Window
    {
        public CriarUsuario()
        {
            InitializeComponent();
        }

        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();

            lbMensagemSucesso.Content = "";


            if (!txtCargo.Text.Equals("") &&
                !txtNickName.Text.Equals("") &&
                !txtSenha.Text.Equals(""))
            {
                u.Cargo = txtCargo.Text;
                u.Nickname = txtNickName.Text;
                u.Senha = txtSenha.Text;

                UsuarioDAO.CadastrarUsuario(u);

                lbMensagemSucesso.Content = "Usuario inserido !";
            }
            else
            {
                MessageBox.Show("Preencha todos os campos antes de inserir !", 
                    "Campos vazios encontrados", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
