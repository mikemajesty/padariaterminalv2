using Controller.Repositorio;
using Mike.Utilities.Desktop;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UI.View.Enum;
using UI.View.UI.ViewProduto;

namespace View.UI.ViewProduto
{
    public partial class frmPesquisarProduto : Form
    {

        private ProdutoRepositorio _produtoRepositorio;
        private EnumTipoPesquisa _enumTipoPesquisa;
        public frmPesquisarProduto(EnumTipoPesquisa enumTipoPesquisa)
        {
            _enumTipoPesquisa = enumTipoPesquisa;
            InitializeComponent();
        }


        private void frmPesquisarProduto_Load(object sender, EventArgs e)
        {

            try
            {

                CarregarGrid();


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

        private void CarregarGrid()
        {

            try
            {
                InstanciarProdutoRepositorio();
                switch (_enumTipoPesquisa)
                {
                    case EnumTipoPesquisa.Produto:
                        _produtoRepositorio.ListarProduto(dgv: dgvProdutos);
                        AjustarTamanhoDoGrid();
                        break;
                    case EnumTipoPesquisa.Estoque:
                        _produtoRepositorio.ListarProdutoPorUnidade(dgv: dgvProdutos);
                        AjustarTamanhoDoGrid();
                        MudarTextoDoForm(texto: "Alterar Estoque");
                        break;
                    case EnumTipoPesquisa.ProdutoTerminal:
                        _produtoRepositorio.ListarProduto(dgv: dgvProdutos);
                        AjustarTamanhoDoGrid();
                        break;
                   
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

        private void MudarTextoDoForm(string texto)
        {
            this.Text = texto;
        }

        private void AjustarTamanhoDoGrid()
        {

            try
            {

                dgvProdutos.AjustartamanhoDoDataGridView(new List<TamanhoGrid> {
                    new TamanhoGrid() { Tamanho = -1, ColunaNome="ID"} ,
                    new TamanhoGrid() { Tamanho = 130, ColunaNome = "Código" },
                    new TamanhoGrid() { Tamanho = 220, ColunaNome = "Nome" },
                    new TamanhoGrid() { Tamanho = 125, ColunaNome="Categoria" },
                    new TamanhoGrid() { Tamanho = 100, ColunaNome="Preço" }  ,
                    new TamanhoGrid() { Tamanho = 100, ColunaNome="Estoque" }});

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

        private void InstanciarProdutoRepositorio()
        {
            _produtoRepositorio = new ProdutoRepositorio();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            try
            {


                MudarTextoDoGroupBox(texto: "Pesquisar pelo Nome do produto");
                this.FocoNoTxt(txt: txtPesquisar);
                LimparTxt(txt: txtPesquisar);
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

        private void MudarTextoDoGroupBox(string texto)
        {
            gpbPesquisar.Text = texto;
        }

        private void LimparTxt(TextBox txt)
        {
            txt.Text = string.Empty;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PesquisarNoBancoPorNome();

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

        private void PesquisarNoBancoPorNome()
        {
            try
            {
                InstanciarProdutoRepositorio();
                if (_produtoRepositorio.GetQuantidade() > 0)
                {
                    int tamanho = txtPesquisar.Text.Length;
                    InstanciarProdutoRepositorio();
                    switch (SelecionarTextoDoRadioButtonSelecionado())
                    {
                        case "Nome":
                            if (_enumTipoPesquisa == EnumTipoPesquisa.Produto)
                            {
                                _produtoRepositorio.SelectProdutoPeloNomeTodos(dgv: dgvProdutos, nome: txtPesquisar.Text);
                            }
                            else
                            {
                                _produtoRepositorio.SelectProdutoPeloNomeEstoque(dgv: dgvProdutos, nome: txtPesquisar.Text);
                            }
                            break;
                        case "Código":
                            if (tamanho == 0)
                            {
                                if (_enumTipoPesquisa == EnumTipoPesquisa.Produto)
                                {
                                    _produtoRepositorio.SelectProdutoPeloCodigoTodos(dgv: dgvProdutos, codigo: txtPesquisar.Text);
                                }
                                else
                                {
                                    _produtoRepositorio.SelectProdutoPeloCodigoEstoque(dgv: dgvProdutos, codigo: txtPesquisar.Text);
                                }

                            }

                            break;
                        case "Categoria":
                            if (_enumTipoPesquisa == EnumTipoPesquisa.Produto)
                            {
                                _produtoRepositorio.SelectProdutoPeloCategoriaTodos(dgv: dgvProdutos, categoria: txtPesquisar.Text);
                            }
                            else
                            {
                                _produtoRepositorio.SelectProdutoPeloCategoriaEstoque(dgv: dgvProdutos, categoria: txtPesquisar.Text);
                            }

                            break;
                    }
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

        private string SelecionarTextoDoRadioButtonSelecionado()
        {
            try
            {

                RadioButton[] rdbList = { rdbCategoria, rdbCodigo, rdbNome };
                string rdbSelecionado = string.Empty;
                foreach (var rdb in rdbList)
                {
                    if (rdb.Checked)
                    {
                        rdbSelecionado = rdb.Text;
                    }
                }
                return rdbSelecionado;

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

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    InstanciarProdutoRepositorio();
                    switch (SelecionarTextoDoRadioButtonSelecionado())
                    {

                        case "Código":
                            if (_enumTipoPesquisa == EnumTipoPesquisa.Produto)
                            {
                                _produtoRepositorio.SelectProdutoPeloCodigoTodos(dgv: dgvProdutos, codigo: txtPesquisar.Text);
                            }
                            else
                            {
                                _produtoRepositorio.SelectProdutoPeloCodigoEstoque(dgv: dgvProdutos, codigo: txtPesquisar.Text);
                            }
                            break;
                    }

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

        private void dgvProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {


                //int contador = 0;
                //foreach (DataGridViewRow row in dgvProdutos.Rows)
                //{
                //    if (Convert.ToInt32(row.Cells["Preço"].Value) <= 0)
                //    {
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.BackColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.ForeColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.SelectionBackColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.SelectionForeColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.BackColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.ForeColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.SelectionBackColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.SelectionForeColor = Color.Yellow;
                //    }
                //    else
                //    {
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.BackColor = Color.White;
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.ForeColor = Color.Black;
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.SelectionBackColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Preço"].Style.SelectionForeColor = Color.Black;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.BackColor = Color.White;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.ForeColor = Color.Black;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.SelectionBackColor = Color.Yellow;
                //        dgvProdutos.Rows[contador].Cells["Estoque"].Style.SelectionForeColor = Color.Black;
                //    }
                //    contador++;
                //}
                (sender as DataGridView).DefaultCellStyle.Format = "C2";

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

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                MudarTextoDoGroupBox(texto: "Pesquisar pelo Código do produto");
                this.FocoNoTxt(txt: txtPesquisar);
                LimparTxt(txt: txtPesquisar);
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

        private void rdbCategoria_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

                MudarTextoDoGroupBox(texto: "Pesquisar pela Categoria do produto");
                this.FocoNoTxt(txt: txtPesquisar);
                LimparTxt(txt: txtPesquisar);
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

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                InstanciarProdutoRepositorio();
                if (_enumTipoPesquisa == EnumTipoPesquisa.Estoque && e.RowIndex >= 0)
                {
                    int idProduto = GetIDDaLinhaDoGrid();
                    Produto produto = _produtoRepositorio.GetProdutoPorID(idProduto);
                    if (OpenMdiForm.OpenForWithShowDialog(new frmCadastrarProduto(produto, null, EnumTipoCadastro.Estoque)) == DialogResult.Yes)
                    {
                        CarregarGrid();
                    }
                }
                else if (_enumTipoPesquisa == EnumTipoPesquisa.ProdutoTerminal && e.RowIndex >= 0)
                {
                    Produto.StaticCodigo = dgvProdutos.CurrentRow.Cells["Código"].Value.ToString();
                    if (Produto.StaticCodigo.Length > 0)
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
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

        public int GetIDDaLinhaDoGrid()
        {
            try
            {


                return Convert.ToInt32(dgvProdutos.CurrentRow.Cells["ID"].Value);

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




    }
}
