namespace UI.View
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPesquisar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPesquisarProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPesquisarComanda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGerenciarEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPesquisar,
            this.menuEstoque,
            this.menuTerminal,
            this.menuSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuPesquisar
            // 
            this.menuPesquisar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPesquisarProduto,
            this.btnPesquisarComanda});
            this.menuPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("menuPesquisar.Image")));
            this.menuPesquisar.Name = "menuPesquisar";
            this.menuPesquisar.Size = new System.Drawing.Size(108, 44);
            this.menuPesquisar.Text = "Pesquisar";
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(152, 22);
            this.btnPesquisarProduto.Text = "Produto";
            this.btnPesquisarProduto.Click += new System.EventHandler(this.btnPesquisarProduto_Click);
            // 
            // btnPesquisarComanda
            // 
            this.btnPesquisarComanda.Name = "btnPesquisarComanda";
            this.btnPesquisarComanda.Size = new System.Drawing.Size(152, 22);
            this.btnPesquisarComanda.Text = "Comanda";
            this.btnPesquisarComanda.Click += new System.EventHandler(this.btnPesquisarComanda_Click);
            // 
            // menuEstoque
            // 
            this.menuEstoque.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGerenciarEstoque});
            this.menuEstoque.Image = ((System.Drawing.Image)(resources.GetObject("menuEstoque.Image")));
            this.menuEstoque.Name = "menuEstoque";
            this.menuEstoque.Size = new System.Drawing.Size(96, 44);
            this.menuEstoque.Text = "Estoque";
            // 
            // btnGerenciarEstoque
            // 
            this.btnGerenciarEstoque.Name = "btnGerenciarEstoque";
            this.btnGerenciarEstoque.Size = new System.Drawing.Size(152, 22);
            this.btnGerenciarEstoque.Text = "Gerenciar";
            this.btnGerenciarEstoque.Click += new System.EventHandler(this.btnGerenciarEstoque_Click);
            // 
            // menuTerminal
            // 
            this.menuTerminal.Image = ((System.Drawing.Image)(resources.GetObject("menuTerminal.Image")));
            this.menuTerminal.Name = "menuTerminal";
            this.menuTerminal.Size = new System.Drawing.Size(101, 44);
            this.menuTerminal.Text = "Terminal";
            this.menuTerminal.Click += new System.EventHandler(this.menuTerminal_Click);
            // 
            // menuSair
            // 
            this.menuSair.Image = ((System.Drawing.Image)(resources.GetObject("menuSair.Image")));
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(65, 44);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHora});
            this.statusStrip1.Location = new System.Drawing.Point(0, 437);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblHora
            // 
            this.lblHora.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(54, 20);
            this.lblHora.Text = "Hora";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPesquisar;
        private System.Windows.Forms.ToolStripMenuItem btnPesquisarProduto;
        private System.Windows.Forms.ToolStripMenuItem menuTerminal;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.ToolStripMenuItem btnPesquisarComanda;
        private System.Windows.Forms.ToolStripMenuItem menuEstoque;
        private System.Windows.Forms.ToolStripMenuItem btnGerenciarEstoque;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblHora;
        private System.Windows.Forms.Timer timer1;
    }
}