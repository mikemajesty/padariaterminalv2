namespace View.UI.ViewTerminal
{
    partial class frmTerminal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerminal));
            this.gpbSelecionarIDDaComanda = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbIdDaComanda = new System.Windows.Forms.PictureBox();
            this.btnModificarComanda = new System.Windows.Forms.Button();
            this.txtIDdaComanda = new System.Windows.Forms.TextBox();
            this.ltvProdutos = new System.Windows.Forms.ListView();
            this.gpbTotal = new System.Windows.Forms.GroupBox();
            this.lblTotalVenda = new System.Windows.Forms.Label();
            this.pnlTudo = new System.Windows.Forms.Panel();
            this.gpbValorPorPeso = new System.Windows.Forms.GroupBox();
            this.lblF1 = new System.Windows.Forms.Label();
            this.ptbValorpagoPorPeso = new System.Windows.Forms.PictureBox();
            this.txtPesoDoProduto = new System.Windows.Forms.TextBox();
            this.ckbPorPeso = new System.Windows.Forms.CheckBox();
            this.gpbCodigoDoProduto = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ptbCodigoDoProduto = new System.Windows.Forms.PictureBox();
            this.txtCodigoDoProduto = new System.Windows.Forms.TextBox();
            this.gpbQuantidadeDoProduto = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ptbQuantidade = new System.Windows.Forms.PictureBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gpbSelecionarIDDaComanda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIdDaComanda)).BeginInit();
            this.gpbTotal.SuspendLayout();
            this.pnlTudo.SuspendLayout();
            this.gpbValorPorPeso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbValorpagoPorPeso)).BeginInit();
            this.gpbCodigoDoProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCodigoDoProduto)).BeginInit();
            this.gpbQuantidadeDoProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbSelecionarIDDaComanda
            // 
            this.gpbSelecionarIDDaComanda.Controls.Add(this.label1);
            this.gpbSelecionarIDDaComanda.Controls.Add(this.ptbIdDaComanda);
            this.gpbSelecionarIDDaComanda.Controls.Add(this.btnModificarComanda);
            this.gpbSelecionarIDDaComanda.Controls.Add(this.txtIDdaComanda);
            this.gpbSelecionarIDDaComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbSelecionarIDDaComanda.Location = new System.Drawing.Point(4, 12);
            this.gpbSelecionarIDDaComanda.Name = "gpbSelecionarIDDaComanda";
            this.gpbSelecionarIDDaComanda.Size = new System.Drawing.Size(427, 89);
            this.gpbSelecionarIDDaComanda.TabIndex = 0;
            this.gpbSelecionarIDDaComanda.TabStop = false;
            this.gpbSelecionarIDDaComanda.Text = "Selecione a comanda pelo ID";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(271, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 38);
            this.label1.TabIndex = 15;
            this.label1.Text = "[F1]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbIdDaComanda
            // 
            this.ptbIdDaComanda.Image = ((System.Drawing.Image)(resources.GetObject("ptbIdDaComanda.Image")));
            this.ptbIdDaComanda.Location = new System.Drawing.Point(3, 34);
            this.ptbIdDaComanda.Name = "ptbIdDaComanda";
            this.ptbIdDaComanda.Size = new System.Drawing.Size(31, 38);
            this.ptbIdDaComanda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbIdDaComanda.TabIndex = 13;
            this.ptbIdDaComanda.TabStop = false;
            // 
            // btnModificarComanda
            // 
            this.btnModificarComanda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarComanda.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarComanda.Image")));
            this.btnModificarComanda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarComanda.Location = new System.Drawing.Point(314, 34);
            this.btnModificarComanda.Name = "btnModificarComanda";
            this.btnModificarComanda.Size = new System.Drawing.Size(111, 38);
            this.btnModificarComanda.TabIndex = 14;
            this.btnModificarComanda.Text = "[F2]";
            this.btnModificarComanda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarComanda.UseVisualStyleBackColor = true;
            this.btnModificarComanda.Click += new System.EventHandler(this.btnModificarComanda_Click);
            // 
            // txtIDdaComanda
            // 
            this.txtIDdaComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDdaComanda.Location = new System.Drawing.Point(38, 34);
            this.txtIDdaComanda.MaxLength = 3;
            this.txtIDdaComanda.Name = "txtIDdaComanda";
            this.txtIDdaComanda.Size = new System.Drawing.Size(231, 38);
            this.txtIDdaComanda.TabIndex = 0;
            this.txtIDdaComanda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIDdaComanda.DoubleClick += new System.EventHandler(this.txtIDdaComanda_DoubleClick);
            this.txtIDdaComanda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDdaComanda_KeyPress);
            // 
            // ltvProdutos
            // 
            this.ltvProdutos.BackColor = System.Drawing.Color.White;
            this.ltvProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltvProdutos.FullRowSelect = true;
            this.ltvProdutos.GridLines = true;
            this.ltvProdutos.Location = new System.Drawing.Point(437, 20);
            this.ltvProdutos.MultiSelect = false;
            this.ltvProdutos.Name = "ltvProdutos";
            this.ltvProdutos.Size = new System.Drawing.Size(418, 252);
            this.ltvProdutos.TabIndex = 9;
            this.ltvProdutos.TabStop = false;
            this.ltvProdutos.UseCompatibleStateImageBehavior = false;
            this.ltvProdutos.View = System.Windows.Forms.View.Details;
            this.ltvProdutos.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ltvProdutos_ColumnWidthChanging);
            this.ltvProdutos.DoubleClick += new System.EventHandler(this.ltvProdutos_DoubleClick);
            // 
            // gpbTotal
            // 
            this.gpbTotal.BackColor = System.Drawing.Color.White;
            this.gpbTotal.Controls.Add(this.lblTotalVenda);
            this.gpbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbTotal.Location = new System.Drawing.Point(1, 278);
            this.gpbTotal.Name = "gpbTotal";
            this.gpbTotal.Size = new System.Drawing.Size(854, 96);
            this.gpbTotal.TabIndex = 18;
            this.gpbTotal.TabStop = false;
            this.gpbTotal.Text = "Total na Comanda";
            // 
            // lblTotalVenda
            // 
            this.lblTotalVenda.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTotalVenda.Location = new System.Drawing.Point(6, 22);
            this.lblTotalVenda.Name = "lblTotalVenda";
            this.lblTotalVenda.Size = new System.Drawing.Size(842, 61);
            this.lblTotalVenda.TabIndex = 1;
            this.lblTotalVenda.Text = "00 R$";
            this.lblTotalVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTudo
            // 
            this.pnlTudo.Controls.Add(this.gpbValorPorPeso);
            this.pnlTudo.Controls.Add(this.ckbPorPeso);
            this.pnlTudo.Controls.Add(this.gpbCodigoDoProduto);
            this.pnlTudo.Controls.Add(this.gpbQuantidadeDoProduto);
            this.pnlTudo.Location = new System.Drawing.Point(1, 107);
            this.pnlTudo.Name = "pnlTudo";
            this.pnlTudo.Size = new System.Drawing.Size(430, 165);
            this.pnlTudo.TabIndex = 14;
            // 
            // gpbValorPorPeso
            // 
            this.gpbValorPorPeso.Controls.Add(this.lblF1);
            this.gpbValorPorPeso.Controls.Add(this.ptbValorpagoPorPeso);
            this.gpbValorPorPeso.Controls.Add(this.txtPesoDoProduto);
            this.gpbValorPorPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbValorPorPeso.Location = new System.Drawing.Point(147, 3);
            this.gpbValorPorPeso.Name = "gpbValorPorPeso";
            this.gpbValorPorPeso.Size = new System.Drawing.Size(280, 78);
            this.gpbValorPorPeso.TabIndex = 20;
            this.gpbValorPorPeso.TabStop = false;
            this.gpbValorPorPeso.Text = "Peso do produto";
            // 
            // lblF1
            // 
            this.lblF1.Location = new System.Drawing.Point(240, 34);
            this.lblF1.Name = "lblF1";
            this.lblF1.Size = new System.Drawing.Size(37, 38);
            this.lblF1.TabIndex = 15;
            this.lblF1.Text = "[F4]";
            this.lblF1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbValorpagoPorPeso
            // 
            this.ptbValorpagoPorPeso.Image = ((System.Drawing.Image)(resources.GetObject("ptbValorpagoPorPeso.Image")));
            this.ptbValorpagoPorPeso.Location = new System.Drawing.Point(209, 34);
            this.ptbValorpagoPorPeso.Name = "ptbValorpagoPorPeso";
            this.ptbValorpagoPorPeso.Size = new System.Drawing.Size(31, 38);
            this.ptbValorpagoPorPeso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbValorpagoPorPeso.TabIndex = 14;
            this.ptbValorpagoPorPeso.TabStop = false;
            // 
            // txtPesoDoProduto
            // 
            this.txtPesoDoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoDoProduto.Location = new System.Drawing.Point(6, 34);
            this.txtPesoDoProduto.MaxLength = 6;
            this.txtPesoDoProduto.Name = "txtPesoDoProduto";
            this.txtPesoDoProduto.Size = new System.Drawing.Size(201, 38);
            this.txtPesoDoProduto.TabIndex = 3;
            this.txtPesoDoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPesoDoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDoProdutoPorpeso_KeyPress);
            // 
            // ckbPorPeso
            // 
            this.ckbPorPeso.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbPorPeso.BackColor = System.Drawing.Color.LightGray;
            this.ckbPorPeso.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.ckbPorPeso.Image = ((System.Drawing.Image)(resources.GetObject("ckbPorPeso.Image")));
            this.ckbPorPeso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbPorPeso.Location = new System.Drawing.Point(6, 7);
            this.ckbPorPeso.Name = "ckbPorPeso";
            this.ckbPorPeso.Size = new System.Drawing.Size(135, 74);
            this.ckbPorPeso.TabIndex = 22;
            this.ckbPorPeso.TabStop = false;
            this.ckbPorPeso.Text = "Peso [F3]";
            this.ckbPorPeso.UseVisualStyleBackColor = false;
            this.ckbPorPeso.CheckedChanged += new System.EventHandler(this.ckbPorPeso_CheckedChanged);
            // 
            // gpbCodigoDoProduto
            // 
            this.gpbCodigoDoProduto.Controls.Add(this.label3);
            this.gpbCodigoDoProduto.Controls.Add(this.ptbCodigoDoProduto);
            this.gpbCodigoDoProduto.Controls.Add(this.txtCodigoDoProduto);
            this.gpbCodigoDoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbCodigoDoProduto.Location = new System.Drawing.Point(147, 81);
            this.gpbCodigoDoProduto.Name = "gpbCodigoDoProduto";
            this.gpbCodigoDoProduto.Size = new System.Drawing.Size(280, 78);
            this.gpbCodigoDoProduto.TabIndex = 21;
            this.gpbCodigoDoProduto.TabStop = false;
            this.gpbCodigoDoProduto.Text = "Código do produto";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(240, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 38);
            this.label3.TabIndex = 15;
            this.label3.Text = "[F6]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbCodigoDoProduto
            // 
            this.ptbCodigoDoProduto.Image = ((System.Drawing.Image)(resources.GetObject("ptbCodigoDoProduto.Image")));
            this.ptbCodigoDoProduto.Location = new System.Drawing.Point(6, 34);
            this.ptbCodigoDoProduto.Name = "ptbCodigoDoProduto";
            this.ptbCodigoDoProduto.Size = new System.Drawing.Size(31, 38);
            this.ptbCodigoDoProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCodigoDoProduto.TabIndex = 13;
            this.ptbCodigoDoProduto.TabStop = false;
            // 
            // txtCodigoDoProduto
            // 
            this.txtCodigoDoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoDoProduto.Location = new System.Drawing.Point(40, 34);
            this.txtCodigoDoProduto.MaxLength = 20;
            this.txtCodigoDoProduto.Name = "txtCodigoDoProduto";
            this.txtCodigoDoProduto.Size = new System.Drawing.Size(200, 38);
            this.txtCodigoDoProduto.TabIndex = 3;
            this.txtCodigoDoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoDoProduto.TextChanged += new System.EventHandler(this.txtCodigoDoProduto_TextChanged);
            this.txtCodigoDoProduto.DoubleClick += new System.EventHandler(this.txtCodigoDoProduto_DoubleClick);
            this.txtCodigoDoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoDoProduto_KeyPress);
            // 
            // gpbQuantidadeDoProduto
            // 
            this.gpbQuantidadeDoProduto.Controls.Add(this.label2);
            this.gpbQuantidadeDoProduto.Controls.Add(this.ptbQuantidade);
            this.gpbQuantidadeDoProduto.Controls.Add(this.txtQuantidade);
            this.gpbQuantidadeDoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbQuantidadeDoProduto.Location = new System.Drawing.Point(5, 81);
            this.gpbQuantidadeDoProduto.Name = "gpbQuantidadeDoProduto";
            this.gpbQuantidadeDoProduto.Size = new System.Drawing.Size(136, 78);
            this.gpbQuantidadeDoProduto.TabIndex = 19;
            this.gpbQuantidadeDoProduto.TabStop = false;
            this.gpbQuantidadeDoProduto.Text = "Quantidade";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(97, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 38);
            this.label2.TabIndex = 15;
            this.label2.Text = "[F5]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptbQuantidade
            // 
            this.ptbQuantidade.Image = ((System.Drawing.Image)(resources.GetObject("ptbQuantidade.Image")));
            this.ptbQuantidade.Location = new System.Drawing.Point(6, 34);
            this.ptbQuantidade.Name = "ptbQuantidade";
            this.ptbQuantidade.Size = new System.Drawing.Size(31, 38);
            this.ptbQuantidade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbQuantidade.TabIndex = 13;
            this.ptbQuantidade.TabStop = false;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(41, 34);
            this.txtQuantidade.MaxLength = 3;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(55, 38);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(867, 386);
            this.Controls.Add(this.pnlTudo);
            this.Controls.Add(this.gpbTotal);
            this.Controls.Add(this.ltvProdutos);
            this.Controls.Add(this.gpbSelecionarIDDaComanda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTerminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmTerminal_Load);
            this.gpbSelecionarIDDaComanda.ResumeLayout(false);
            this.gpbSelecionarIDDaComanda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIdDaComanda)).EndInit();
            this.gpbTotal.ResumeLayout(false);
            this.pnlTudo.ResumeLayout(false);
            this.gpbValorPorPeso.ResumeLayout(false);
            this.gpbValorPorPeso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbValorpagoPorPeso)).EndInit();
            this.gpbCodigoDoProduto.ResumeLayout(false);
            this.gpbCodigoDoProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCodigoDoProduto)).EndInit();
            this.gpbQuantidadeDoProduto.ResumeLayout(false);
            this.gpbQuantidadeDoProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQuantidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSelecionarIDDaComanda;
        private System.Windows.Forms.TextBox txtIDdaComanda;
        private System.Windows.Forms.ListView ltvProdutos;
        private System.Windows.Forms.PictureBox ptbIdDaComanda;
        private System.Windows.Forms.GroupBox gpbTotal;
        private System.Windows.Forms.Label lblTotalVenda;
        private System.Windows.Forms.Panel pnlTudo;
        private System.Windows.Forms.GroupBox gpbValorPorPeso;
        private System.Windows.Forms.TextBox txtPesoDoProduto;
        private System.Windows.Forms.CheckBox ckbPorPeso;
        private System.Windows.Forms.GroupBox gpbCodigoDoProduto;
        private System.Windows.Forms.PictureBox ptbCodigoDoProduto;
        private System.Windows.Forms.TextBox txtCodigoDoProduto;
        private System.Windows.Forms.GroupBox gpbQuantidadeDoProduto;
        private System.Windows.Forms.PictureBox ptbQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ptbValorpagoPorPeso;
        private System.Windows.Forms.Label lblF1;
        private System.Windows.Forms.Button btnModificarComanda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}