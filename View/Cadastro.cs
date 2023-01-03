using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Estoque.View
{
    public partial class Cadastro : Form
    {
        // Variaveis globais
        decimal precoVenda = 0, precoTotal = 0;

        public Cadastro()
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
            //criar conexão com o banco e verificar se produto ja está cadastrado

            if (string.IsNullOrEmpty(txtProduto.Text))
            {
                MessageBox.Show("O nome do produto não pode ser vazio!");
            }
            if (cbUnidadeMedida.Text != null && mtbLucro.Text != null && mtbPrecoCusto.Text != null &&
                txtProduto.Text != null && txtPrecoTotal.Text != null && txtPrecoVenda.Text != null && 
                txtQuantidade.Text != null)
            {
                GravarDadosDB();
            }

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
        public void ValidaDadosCadastro()
        {
            if(mtbLucro.Text == "   %")
            {
                txtPrecoTotal.Clear();
                txtPrecoVenda.Clear();
                return;
            }
            // Captura os dados digitados
            string nomeProduto = txtProduto.Text;
            int quantidade = Convert.ToInt32(txtQuantidade.Text);
            decimal precoCusto = Convert.ToDecimal(mtbPrecoCusto.Text.Replace("R$ ","").Trim());
            decimal lucro = Convert.ToDecimal(mtbLucro.Text.Replace("%","").Trim());
            string unidadeMedida = cbUnidadeMedida.Text;

            try
            {
                precoVenda = (precoCusto * (lucro / 100) + precoCusto);
                precoTotal = precoVenda * quantidade;
                txtPrecoVenda.Text = "R$ " + precoVenda.ToString("0.00");
                txtPrecoTotal.Text = "R$ " + precoTotal.ToString("0.00");
            }
            catch { }
            
        }

        private void mtbLucro_KeyUp(object sender, KeyEventArgs e)
        {
            ValidaDadosCadastro();
            // chamar o metodo BuscarProximoId();
            BuscarProximoId();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                
        }

        private SqlConnection GetConnectionString()
        {
            // Cria a string de conexão
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EB11LVD\\SQLEXPRESS;Initial Catalog=ESTOQUE;Integrated Security=True");
            return conn; 
        }

        private void GravarDadosDB()
        {         
            //string de inserção no banco de dados
            string sql = $"INSERT INTO [dbo].[ESTOQUE]([NOME_PRODUTO],[QUANTIDADE_PRODUTO],[UND_MEDIDA],[PRECO_CUSTO],[LUCRO_PRODUTO],[PRECO_VENDA],[PRECO_TOTAL])" +
                "VALUES(@nome_produto,@quantidade_produto,@und_medida,@preco_custo,@lucro_produto,@preco_venda,@preco_total)";

            try
            {
                //Cria um objeto de comando passando os parametros do comando
                SqlCommand cmd = new SqlCommand(sql, GetConnectionString());

                //Insere os dados dos elementos da tela no comando sql
                cmd.Parameters.Add(new SqlParameter("nome_produto", txtProduto.Text));
                cmd.Parameters.Add(new SqlParameter("quantidade_produto", Convert.ToInt32(txtQuantidade.Text)));
                cmd.Parameters.Add(new SqlParameter("und_medida", cbUnidadeMedida.Text));
                cmd.Parameters.Add(new SqlParameter("preco_custo", Convert.ToDecimal(mtbPrecoCusto.Text.Replace("R$ ", "").Trim())));
                cmd.Parameters.Add(new SqlParameter("lucro_produto", Convert.ToInt32(mtbLucro.Text.Replace("%",""))));
                cmd.Parameters.Add(new SqlParameter("preco_venda", precoVenda));
                cmd.Parameters.Add(new SqlParameter("preco_total", precoTotal));

                //Abre conexão  com o banco de dados 
                GetConnectionString().Open();

                //Execução do comando
                cmd.BeginExecuteNonQuery();

                //Fecha conexão  com o banco de dados 
                GetConnectionString().Close();

                MessageBox.Show("Produto Cadastrado!");
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao inserir" + ex);
            }
            finally
            {
                GetConnectionString().Close();
            }
        }

        private void BuscarDadosDB()
        {
            //string de inserção no banco de dados
            string sql = "SELECT * FROM dbo.ESTOQUE;";

            try
            {
                //Cria um objeto de comando passando os parametros do comando
                SqlCommand cmd = new SqlCommand(sql, GetConnectionString());

                //Abre conexão  com o banco de dados 
                GetConnectionString().Open();

                //Execução do comando
                cmd.BeginExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();



                //Implementar a visualização dos dados

                //Fecha conexão  com o banco de dados 
                GetConnectionString().Close();
            }
            catch { }
        }

        private void BuscarProximoId()
        {
            //string de inserção no banco de dados
            string sql = "SELECT MAX(ID_PRODUTO) + 1 FROM dbo.ESTOQUE";
            try
            {
                //Cria um objeto de comando passando os parametros do comando
                SqlCommand cmd = new SqlCommand(sql, GetConnectionString());

                //Abre conexão  com o banco de dados 
                GetConnectionString().Open();

                //Execução do comando
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                txtCodigoId.Text = reader.ToString();
                


                //Implementar a visualização dos dados

                //Fecha conexão  com o banco de dados 
                GetConnectionString().Close();
            }
            catch { }
        }
    }
}
