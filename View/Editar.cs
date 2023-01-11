using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estoque.Services;
namespace Estoque.View
{
    public partial class Editar : Form
    {
        decimal precoVenda = 0, precoTotal = 0;
        string strSQL;           
        SqlCommand cmd = new SqlCommand();        
        ServiceConnection connService = new ServiceConnection();
        SqlDataReader dr;   

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
            connService.conn.Open();
            cmd.Connection = connService.conn;

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

        public void ConsultaDadosDB()
        {
            try
            {
                //criar conexão com o banco 
                connService.conn.Open();
                cmd.Connection = connService.conn;

                if (txtCodigo != null)
                {
                    strSQL = "SELECT * FROM ESTOQUE WHERE ID_PRODUTO = '" + txtCodigo.Text + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        NaoCadastrado();
                    }
                    else
                    {
                        dr.Read();
                        ConsultaProdutos();
                    }
                    if (!dr.IsClosed){ dr.Close(); }
                    connService.conn.Close();
                }
                else if(cbProduto != null)
                {
                    strSQL = "SELECT * FROM ESTOQUE WHERE NOME_PRODUTO = '" + cbProduto.Text + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        NaoCadastrado();
                    }
                    else
                    {
                        dr.Read();
                        ConsultaProdutos();
                    }
                }
                else
                {
                    NaoCadastrado();
                }
                if (!dr.IsClosed) { dr.Close(); }
                connService.conn.Close();
            }
            catch (SqlException ex) 
            { 
                MessageBox.Show("Ocorreu um erro: " + ex.Message); 
            }
            finally
            {
                connService.conn.Close();
            }
        }

        private void ConsultaProdutos()
        {
            txtCodigo.Text = dr["ID_PRODUTO"].ToString();
            txtProduto.Text = dr["NOME_PRODUTO"].ToString();
            txtQuantidade.Text = dr["QUANTIDADE_PRODUTO"].ToString();
            cbUnidadeMedida.Text = dr["UND_MEDIDA"].ToString();
            txtPrecoTotal.Text = "R$ " + dr["PRECO_TOTAL"].ToString();
            txtPrecoVenda.Text = "R$ " + dr["PRECO_VENDA"].ToString();
            mtbPrecoCusto.Text = dr["PRECO_CUSTO"].ToString();
            mtbLucro.Text = dr["LUCRO_PRODUTO"].ToString();           

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                ConsultaDadosDB();
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Ocorreu um erro: " + ex); 
            }
        }

        public void NaoCadastrado()
        {
            MessageBox.Show("Produto não cadastrado!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Editar_Load(object sender, EventArgs e)
        {

        }

        public void ValidaDadosCadastro()
        {

            if (mtbLucro.Text == "   %")
            {
                txtPrecoTotal.Clear();
                txtPrecoVenda.Clear();
                return;
            }
            // Captura os dados digitados
            string nomeProduto = txtProduto.Text;
            int quantidade = Convert.ToInt32(txtQuantidade.Text);
            decimal precoCusto = Convert.ToDecimal(mtbPrecoCusto.Text.Replace("R$ ", "").Trim());
            decimal lucro = Convert.ToDecimal(mtbLucro.Text.Replace("%", "").Trim());
            string unidadeMedida = cbUnidadeMedida.Text;

            try
            {
                precoVenda = (precoCusto * (lucro / 100) + precoCusto);
                precoTotal = precoVenda * quantidade;
                txtPrecoVenda.Text = "R$ " + precoVenda.ToString("0.00");
                txtPrecoTotal.Text = "R$ " + precoTotal.ToString("0.00");
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Ocorreu um erro: " + ex); 
            }

        }
    }
}
