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
                     => _comandaRepositorio = new ComandaRepositorio();
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
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
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
                SaveErroInTxt.RecordInTxt(error, this.GetType().Name);
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (dgvComanda.Rows.Count > 0)
                    {
                        var codigo = (string)dgvComanda.GetSelectRow(0, "Código");
                        InstanciarComandaRepositorio();
                        if (_comandaRepositorio.GetQuantidade() > 0)
                        {
                            Comanda.CodigoStatic = "";
                            Comanda.CodigoStatic = codigo;
                            this.DialogResult = Comanda.CodigoStatic != "" ? DialogResult.Yes : DialogResult.No;
                        }
                        else
                            MyErro.MyCustomException("Não existe comanda cadastrada.");
                    }
                    break;
                case Keys.Up:
                    dgvComanda.MoveToUp();
                    break;
                case Keys.Down:
                    dgvComanda.MoveToDown();
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
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
                case Keys.Escape:
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
                     => ValidatorField.IntegerAndLetter(e);
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
                SaveErroInTxt.RecordInTxt(erro, this.GetType().Name);
                DialogMessage.MessageComButtonOkIconeErro(erro.Message, "Erro");
            }

        }

        private void AjustarTamanhoDoGrid()
        {

            try
            {
                dgvComanda.AjustartamanhoDoDataGridView(new List<TamanhoGrid>()
                {
                    new TamanhoGrid(){ ColunaNome = "ID", Tamanho = 173},
                    new TamanhoGrid(){ ColunaNome = "Código" , Tamanho=250}
                });

            }
            catch (CustomException error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }
            catch (Exception error)
            {
                SaveErroInTxt.RecordInTxt(error, this.GetType().Name);
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }


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
                        Comanda.CodigoStatic = dgvComanda.CurrentRow.Cells["Código"].Value.ToString();
                        this.DialogResult = Comanda.CodigoStatic != "" ? DialogResult.Yes : DialogResult.No;
                    }
                    else
                        MyErro.MyCustomException("Não existe comanda cadastrada.");
                }

            }
            catch (CustomException error)
            {
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }
            catch (Exception error)
            {
                SaveErroInTxt.RecordInTxt(error, this.GetType().Name);
                DialogMessage.MessageFullComButtonOkIconeDeInformacao(message: error.Message, title: "Aviso");
            }

        }
    }
}
