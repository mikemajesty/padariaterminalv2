using Controller.Repositorio;
using Mike.Utilities.Desktop;
using System;
using System.Windows.Forms;
using UI.View.Enum;
using UI.View.UI.ViewComanda;
using View.UI.ViewProduto;
using View.UI.ViewTerminal;

namespace UI.View
{
    public partial class Menu : Form
    {
        private TipoCadastroRepositorio _tipoCadastroRepositorio;
        public Menu()
        {
            InitializeComponent();
        }
        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {

            try
            {

                foreach (Form item in Application.OpenForms)
                {
                    if (item.IsMdiChild && item is frmPesquisarProduto)
                    {
                        item.Close();
                        break;
                    }
                }
                OpenMdiForm.LoadNewKeepAnother(this, new frmPesquisarProduto(EnumTipoPesquisa.Produto));

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }



        }
        private void CarregarTipoDeCadastro()
        {
            try
            {
                InstanciarTipoCadastroRepositorio();
                _tipoCadastroRepositorio.Cadastrar();

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }
        }

        private void InstanciarTipoCadastroRepositorio()
        {
            _tipoCadastroRepositorio = new TipoCadastroRepositorio();
        }
        private void menuTerminal_Click(object sender, EventArgs e)
        {

            try
            {

                OpenMdiForm.LoadNewKeepAnother(this, new frmTerminal());

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }


        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void Sair()
        {
            if (DialogMessage.MessageFullQuestion("Deseja realmente sair?", "Aviso") == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPesquisarComanda_Click(object sender, EventArgs e)
        {

            try
            {

                OpenMdiForm.LoadNewKeepAnother(this, new frmPesquisarComanda());

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }


        }

        private void btnGerenciarEstoque_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.IsMdiChild && item is frmPesquisarProduto)
                    {
                        item.Close();
                        break;
                    }
                }
                OpenMdiForm.LoadNewKeepAnother(this, new frmPesquisarProduto(EnumTipoPesquisa.Estoque));

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }


        }

        private void Menu_Load(object sender, EventArgs e)
        {

            try
            {

                CarregarTipoDeCadastro();

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {

                lblHora.Text = DateTime.Now.ToDataCerta();

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }
    }
}
