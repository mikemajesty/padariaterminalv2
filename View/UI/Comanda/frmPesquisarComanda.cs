using Controller.Repositorio;
using Mike.Utilities.Desktop;
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

                InstanciarComandaRepositorio();
                if (_comandaRepositorio.GetQuantidade() > 0)
                {
                    string codigo = txtPesquisar.Text == Vazio ? "" : txtPesquisar.Text;
                    _comandaRepositorio.PesquisarPorCodigo(dgv: dgvComanda, codigoComanda: codigo);
                    AjustarTamanhoDoGrid();
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

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorField.IntegerAndLetter(e);

        }

        private void frmPesquisarComanda_Load(object sender, EventArgs e)
        {

            try
            {

                InstanciarComandaRepositorio();
                _comandaRepositorio.PesquisarPorCodigo(dgv: dgvComanda, codigoComanda: "");
                AjustarTamanhoDoGrid();

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


    }
}
