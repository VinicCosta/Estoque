namespace Estoque.View
{
    partial class Desativar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProduto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnConfirmaDesativacao = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desativação";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produto:";
            // 
            // cbProduto
            // 
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.Location = new System.Drawing.Point(71, 103);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(284, 23);
            this.cbProduto.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(446, 103);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtCodigo.TabIndex = 4;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(579, 103);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnConfirmaDesativacao
            // 
            this.btnConfirmaDesativacao.BackColor = System.Drawing.Color.Lime;
            this.btnConfirmaDesativacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmaDesativacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmaDesativacao.Location = new System.Drawing.Point(626, 415);
            this.btnConfirmaDesativacao.Name = "btnConfirmaDesativacao";
            this.btnConfirmaDesativacao.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmaDesativacao.TabIndex = 20;
            this.btnConfirmaDesativacao.Text = "Confirma";
            this.btnConfirmaDesativacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfirmaDesativacao.UseVisualStyleBackColor = false;
            this.btnConfirmaDesativacao.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Location = new System.Drawing.Point(707, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(82, 168);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(273, 23);
            this.txtProduto.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Descrição: ";
            // 
            // Desativar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmaDesativacao);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbProduto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Desativar";
            this.Text = "Desativar";            
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private Label label1;
        private Label label2;
        private ComboBox cbProduto;
        private Label label3;
        private TextBox txtCodigo;
        private Button btnPesquisar;
        private Button btnConfirmaDesativacao;
        private Button btnCancelar;
        private TextBox txtProduto;
        private Label label4;
    }
}