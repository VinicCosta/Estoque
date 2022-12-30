using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.View
{
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Deseja cancelar a operação?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (retorno == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //criar conexão com o banco para atualizar o produto

            MessageBox.Show("Produto Cadastrado!");

            DialogResult retorno = MessageBox.Show("Deseja cadastrar outro produto?", "Cadastrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retorno == DialogResult.Yes)
            {
                cbUnidadeMedida.ResetText();
                mtbPrecoCusto.Clear();
                mtbLucro.Clear();
                txtProduto.Clear();
                txtQuantidade.Clear();
            }
            else
            {
                Close();
            }
        }
    }
}
