namespace UI.View.UI.ViewProduto
{
    partial class frmCadastrarProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastrarProduto));
            this.ckbEstoque = new System.Windows.Forms.CheckBox();
            this.gpbTipoCadastro = new System.Windows.Forms.GroupBox();
            this.cbbTipoCadastro = new System.Windows.Forms.ComboBox();
            this.gpbEstoque = new System.Windows.Forms.GroupBox();
            this.txtQtdMaxima = new System.Windows.Forms.TextBox();
            this.txtQtdMinima = new System.Windows.Forms.TextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.lblQuantidadeMaxima = new System.Windows.Forms.Label();
            this.lblQuantidadeMinima = new System.Windows.Forms.Label();
            this.lblEstoque = new System.Windows.Forms.Label();
            this.gpbProduto = new System.Windows.Forms.GroupBox();
            this.cbbCategoria = new System.Windows.Forms.ComboBox();
            this.gpbDadosUnidade = new System.Windows.Forms.GroupBox();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.gpbTipoCadastro.SuspendLayout();
            this.gpbEstoque.SuspendLayout();
            this.gpbProduto.SuspendLayout();
            this.gpbDadosUnidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbEstoque
            // 
            this.ckbEstoque.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckbEstoque.Location = new System.Drawing.Point(360, 15);
            this.ckbEstoque.Name = "ckbEstoque";
            this.ckbEstoque.Size = new System.Drawing.Size(311, 66);
            this.ckbEstoque.TabIndex = 18;
            this.ckbEstoque.TabStop = false;
            this.ckbEstoque.Text = "Gerenciar Estoque";
            this.ckbEstoque.UseVisualStyleBackColor = true;
            this.ckbEstoque.CheckedChanged += new System.EventHandler(this.ckbEstoque_CheckedChanged);
            // 
            // gpbTipoCadastro
            // 
            this.gpbTipoCadastro.Controls.Add(this.cbbTipoCadastro);
            this.gpbTipoCadastro.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbTipoCadastro.Location = new System.Drawing.Point(14, 7);
            this.gpbTipoCadastro.Name = "gpbTipoCadastro";
            this.gpbTipoCadastro.Size = new System.Drawing.Size(330, 74);
            this.gpbTipoCadastro.TabIndex = 17;
            this.gpbTipoCadastro.TabStop = false;
            this.gpbTipoCadastro.Text = "Tipo de cadastro do produto";
            // 
            // cbbTipoCadastro
            // 
            this.cbbTipoCadastro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoCadastro.FormattingEnabled = true;
            this.cbbTipoCadastro.Location = new System.Drawing.Point(6, 30);
            this.cbbTipoCadastro.Name = "cbbTipoCadastro";
            this.cbbTipoCadastro.Size = new System.Drawing.Size(318, 31);
            this.cbbTipoCadastro.TabIndex = 0;
            this.cbbTipoCadastro.SelectedIndexChanged += new System.EventHandler(this.cbbTipoCadastro_SelectedIndexChanged);
            // 
            // gpbEstoque
            // 
            this.gpbEstoque.Controls.Add(this.txtQtdMaxima);
            this.gpbEstoque.Controls.Add(this.txtQtdMinima);
            this.gpbEstoque.Controls.Add(this.txtEstoque);
            this.gpbEstoque.Controls.Add(this.lblQuantidadeMaxima);
            this.gpbEstoque.Controls.Add(this.lblQuantidadeMinima);
            this.gpbEstoque.Controls.Add(this.lblEstoque);
            this.gpbEstoque.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbEstoque.Location = new System.Drawing.Point(14, 382);
            this.gpbEstoque.Name = "gpbEstoque";
            this.gpbEstoque.Size = new System.Drawing.Size(657, 86);
            this.gpbEstoque.TabIndex = 15;
            this.gpbEstoque.TabStop = false;
            this.gpbEstoque.Text = "Dados no estoque";
            // 
            // txtQtdMaxima
            // 
            this.txtQtdMaxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdMaxima.Location = new System.Drawing.Point(582, 39);
            this.txtQtdMaxima.MaxLength = 20;
            this.txtQtdMaxima.Name = "txtQtdMaxima";
            this.txtQtdMaxima.Size = new System.Drawing.Size(69, 29);
            this.txtQtdMaxima.TabIndex = 9;
            this.txtQtdMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQtdMinima
            // 
            this.txtQtdMinima.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdMinima.Location = new System.Drawing.Point(338, 39);
            this.txtQtdMinima.MaxLength = 20;
            this.txtQtdMinima.Name = "txtQtdMinima";
            this.txtQtdMinima.Size = new System.Drawing.Size(69, 29);
            this.txtQtdMinima.TabIndex = 8;
            this.txtQtdMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEstoque
            // 
            this.txtEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoque.Location = new System.Drawing.Point(91, 39);
            this.txtEstoque.MaxLength = 20;
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(69, 29);
            this.txtEstoque.TabIndex = 7;
            this.txtEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstoque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstoque_KeyPress);
            // 
            // lblQuantidadeMaxima
            // 
            this.lblQuantidadeMaxima.AutoSize = true;
            this.lblQuantidadeMaxima.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeMaxima.Location = new System.Drawing.Point(435, 42);
            this.lblQuantidadeMaxima.Name = "lblQuantidadeMaxima";
            this.lblQuantidadeMaxima.Size = new System.Drawing.Size(150, 23);
            this.lblQuantidadeMaxima.TabIndex = 2;
            this.lblQuantidadeMaxima.Text = "Quantidade Máxima";
            // 
            // lblQuantidadeMinima
            // 
            this.lblQuantidadeMinima.AutoSize = true;
            this.lblQuantidadeMinima.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeMinima.Location = new System.Drawing.Point(189, 42);
            this.lblQuantidadeMinima.Name = "lblQuantidadeMinima";
            this.lblQuantidadeMinima.Size = new System.Drawing.Size(145, 23);
            this.lblQuantidadeMinima.TabIndex = 2;
            this.lblQuantidadeMinima.Text = "Quantidade Mínima";
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoque.Location = new System.Drawing.Point(10, 42);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(67, 23);
            this.lblEstoque.TabIndex = 2;
            this.lblEstoque.Text = "Estoque";
            // 
            // gpbProduto
            // 
            this.gpbProduto.Controls.Add(this.cbbCategoria);
            this.gpbProduto.Controls.Add(this.gpbDadosUnidade);
            this.gpbProduto.Controls.Add(this.txtDescricao);
            this.gpbProduto.Controls.Add(this.lblDescricao);
            this.gpbProduto.Controls.Add(this.lblCategoria);
            this.gpbProduto.Controls.Add(this.lblNome);
            this.gpbProduto.Controls.Add(this.lblCodigo);
            this.gpbProduto.Controls.Add(this.txtNome);
            this.gpbProduto.Controls.Add(this.txtCodigo);
            this.gpbProduto.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbProduto.Location = new System.Drawing.Point(14, 80);
            this.gpbProduto.Name = "gpbProduto";
            this.gpbProduto.Size = new System.Drawing.Size(657, 302);
            this.gpbProduto.TabIndex = 14;
            this.gpbProduto.TabStop = false;
            this.gpbProduto.Text = "Dados do produto";
            // 
            // cbbCategoria
            // 
            this.cbbCategoria.BackColor = System.Drawing.Color.Yellow;
            this.cbbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategoria.FormattingEnabled = true;
            this.cbbCategoria.Location = new System.Drawing.Point(92, 115);
            this.cbbCategoria.Name = "cbbCategoria";
            this.cbbCategoria.Size = new System.Drawing.Size(559, 31);
            this.cbbCategoria.TabIndex = 0;
            // 
            // gpbDadosUnidade
            // 
            this.gpbDadosUnidade.Controls.Add(this.txtPrecoVenda);
            this.gpbDadosUnidade.Controls.Add(this.lblPrecoVenda);
            this.gpbDadosUnidade.Location = new System.Drawing.Point(346, 178);
            this.gpbDadosUnidade.Name = "gpbDadosUnidade";
            this.gpbDadosUnidade.Size = new System.Drawing.Size(304, 113);
            this.gpbDadosUnidade.TabIndex = 8;
            this.gpbDadosUnidade.TabStop = false;
            this.gpbDadosUnidade.Text = "Dados de Unidade";
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecoVenda.Location = new System.Drawing.Point(146, 48);
            this.txtPrecoVenda.MaxLength = 7;
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(152, 29);
            this.txtPrecoVenda.TabIndex = 6;
            this.txtPrecoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoVenda.Location = new System.Drawing.Point(13, 51);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(124, 23);
            this.lblPrecoVenda.TabIndex = 8;
            this.lblPrecoVenda.Text = "Preço de Venda";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(92, 185);
            this.txtDescricao.MaxLength = 70;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(248, 106);
            this.txtDescricao.TabIndex = 3;
            this.txtDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(9, 185);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(80, 23);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(9, 118);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(77, 23);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(9, 73);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(52, 23);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(9, 33);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 23);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(92, 70);
            this.txtNome.MaxLength = 30;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(559, 29);
            this.txtNome.TabIndex = 2;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(92, 30);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(559, 29);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCadastrar.BackColor = System.Drawing.Color.White;
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(14, 470);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(657, 54);
            this.btnCadastrar.TabIndex = 16;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // frmCadastrarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 531);
            this.Controls.Add(this.ckbEstoque);
            this.Controls.Add(this.gpbTipoCadastro);
            this.Controls.Add(this.gpbEstoque);
            this.Controls.Add(this.gpbProduto);
            this.Controls.Add(this.btnCadastrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadastrarProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes  Produto";
            this.Load += new System.EventHandler(this.frmCadastrarProduto_Load);
            this.gpbTipoCadastro.ResumeLayout(false);
            this.gpbEstoque.ResumeLayout(false);
            this.gpbEstoque.PerformLayout();
            this.gpbProduto.ResumeLayout(false);
            this.gpbProduto.PerformLayout();
            this.gpbDadosUnidade.ResumeLayout(false);
            this.gpbDadosUnidade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbEstoque;
        private System.Windows.Forms.GroupBox gpbTipoCadastro;
        private System.Windows.Forms.GroupBox gpbEstoque;
        private System.Windows.Forms.TextBox txtQtdMaxima;
        private System.Windows.Forms.TextBox txtQtdMinima;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label lblQuantidadeMaxima;
        private System.Windows.Forms.Label lblQuantidadeMinima;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.GroupBox gpbProduto;
        private System.Windows.Forms.GroupBox gpbDadosUnidade;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.ComboBox cbbTipoCadastro;
        private System.Windows.Forms.ComboBox cbbCategoria;
    }
}