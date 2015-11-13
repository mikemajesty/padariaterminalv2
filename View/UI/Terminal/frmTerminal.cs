using Controller.Repositorio;
using Mike.Utilities.Desktop;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.View;
using UI.View.Enum;
using UI.View.UI.ViewComanda;
using UI.View.UI.ViewProduto;
using View.UI.ViewProduto;

namespace View.UI.ViewTerminal
{
    public partial class frmTerminal : Form
    {

        private VendaComComandaAtivaRepositorio _vendaComComandaATivaRepositorio;
        private ComandaRepositorio _comandaRepositorio;
        private ProdutoRepositorio _produtoRepositorio;
        private frmMensagemDeEspera frmMensagem;
        private Espere espere;
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


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {


                case Keys.F1:
                    FocarNoTxt(txtIDdaComanda);
                    break;
                case Keys.F2:
                    btnModificarComanda.PerformClick();
                    break;
                case Keys.F3:
                    MarcarDesmarcarCkb();
                    break;
                case Keys.F4:
                    if (ckbPorPeso.Checked == false)
                    {
                        ckbPorPeso.Checked = true;
                    }
                    FocarNoTxt(txtPesoDoProduto);
                    break;
                case Keys.F5:
                    if (ckbPorPeso.Checked == true)
                    {
                        ckbPorPeso.Checked = false;
                    }
                    FocarNoTxt(txtQuantidade);
                    break;
                case Keys.F6:
                    FocarNoTxt(txtCodigoDoProduto);
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;
                case Keys.F13:
                    break;
                case Keys.F14:
                    break;
                case Keys.F15:
                    break;
                case Keys.F16:
                    break;
                case Keys.F17:
                    break;
                case Keys.F18:
                    break;
                case Keys.F19:
                    break;
                case Keys.F20:
                    break;
                case Keys.F21:
                    break;
                case Keys.F22:
                    break;
                case Keys.F23:
                    break;
                case Keys.F24:
                    break;


            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MarcarDesmarcarCkb()
        {
            if (ckbPorPeso.Visible == true)
            {
                ckbPorPeso.Checked = ckbPorPeso.Checked == true
                      && ckbPorPeso.Visible == true ? false : true;
            }

        }


        private void txtIDdaComanda_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorField.Integer(e);
            try
            {

                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    CarregarFormComanda();
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

        private void CarregarFormComanda()
        {
            try
            {

                if (txtIDdaComanda.Text.Trim().Length == 0)
                {
                    if (OpenMdiForm.OpenForWithShowDialog(new frmPesquisarComanda()) == DialogResult.Yes)
                    {
                        espere = new Espere();
                        espere.Start(MostrarMensagem);
                        if (Comanda.StaticID > 0)
                        {
                            txtIDdaComanda.Text = Comanda.StaticID.ToString();
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
                            }
                        }
                    
                    }
                }
                else
                {
                    espere = new Espere();
                    espere.Start(MostrarMensagem);
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
                    }
                
                }
            }
            catch (CustomException error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }
            catch (Exception error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }
            finally
            {
                
                if (espere != null)
                {
                    espere.CancelarTask();
                    if (espere.Cancel.IsCancellationRequested)
                    {
                        if (frmMensagem != null)
                        {
                            frmMensagem.Close();
                        }
                    }
                }
               
            }
        }

        private void MostrarMensagem()
        {
            frmMensagem = new frmMensagemDeEspera();
            frmMensagem.ShowDialog();
        }

        private void CarregarComanda()
        {

            try
            {
                int ID = Convert.ToInt32(txtIDdaComanda.Text);
                _vendaComComandaATivaRepositorio.GetItensnaComandaPorID(ID, ltvProdutos);
                MyListView.GetValorNoListView(ltvProdutos, 3, lblTotalVenda);

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
                    => list.ForEach(c => c.Enabled = false);

        private void DesbilitarGroupBox(List<GroupBox> list)
                    => list.ForEach(c => c.Enabled = false);



        private void LimparTxt(List<TextBox> list)
                    => list.ForEach(c => c.Text = string.Empty);



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
            ValidatorField.Money(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                FocarNoTxt(txtCodigoDoProduto);
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
                    if (txtCodigoDoProduto.Text.Trim().Length == 0)
                    {
                        if (OpenMdiForm.OpenForWithShowDialog(new frmPesquisarProduto(EnumTipoPesquisa.ProdutoTerminal)) == DialogResult.Yes)
                        {
                            CarregarProduto(codigo: Produto.StaticCodigo);
                        }
                    }
                    else
                    {
                        CarregarProduto(codigo: txtCodigoDoProduto.Text.Trim());

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

        private void CarregarProduto(string codigo)
        {

            try
            {
                if (ckbPorPeso.Checked)
                {
                    decimal peso = 0;
                    string pesoDigitado = txtPesoDoProduto.Text.Trim();
                    peso = pesoDigitado == "" ? 0 : Convert.ToDecimal(pesoDigitado.Replace(",", ""));
                    if (peso > 0)
                    {
                        InstanciarProdutoRepositorio();
                        if (_produtoRepositorio.VerificarSeProdutoVendidoPorPeso(codigo: codigo) == true)
                        {
                            Produto produto = _produtoRepositorio.AdicionarProdutoParaVendaPorPeso(ltvProdutos, codigo, peso);
                            if (produto != null)
                            {
                                InstanciarVendaComComandaAtivaRepositorio();
                                _vendaComComandaATivaRepositorio.Cadastrar(PupularVendaComComandaAtivaPeso(produto, peso));
                                MyListView.GetValorNoListView(ltvProdutos, 3, lblTotalVenda);
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
                            DesmarcarCheckBox();
                            FocarNoTxt(txtCodigoDoProduto);
                            txtCodigoDoProduto.Text = codigo;
                            SendKeys.SendWait("{Enter}");
                            LimparTxt(new List<TextBox> { txtCodigoDoProduto });
                        }

                    }
                    else
                    {
                        MyErro.MyCustomException("Digite o peso do item vendido.");
                        FocarNoTxt(txtPesoDoProduto);
                    }
                }
                else
                {

                    InstanciarProdutoRepositorio();
                    InstanciarVendaComComandaAtivaRepositorio();
                    Produto produto = _produtoRepositorio.AdicionarProdutoNoListViewSemComanda(ltv: ltvProdutos, codigo: codigo, quantidade: Convert.ToInt32(txtQuantidade.Text));
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
                        MyListView.GetValorNoListView(ltvProdutos, 3, lblTotalVenda);
                        PosSalvamento();
                        CarregarTxtQuantidadeComUm();
                        timer1.Start();
                        DialogMessage.MessageFullComButtonOkIconeDeInformacao("Produto inserido com sucesso.", "Aviso");
                    }


                }
            }
            catch (CustomException error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }
            catch (Exception error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }

        }

        private VendaComComandaAtiva PupularVendaComComandaAtivaPeso(Produto produto, decimal peso)
        {


            try
            {
                int pesoTemp = Convert.ToInt32(peso);
                VendaComComandaAtiva venda = new VendaComComandaAtiva();
                venda.IDComanda = Convert.ToInt32(txtIDdaComanda.Text);
                venda.IDProduto = produto.ID;
                venda.PrecoTotal = (produto.PrecoVenda / 1000) * peso;
                venda.Quantidade = -pesoTemp;
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
                    if (recebido.Contains("Kg"))
                    {
                        string recebidoTemp = MyListView.RetornarValorPeloIndexDaColuna(ltvProdutos, 2).Replace(" Kg", "");
                        quantidade = -Convert.ToInt32(recebidoTemp.Replace(",", ""));
                    }
                    else
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

        private void txtIDdaComanda_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                CarregarFormComanda();
            }
            catch (CustomException error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }
            catch (Exception error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }

        }

        private void txtCodigoDoProduto_TextChanged(object sender, EventArgs e)
        {
            if (txtPesoDoProduto.Text.Trim().Length > 0)
            {
                if (txtPesoDoProduto.Text.Trim().EndsWith(","))
                {
                    txtPesoDoProduto.Text = txtPesoDoProduto.Text.Remove(txtPesoDoProduto.Text.Length - 1, 1);
                }
            }
        }

        private void txtCodigoDoProduto_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (OpenMdiForm.OpenForWithShowDialog(new frmPesquisarProduto(EnumTipoPesquisa.ProdutoTerminal)) == DialogResult.Yes)
                {
                    CarregarProduto(codigo: Produto.StaticCodigo);
                }
            }
            catch (CustomException error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }
            catch (Exception error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }

        }
    }
}
