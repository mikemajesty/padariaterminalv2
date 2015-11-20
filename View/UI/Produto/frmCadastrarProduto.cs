using Controller.Repositorio;
using Mike.Utilities.Desktop;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UI.View.Enum;

namespace UI.View.UI.ViewProduto
{
    public partial class frmCadastrarProduto : Form
    {

        private Produto _produto;
        private CategoriaRepositotio _categoriaRepositorio;
        private TipoCadastroRepositorio _tipoCadastroRepositorio;
        private VendaComComandaAtivaRepositorio _vendaComComandaAtivaRepositorio;
        private DeletarDaComandaAtiva _deleteDaComanda;
        private EnumTipoCadastro _enumTipoCadastro;
        private ProdutoRepositorio _produtoRepositorio;
        public frmCadastrarProduto(Produto produto, DeletarDaComandaAtiva deleteDaComanda, EnumTipoCadastro enumTipoCadastro)
        {
            _produto = produto;
            _deleteDaComanda = deleteDaComanda;
            _enumTipoCadastro = enumTipoCadastro;
            InitializeComponent();
        }
        private void InstanciarProdutoRepositorio()
                     => _produtoRepositorio = new ProdutoRepositorio();
        private void InstanciarVendaComComandaAtivaRepositorio()
                     => _vendaComComandaAtivaRepositorio = new VendaComComandaAtivaRepositorio();
        private void InstanciarTipoCadastroRepositorio()
                     => _tipoCadastroRepositorio = new TipoCadastroRepositorio();
        private void frmCadastrarProduto_Load(object sender, EventArgs e)
        {

            try
            {


                if (_enumTipoCadastro == EnumTipoCadastro.Comanda)
                {
                    CarregarTipoDeCadastro();
                    CarregarCategoria();
                    PopulaTxt();
                    MudarCorDoBotao(Color.LightCoral);
                    MudarTextoDoForm("Deletar Produto");
                    MudarTextoDoBotao("Deletar da Comanda");
                    DesabilitarCampos();
                    DesabilitarGroupBoxDeTipoDeCadastro();
                    DesabilitarCheckBox();
                    FocarNoBotao(btn: btnCadastrar);
                }
                else if (_enumTipoCadastro == EnumTipoCadastro.Estoque)
                {
                    CarregarTipoDeCadastro();
                    CarregarCategoria();
                    PopulaTxt();
                    MudarTextoDoForm("Alterar Estoque");
                    MudarTextoDoBotao("Alterar");
                    DesabilitarGroupBox(gpbTipoCadastro);
                    DesabilitarGroupBox(gpbProduto);
                    DesabilitarGroupBox(gpbDadosUnidade);
                    DesabilitarTextBox(new List<TextBox> { txtQtdMaxima, txtQtdMinima });
                    MudarCorDoBotao(Color.LightGreen);
                    DesabilitarCheckBox();
                    FocarNoTxt(txtEstoque);
                }


            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private void FocarNoBotao(Button btn) => this.FocoNoBotao(btn);


        private void DesabilitarTextBox(List<TextBox> txtList)
                     => txtList.ForEach(c => c.Enabled = false);
        private void CarregarTipoDeCadastro()
        {
            try
            {
                InstanciarTipoCadastroRepositorio();
                _tipoCadastroRepositorio.Cadastrar();
                _tipoCadastroRepositorio.Listar(cbbTipoCadastro);



            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }
        }

        private void CarregarCategoria()
        {

            try
            {
                InstanciarCategoriaRepositorio();
                _categoriaRepositorio.CarregaCategoria(cbbCategoria);


            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private void InstanciarCategoriaRepositorio()
                     => _categoriaRepositorio = new CategoriaRepositotio();

        private void DesabilitarCheckBox() => ckbEstoque.Enabled = false;

        private void DesabilitarGroupBox(GroupBox gpb)
        {
            switch (cbbTipoCadastro.Text)
            {
                case "Unidade":
                    gpb.Enabled = false;
                    break;
                case "Peso":
                    gpb.Enabled = true;
                    break;

            }
        }

        private void DesabilitarGroupBoxDeTipoDeCadastro()
                     => gpbTipoCadastro.Enabled = false;



        private void DesabilitarCampos()
        {
            foreach (Control gpb in this.Controls)
            {
                if (gpb is GroupBox)
                {
                    gpb.Enabled = false;
                }
            }
        }

        private void MudarTextoDoBotao(string text)
                     => btnCadastrar.Text = text;

        private void MudarTextoDoForm(string text)
                     => this.Text = text;
        private void MudarCorDoBotao(Color color)
                     => btnCadastrar.BackColor = color;
        private void PopulaTxt()
        {
            try
            {
                cbbTipoCadastro.Text = CarregarComboBoxDeAcordoComTipoDeCadastro();

                switch (cbbTipoCadastro.Text)
                {
                    case "Unidade":
                        PopulartxtPadrao();
                        PopulatxtUnidade();
                        break;
                    case "Peso":
                        PopulartxtPadrao();
                        break;

                }


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

        private string CarregarComboBoxDeAcordoComTipoDeCadastro()
        {
            try
            {
                InstanciarTipoCadastroRepositorio();
                return _tipoCadastroRepositorio.GetNomePeloID(_produto.TipoCadastro);
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

        private void PopulatxtUnidade()
        {
            try
            {
                txtEstoque.Text = _produto.Quantidade.ToString();
                txtEstoque.Text = _produto.Quantidade.ToString();
                txtQtdMaxima.Text = _produto.QuantidadeMaxima.ToString();
                txtQtdMinima.Text = _produto.QuantidadeMinima.ToString();
                ckbEstoque.Checked = _produto.GerenciarEstoque;

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private void PopulartxtPadrao()
        {

            try
            {
                InstanciarCategoriaRepositorio();
                cbbCategoria.Text = _categoriaRepositorio.GetCategoriaNomePeloID(_produto.Categoria);
                txtNome.Text = _produto.Nome;
                txtCodigo.Text = _produto.Codigo;
                txtDescricao.Text = _produto.Descricao;
                txtPrecoVenda.Text = _produto.PrecoVenda.ToString();

                if (_produto.GerenciarEstoque == false)
                {
                    EsconderGruopBox(gpbEstoque);
                }
                ckbEstoque.Checked = _produto.GerenciarEstoque;


            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private void EsconderGruopBox(GroupBox gpb)
                     => gpb.Visible = false;
        private void cbbTipoCadastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FocarNoTxt(txt: txtCodigo);
                switch (cbbTipoCadastro.Text)
                {
                    case "Unidade":

                        MudarTamanhoDotxtDescricao(new Size(248, 106));
                        AparecerGruopBox(gpbEstoque);
                        AparecerGruopBox(gpbDadosUnidade);
                        LimparTodosOsTxt();
                        DeixarTxtComoObrigatorio(ListaTxtUnidade());
                        MudarPosicaoDoGroupBoxTipoCadastro(new Point(12, 4));
                        MostrarCheck();
                        ComboBoxCheckado();
                        if (ckbEstoque.Checked)
                        {
                            MudarTamanhoDoform(new Size(701, 572));
                            MudarPosicaoDoBotao(new Point(12, 471));
                        }
                        else
                        {
                            MudarTamanhoDoform(new Size(701, 485));
                            MudarPosicaoDoBotao(new Point(12, 385));
                        }
                        break;
                    case "Peso":
                        MudarTamanhoDoform(new Size(701, 485));
                        EsconderGruopBox(gpbEstoque);
                        MudarPosicaoDoBotao(new Point(12, 385));
                        DeixarTxtComoObrigatorio(ListaTxtPeso());
                        DefinirMaxLenghtDoTxtEstoque(tamanho: 3);
                        EsconderCheckBox();
                        MudarPosicaoDoGroupBoxTipoCadastro(new Point(174, 4));
                        break;
                }

            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }
        }
        private TextBox[] ListaTxtPeso()      
                         => new TextBox[] { txtCodigo,
                                            txtNome,
                                            txtDescricao };
      
        private void EsconderCheckBox()
                     => ckbEstoque.Visible = false;
        private void DefinirMaxLenghtDoTxtEstoque(int tamanho)
                     =>txtEstoque.MaxLength = tamanho;
        private void ComboBoxCheckado()
        {
            if (ckbEstoque.Checked == false)
            {
                EsconderGruopBox(gpbEstoque);
            }
        }

        private void LimparCheckBox()
                     => ckbEstoque.Checked = false;
        private void MostrarCheck()
                     => ckbEstoque.Visible = true;
        private void MudarPosicaoDoGroupBoxTipoCadastro(Point point)
                     => gpbTipoCadastro.Location = point;
        private void DeixarTxtComoObrigatorio(TextBox[] txtList)
                     => Array.ForEach(txtList, c => c.BackColor = Color.Yellow);
        private TextBox[] ListaTxtUnidade()
                => new TextBox[] { txtCodigo,
                                   txtNome,
                                   txtPrecoVenda,
                                   txtQtdMaxima,
                                   txtQtdMinima,
                                   txtEstoque };
        private void LimparTodosOsTxt()
                     => Array.ForEach(TodosOsTxt(), c => c.Text = string.Empty);
        private TextBox[] TodosOsTxt()
                          => new TextBox[] { txtCodigo,
                                             txtDescricao,
                                             txtEstoque,
                                             txtNome,
                                             txtPrecoVenda,
                                             txtQtdMaxima,
                                             txtQtdMinima };
           
        private void AparecerGruopBox(GroupBox gpb)
                     => gpb.Visible = true;
        private void MudarTamanhoDotxtDescricao(Size size)
                     => txtDescricao.Size = size;
        private void MudarPosicaoDoBotao(Point point)
                     => btnCadastrar.Location = point;
        private void MudarTamanhoDoform(Size size)
                     => this.Size = size;
        private void FocarNoTxt(TextBox txt)
                     => this.FocoNoTxt(txt);
        private void ckbEstoque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckbEstoque.Checked)
                {
                    AparecerGruopBox(gpbEstoque);
                    FocarNoTxt(txt: txtCodigo);
                    MudarTamanhoDoform(new Size(701, 572));
                    MudarPosicaoDoBotao(new Point(12, 471));
                }
                else if (ckbEstoque.Checked == false)
                {
                    EsconderGruopBox(gpbEstoque);
                    FocarNoTxt(txt: txtCodigo);
                    MudarTamanhoDoform(new Size(701, 485));
                    MudarPosicaoDoBotao(new Point(12, 385));
                }
            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            try
            {
                if (_enumTipoCadastro == EnumTipoCadastro.Comanda)
                {
                    if (DialogMessage.MessageFullQuestion("Deseja remover esse produto da Comanda?", "Aviso") == DialogResult.Yes)
                    {
                        InstanciarVendaComComandaAtivaRepositorio();
                        if (_vendaComComandaAtivaRepositorio.DeletarProdutoDaComanda(_deleteDaComanda.ComandaID, _deleteDaComanda.Quantidade, _deleteDaComanda.ProdutoID) > 0)
                        {
                            this.DialogResult = DialogResult.Yes;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.No;
                        }
                    }
                }
                else if (_enumTipoCadastro == EnumTipoCadastro.Estoque)
                {
                    if (ckbEstoque.Checked == true)
                    {
                        InstanciarProdutoRepositorio();
                        if (_produtoRepositorio.GetProdutoPorID(_produto.ID).Quantidade > Convert.ToInt32(txtEstoque.Text.Trim() == "" ? "0" : txtEstoque.Text.Trim()))
                        {
                            DialogMessage.MessageFullComButtonOkIconeDeInformacao("Estoque só pode ser retirado pelo Administrador", "Aviso");
                            txtEstoque.Text = _produto.Quantidade.ToString();
                            FocarNoTxt(txtEstoque);
                        }
                        else
                        {
                            int operacao = _produtoRepositorio.Alterar(new Produto()
                            {
                                Categoria = _produto.Categoria,
                                Codigo = _produto.Codigo,
                                Descricao = _produto.Descricao,
                                GerenciarEstoque = _produto.GerenciarEstoque,
                                ID = _produto.ID,
                                Nome = _produto.Nome,
                                Porcentagem = _produto.Porcentagem,
                                PrecoCompra = _produto.PrecoCompra,
                                PrecoVenda = _produto.PrecoVenda,
                                PrecoVendaPeso = _produto.PrecoVendaPeso,
                                Quantidade = Convert.ToInt32(txtEstoque.Text),
                                QuantidadeMaxima = _produto.QuantidadeMinima,
                                QuantidadeMinima = _produto.QuantidadeMinima,
                                TipoCadastro = _produto.TipoCadastro
                            });
                            if (operacao > 0)
                            {
                                DialogMessage.MessageFullComButtonOkIconeDeInformacao("Estoque Alterado com Sucesso", "Aviso");
                                this.DialogResult = DialogResult.Yes;
                            }
                        }
                    }
                    else
                    {
                        MyErro.MyCustomException("Esse produto não é gerenciado pelo estoque.");
                    }
                }
            }
            catch (CustomException erro)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(erro.Message, "Aviso");
            }
            catch (Exception erro)
            {
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }
        }
        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
                     => ValidatorField.Integer(e);

    }
}
