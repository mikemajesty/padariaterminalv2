using Controller.Repositorio;
using Mike.Utilities.Desktop;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.View.Enum;
using UI.View.UI.ViewProduto;

namespace View.UI.ViewTerminal
{
    public partial class frmTerminal : Form
    {

        private VendaComComandaAtivaRepositorio _vendaComComandaATivaRepositorio;
        private ComandaRepositorio _comandaRepositorio;
        private ProdutoRepositorio _produtoRepositorio;
        private const bool Existe = true;
        public frmTerminal()
        {
            InitializeComponent();
        }
        private void InstanciarComandaRepositorio()
        {
            _comandaRepositorio = new ComandaRepositorio();
        }
        private void InstanciarVendaComComandaAtivaRepositorio()
        {
            _vendaComComandaATivaRepositorio = new VendaComComandaAtivaRepositorio();
        }
        private void frmTerminal_Load(object sender, EventArgs e)
        {
            EsconderPanel(pnlTudo);
            CarregarTextBoxQuantidadeComUM();
            EsconderGroupBox(gpbValorPorPeso);
        }

        private void EsconderGroupBox(GroupBox gpb)
        {
            gpb.Visible = false;
        }
        private void MostrarGroupBox(GroupBox gpb)
        {
            gpb.Visible = true;
        }


        private void CarregarTextBoxQuantidadeComUM()
        {
            txtQuantidade.Text = "1";
        }

        private void EsconderPanel(Panel pnl)
        {
            pnl.Visible = false;
        }

        private void txtIDdaComanda_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorField.Integer(e);
            try
            {

                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    InstanciarComandaRepositorio();
                    InstanciarVendaComComandaAtivaRepositorio();
                    if (txtIDdaComanda.Text.Length > 0)
                    {

                        if (_comandaRepositorio.SeExiste(new Comanda() { ID = Convert.ToInt32(txtIDdaComanda.Text) }) == Existe)
                        {
                            MostrarPanel(pnlTudo);
                            DesabilitarTextBox(new List<TextBox>() { txtIDdaComanda });
                            FocarNoTxt(txtQuantidade);
                            CarregarComanda();
                            CarregarTxtQuantidadeComUm();
                        }
                        else
                        {
                            MyErro.MyCustomException("Comanda não cadastrada.");
                        }

                    }
                }


            }
            catch (CustomException erro)
            {
                FocarNoTxt(txtIDdaComanda);
                LimparTxt(new List<TextBox>() { txtIDdaComanda });
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");

            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private void CarregarComanda()
        {

            try
            {
                int ID = Convert.ToInt32(txtIDdaComanda.Text);
                _vendaComComandaATivaRepositorio.GetItensnaComandaPorID(ID, ltvProdutos);
                MyListView.GetValorNaComanda(ltvProdutos, 3, lblTotalVenda);

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

        private void DesabilitarTextBox(List<TextBox> list)
        {
            foreach (var txt in list)
            {
                txt.Enabled = false;
            }
        }

        private void DesbilitarGroupBox(List<GroupBox> list)
        {
            foreach (var gpb in list)
            {
                gpb.Enabled = false;
            }
        }

        private void LimparTxt(List<TextBox> list)
        {
            foreach (var txt in list)
            {
                txt.LimparTxt();
            }
        }

        private void FocarNoTxt(TextBox txtIDdaComanda)
        {
            this.FocoNoTxt(txtIDdaComanda);
        }

        private void MostrarPanel(Panel pnl)
        {
            pnl.Visible = true;
        }

        private void ltvProdutos_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            MyListView.ColumnWidthChanging(e, ltvProdutos);
        }


        private void ckbPorPeso_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                MostrarGroupBox(gpbValorPorPeso);
                FocarNoTxt(txtPesoDoProduto);
                LimparTxt(new List<TextBox>() { txtCodigoDoProduto });
                EsconderGroupBox(gpbQuantidadeDoProduto);
            }
            else
            {
                EsconderGroupBox(gpbValorPorPeso);
                FocarNoTxt(txtCodigoDoProduto);
                LimparTxt(new List<TextBox>() { txtPesoDoProduto });
                MostrarGroupBox(gpbQuantidadeDoProduto);
            }
        }
        private void txtValorDoProdutoPorpeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorField.Peso(e: e, sender: sender);
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (gpbQuantidadeDoProduto.Visible == true)
                {
                    FocarNoTxt(txtQuantidade);
                }
                else
                {
                    FocarNoTxt(txtCodigoDoProduto);
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorField.Integer(e);
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                FocarNoTxt(txtCodigoDoProduto);
            }
        }

        private void txtCodigoDoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                ValidatorField.IntegerAndLetter(e);
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (ckbPorPeso.Checked)
                    {

                        decimal peso = 0;
                        if (txtPesoDoProduto.Text.Contains("0,"))
                        {
                            string temp = txtPesoDoProduto.Text.Substring(2, txtPesoDoProduto.Text.Length - 2);
                            peso = txtPesoDoProduto.Text == "" ? 0 : Convert.ToDecimal(temp);
                        }
                        else
                        {
                            peso = txtPesoDoProduto.Text == "" ? 0 : Convert.ToDecimal(txtPesoDoProduto.Text.Replace(",", ""));
                        }
                        if (peso > 0)
                        {
                            InstanciarProdutoRepositorio();
                            Produto produto = _produtoRepositorio.AdicionarProdutoParaVendaPorPeso(ltvProdutos, txtCodigoDoProduto.Text, peso);
                            if (produto != null)
                            {
                                InstanciarVendaComComandaAtivaRepositorio();
                                _vendaComComandaATivaRepositorio.Cadastrar(PupularVendaComComandaAtivaPeso(produto, peso));
                                MyListView.GetValorNaComanda(ltvProdutos, 3, lblTotalVenda);
                                DesmarcarCheckBox();
                                LimparTxt(new List<TextBox>() { txtCodigoDoProduto, txtPesoDoProduto });
                                PosSalvamento();
                                CarregarTxtQuantidadeComUm();
                                timer1.Start();
                                DialogMessage.MessageFullComButtonOkIconeDeInformacao("Produto inserido com sucesso.", "Aviso");
                            }

                        }
                        else
                        {
                            MyErro.MyCustomException("Digite o valor do item vendido.");
                            FocarNoTxt(txtPesoDoProduto);
                        }
                    }
                    else
                    {

                        InstanciarProdutoRepositorio();
                        InstanciarVendaComComandaAtivaRepositorio();
                        Produto produto = _produtoRepositorio.AdicionarProdutoNoListViewSemComanda(ltv: ltvProdutos, codigo: txtCodigoDoProduto.Text, quantidade: Convert.ToInt32(txtQuantidade.Text));
                        if (produto != null)
                        {
                            _vendaComComandaATivaRepositorio.Cadastrar(new VendaComComandaAtiva()
                            {
                                IDComanda = Convert.ToInt32(txtIDdaComanda.Text),
                                IDProduto = produto.ID,
                                PrecoTotal = produto.PrecoVenda * Convert.ToInt32(txtQuantidade.Text),
                                Quantidade = Convert.ToInt32(txtQuantidade.Text)
                            });
                            LimparTxt(new List<TextBox>() { txtCodigoDoProduto });

                            DesmarcarCheckBox();
                            LimparTxt(new List<TextBox>() { txtPesoDoProduto });
                            MyListView.GetValorNaComanda(ltvProdutos, 3, lblTotalVenda);
                            PosSalvamento();
                            CarregarTxtQuantidadeComUm();
                            timer1.Start();
                            DialogMessage.MessageFullComButtonOkIconeDeInformacao("Produto inserido com sucesso.", "Aviso");
                        }


                    }



                }
            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
                FocarNoTxt(txtCodigoDoProduto);
                LimparTxt(new List<TextBox>() { txtCodigoDoProduto });

            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private VendaComComandaAtiva PupularVendaComComandaAtivaPeso(Produto produto, decimal peso)
        {


            try
            {
                VendaComComandaAtiva venda = new VendaComComandaAtiva();
                venda.IDComanda = Convert.ToInt32(txtIDdaComanda.Text);
                venda.IDProduto = produto.ID;
                venda.PrecoTotal = (produto.PrecoVenda / 1000) * peso;
                venda.Quantidade = 0;
                return venda;

            }
            catch (CustomException erro)
            {
                throw new CustomException(erro.Message);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }



        }

        private void DesmarcarCheckBox()
        {
            ckbPorPeso.Checked = false;
        }

        private void InstanciarProdutoRepositorio()
        {
            _produtoRepositorio = new ProdutoRepositorio();
        }


        private void btnModificarComanda_Click(object sender, EventArgs e)
        {

            try
            {

                PosSalvamento();

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

        private void PosSalvamento()
        {
            try
            {
                LimparTxt(new List<TextBox>() { txtIDdaComanda });
                HabilitarTxt(txtIDdaComanda);
                FocarNoTxt(txtIDdaComanda);
                LimparListView();
                EsconderPanel(pnlTudo);
                LimparTxt(new List<TextBox>() { txtPesoDoProduto, txtIDdaComanda });
                CarregarComZeroLabelTotalVenda();

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

        private void CarregarComZeroLabelTotalVenda()
        {
            lblTotalVenda.Text = "00 R$";
        }

        private void LimparListView()
        {
            ltvProdutos.Clear();
        }

        private void HabilitarTxt(TextBox txt)
        {
            txt.Enabled = true;
        }

        private void ltvProdutos_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    InstanciarProdutoRepositorio();
                    Produto produto = _produtoRepositorio.GetProdutoPorCodigo(MyListView.RetornarValorPeloIndexDaColuna(ltvProdutos, 1));
                    string recebido = (MyListView.RetornarValorPeloIndexDaColuna(ltvProdutos, 2));
                    int quantidade = 0;
                    if (!recebido.Contains("Peso"))
                    {
                        quantidade = Convert.ToInt32(MyListView.RetornarValorPeloIndexDaColuna(ltvProdutos, 2));
                    }

                    if (OpenMdiForm.OpenForWithShowDialog(new frmCadastrarProduto(produto, new DeletarDaComandaAtiva() { Quantidade = quantidade, ComandaID = Convert.ToInt32(txtIDdaComanda.Text), ProdutoID = produto.ID }, EnumTipoCadastro.Comanda)) == DialogResult.Yes)
                    {


                        LimparListView();
                        CarregarComanda();
                        FocarNoTxt(txtCodigoDoProduto);
                        CarregarTxtQuantidadeComUm();
                    }




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
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private void CarregarTxtQuantidadeComUm()
        {
            txtQuantidade.Text = "1";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                SendKeys.Send("{ENTER}");

                timer1.Stop();


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
