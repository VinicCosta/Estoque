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
    public partial class Desativar : Form
    {
        string strSQL;           
        SqlCommand cmd = new SqlCommand();        
        ServiceConnection connService = new ServiceConnection();
        SqlDataReader dr;   

        public Desativar()
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

            DialogResult retorno = MessageBox.Show("Deseja desativar este produto?", "Desativação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (retorno == DialogResult.Yes)
            {
                try
                {
                    strSQL = "DELETE FROM ESTOQUE WHERE ID_PRODUTO = '" + txtCodigo.Text + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    
                    Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
                finally
                {
                    dr.Close();
                    connService.conn.Close();
                    Close();
                }                
            }
            else
            {
               connService.conn.Close();
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

    }
}
