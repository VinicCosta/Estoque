using Estoque.View;

namespace Estoque
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Chama a tela de Editar
            Editar editar = new Editar();
            editar.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Chama a tela de Cadatro
            Cadastro cadastro = new Cadastro();
            cadastro.ShowDialog();
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            Desativar desativar = new Desativar();
            desativar.ShowDialog();
        }
    }
}