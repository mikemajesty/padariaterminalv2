using Mike.Utilities.Desktop;
using Model.Data;
using Model.Entidades;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Controller.Repositorio
{
    public class VendaComComandaAtivaRepositorio
    {
        private _DbContext _banco;
        private void InstanciaBanco()
        {
            _banco = new _DbContext();
        }
        public void GetItensnaComandaPorID(int ID, ListView ltv)
        {

            try
            {

                InstanciaBanco();
                IQueryable<dynamic> _venda = (from venda in _banco.VendaComComandaAtiva
                                              join comanda in _banco.Comanda on venda.IDComanda equals
                                                  comanda.ID
                                              join prod in _banco.Produto on venda.IDProduto equals prod.ID
                                              where comanda.ID == ID
                                              select new
                                              {
                                                  Nome = prod.Nome,
                                                  Codigo = prod.Codigo,
                                                  Quantidade = venda.Quantidade,
                                                  Total = venda.PrecoTotal,
                                                  LucroTotal =
                                                  venda.Quantidade == 0 ?
                                                  ((venda.PrecoTotal * 100) / prod.Porcentagem) :
                                                  ((prod.PrecoVenda - prod.PrecoCompra) * venda.Quantidade)
                                              });

                AdicionarItensNoListView(ltv, _venda);


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
        private static void AdicionarItensNoListView(ListView ltv, IQueryable<dynamic> _venda)
        {

            try
            {

                ListViewItem listView;


                if (ltv.Columns.Count == 0)
                {
                    ltv.Columns.Add("Nome").Width = 160;
                    ltv.Columns.Add("Codigo").Width = 106;
                    ltv.Columns.Add("Quantidade").Width = 76;
                    ltv.Columns.Add("Total").Width = 70;
                    ltv.Columns.Add("LucroTotal").Width = 0;

                }

                foreach (var item in _venda)
                {
                    listView = new ListViewItem(item.Nome);
                    listView.SubItems.Add(item.Codigo);
                    if (item.Quantidade == 0)
                    {
                        listView.SubItems.Add("Peso");
                    }
                    else
                    {
                        listView.SubItems.Add("" + item.Quantidade);
                    }
                    listView.SubItems.Add("" + item.Total);
                    listView.SubItems.Add("" + item.LucroTotal);
                    ltv.Items.Add(listView);
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

        public int Cadastrar(VendaComComandaAtiva vendaComandaAtiva)
        {
            try
            {
                InstanciaBanco();
                _banco.Entry(vendaComandaAtiva).State = EntityState.Added;
                return _banco.SaveChanges();

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

        public int DeletarProdutoDaComanda(int IDComanda, int quantidade, int IDProduto)
        {
            try
            {
                InstanciaBanco();
                int retorno = 0;
                Produto produto;
                if ((produto = _banco.Produto.FirstOrDefault(c => c.ID == IDProduto)) != null)
                {
                    
                    VendaComComandaAtiva venda = _banco.VendaComComandaAtiva.FirstOrDefault(c => c.IDComanda == IDComanda && c.Quantidade == quantidade && c.IDProduto == produto.ID);
                    if (venda != null)
                    {
                        _banco.Entry(venda).State = EntityState.Deleted;
                        retorno = _banco.SaveChanges();
                    }
                 
                }
                return retorno;

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
