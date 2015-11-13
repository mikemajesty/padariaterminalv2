using Controller.Repositorio;
using Mike.Utilities.Desktop;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.View.UI.ViewComanda
{
    public partial class frmPesquisarComanda : Form
    {
        private ComandaRepositorio _comandaRepositorio;
        private const string Vazio = "";
        public frmPesquisarComanda()
        {
            InitializeComponent();
        }
        private void InstanciarComandaRepositorio()
        {
            _comandaRepositorio = new ComandaRepositorio();
        }
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

            try
            {
                PesquisarECarregar();
               
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

        private void PesquisarECarregar()
        {

            try
            {
                string codigo = txtPesquisar.Text.Trim();
                InstanciarComandaRepositorio();
                _comandaRepositorio.
                    PesquisarPorCodigoPesquisar(dgv: dgvComanda, codigoComanda: codigo);
                AjustarTamanhoDoGrid();
                dgvComanda.PadronizarGrid();
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

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorField.IntegerAndLetter(e);

        }

        private void frmPesquisarComanda_Load(object sender, EventArgs e)
        {

            try
            {
                PesquisarECarregar();

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

        private void AjustarTamanhoDoGrid()
        {

            dgvComanda.AjustartamanhoDoDataGridView(new List<TamanhoGrid>()
                {
                    new TamanhoGrid(){ ColunaNome = "ID", Tamanho = 173},
                    new TamanhoGrid(){ ColunaNome = "Código" , Tamanho=250}
                });

        }

        private void dgvComanda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                InstanciarComandaRepositorio();
                if (e.RowIndex >= 0)
                {
                    if (_comandaRepositorio.GetQuantidade() > 0)
                    {
                        Comanda.StaticID = Convert.ToInt32(dgvComanda.CurrentRow.Cells["ID"].Value);
                        if (Comanda.StaticID > 0)
                        {
                            this.DialogResult = DialogResult.Yes;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.No;
                        }
                    }
                    else
                    {
                        MyErro.MyCustomException("Não existe comanda cadastrada.");
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
    }
}
