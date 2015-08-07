using Mike.Utilities.Desktop;
using Model.Data;
using Model.Entidades;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Controller.Repositorio
{
    public class ProdutoRepositorio
    {
        private _DbContext _banco;
        private TipoCadastroRepositorio _tipoCadastroRepositorio;
        public int GetQuantidade()
        {
            try
            {
                InstanciarDbContext();
                return _banco.Produto.Count();

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

        private void InstanciarDbContext()
        {
            _banco = new _DbContext();
        }
        public int Alterar(Produto produto)
        {
            try
            {
                InstanciarDbContext();                
                _banco.Entry(produto).State = EntityState.Modified;
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

        public void SelectProdutoPeloNomeTodos(DataGridView dgv, string nome)
        {
            try
            {
                InstanciarDbContext();
                dgv.DataSource = (from prod in _banco.Produto
                                  join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                  select new
                                  {
                                      ID = prod.ID,
                                      Código = prod.Codigo,
                                      Nome = prod.Nome,
                                      Categoria = cat.Nome,
                                      Preço = prod.PrecoVenda,
                                      Estoque = prod.GerenciarEstoque
                                  }).Where(c => c.Nome.Contains(nome)).ToList();

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

        public void SelectProdutoPeloCodigoTodos(DataGridView dgv, string codigo)
        {

            try
            {
                InstanciarDbContext();
                dgv.DataSource = ((from prod in _banco.Produto
                                   join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                   select new
                                   {
                                       ID = prod.ID,
                                       Codigo = prod.Codigo,
                                       Nome = prod.Nome,
                                       Categoria = cat.Nome,
                                       Preço = prod.PrecoVenda,
                                       Estoque = prod.GerenciarEstoque
                                   }).Where(c => c.Codigo == codigo).OrderBy(c => c.Nome).ToList());

                if (dgv.Rows.Count == 0)
                {
                    dgv.DataSource = ((from prod in _banco.Produto
                                       join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                       select new
                                       {
                                           ID = prod.ID,
                                           Código = prod.Codigo,
                                           Nome = prod.Nome,
                                           Categoria = cat.Nome,
                                           Preço = prod.PrecoVenda,
                                           Estoque = prod.GerenciarEstoque
                                       }).OrderBy(c => c.Nome).ToList());
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

        public void SelectProdutoPeloCategoriaTodos(DataGridView dgv, string categoria)
        {
            try
            {
                InstanciarDbContext();
                dgv.DataSource = (from prod in _banco.Produto
                                  join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                  select new
                                  {
                                      ID = prod.ID,
                                      Código = prod.Codigo,
                                      Nome = prod.Nome,
                                      Categoria = cat.Nome,
                                      Preço = prod.PrecoVenda,
                                      Estoque = prod.GerenciarEstoque
                                  }).Where(c => c.Categoria.Contains(categoria)).ToList();

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

        public void ListarProduto(DataGridView dgv)
        {
            try
            {
                InstanciarDbContext();
                dgv.DataSource = (from prod in _banco.Produto
                                  join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                  select new
                                  {
                                      ID = prod.ID,
                                      Código = prod.Codigo,
                                      Nome = prod.Nome,
                                      Categoria = cat.Nome,
                                      Preço = prod.PrecoVenda,
                                      Estoque = prod.GerenciarEstoque
                                  }).OrderBy(c => c.Nome).ToList();
                dgv.EsconderColuna("ID");
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

        public Produto AdicionarProdutoParaVendaPorPeso(ListView ltv, string codigo, decimal peso)
        {
            try
            {
                InstanciarTipoCadastroRepositorio();
                int IDTipoPeso = _tipoCadastroRepositorio.GetIDPeloNome("Peso");
                Produto produto = this.GetProdutoPorCodigoPorPeso(codigo);

                if (produto != null)
                {
                    IQueryable<dynamic> _venda = null;

                    if (produto.TipoCadastro == IDTipoPeso)
                    {
                        _venda = (from prod in _banco.Produto
                                  select new
                                  {
                                      Nome = prod.Nome
                                      ,
                                      Codigo = prod.Codigo
                                      ,
                                      Quantidade = "Peso"
                                      ,
                                      Total = (prod.PrecoVenda / 1000) * peso
                                      ,
                                      LucroTotal = ((((prod.PrecoVenda / 1000) * peso ) * 100) / prod.Porcentagem)
                                  }).Where(c => c.Codigo == codigo);

                        AdicionarItensNoListView(ltv, _venda);

                    }
                    return produto;
                }
                else
                {
                    throw new CustomException("Produto com esse código não esta cadastrado.");
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
        public Produto GetProdutoPorCodigoPorPeso(string codigo)
        {
            try
            {
                InstanciarDbContext();
                InstanciarTipoCadastroRepositorio();

                if (_banco.Produto.FirstOrDefault(c => c.Codigo == codigo) != null)
                {
                    int ID = _tipoCadastroRepositorio.GetIDPeloNome("Peso");
                    Produto prod = _banco.Produto.FirstOrDefault(c => c.Codigo == codigo && c.TipoCadastro == ID);
                    if (prod != null)
                    {
                        return prod;
                    }
                    else
                    {
                        throw new CustomException("Esse Produto é vendido por unidade.");
                    }
                }
                else
                {
                    throw new CustomException("Produto com esse código não esta cadastrado.");
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



        private Produto GetProdutoPorCodigoUnidade(string codigo)
        {
            try
            {
                InstanciarDbContext();
                InstanciarTipoCadastroRepositorio();
                if (_banco.Produto.FirstOrDefault(c => c.Codigo == codigo) != null)
                {
                    int ID = _tipoCadastroRepositorio.GetIDPeloNome("Unidade");
                    Produto prod = _banco.Produto.FirstOrDefault(c => c.Codigo == codigo && c.TipoCadastro == ID);
                    return prod;

                }
                else
                {
                    throw new CustomException("Produto com esse código não esta cadastrado.");
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

        private void AdicionarItensNoListView(ListView ltv, IQueryable<dynamic> _venda)
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
                    ltv.Columns.Add("LucroTotal").Width = 50;

                }

                foreach (var item in _venda)
                {
                    listView = new ListViewItem(item.Nome);
                    listView.SubItems.Add(item.Codigo);
                    object itemQtd = item.Quantidade;
                    if (itemQtd.ToString().Contains("Peso"))
                    {
                        listView.SubItems.Add("Peso");
                    }
                    else
                    {
                        listView.SubItems.Add("" + item.Quantidade);
                    }
                    listView.SubItems.Add(item.Total.ToString("N2"));
                    listView.SubItems.Add(item.LucroTotal.ToString("N2"));
                    ltv.Items.Add(listView);
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

        private void InstanciarTipoCadastroRepositorio()
        {
            _tipoCadastroRepositorio = new TipoCadastroRepositorio();
        }



        public Produto AdicionarProdutoNoListViewSemComanda(ListView ltv, string codigo, int quantidade)
        {
            try
            {
                InstanciarTipoCadastroRepositorio();
                int IDTipoUnidade = _tipoCadastroRepositorio.GetIDPeloNome("Unidade");

                Produto produto = this.GetProdutoPorCodigoUnidade(codigo);

                IQueryable<dynamic> _venda = null;

                if (produto != null)
                {
                    if (produto.TipoCadastro == IDTipoUnidade)
                    {
                        _venda = (from prod in _banco.Produto
                                  select new
                                  {
                                      Nome = prod.Nome
                                      ,
                                      Codigo = prod.Codigo
                                      ,
                                      Quantidade = quantidade
                                      ,
                                      Total = prod.PrecoVenda * quantidade
                                      ,
                                      LucroTotal = ((prod.PrecoVenda - prod.PrecoCompra) * quantidade)
                                  }).Where(c => c.Codigo == codigo);

                        AdicionarItensNoListView(ltv, _venda);

                    }
                }
                else
                {
                    MyErro.MyCustomException("Esse Produto é vendido por peso.");
                }

                return produto;
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

        public Produto GetProdutoPorCodigo(string codigo)
        {
            try
            {
                InstanciarDbContext();
                Produto prod = _banco.Produto.FirstOrDefault(c => c.Codigo == codigo);
                if (prod != null)
                {
                    return prod;
                }
                else
                {
                    throw new CustomException("Produto com esse código não esta cadastrado.");
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

        public Produto GetProdutoPorID(int idProduto)
        {
            try
            {
                InstanciarDbContext();
                Produto prod = _banco.Produto.FirstOrDefault(c => c.ID == idProduto);
                if (prod != null)
                {
                    return prod;
                }
                else
                {
                    throw new CustomException("Produto não esta cadastrado.");
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

        public void ListarProdutoPorUnidade(DataGridView dgv)
        {

            try
            {

                InstanciarDbContext();
                InstanciarTipoCadastroRepositorio();
                int IDTipoCadastro = _tipoCadastroRepositorio.GetIDPeloNome("Unidade");
                dgv.DataSource = (from prod in _banco.Produto
                                  join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                  where prod.TipoCadastro == IDTipoCadastro
                                  select new
                                  {
                                      ID = prod.ID,
                                      Código = prod.Codigo,
                                      Nome = prod.Nome,
                                      Categoria = cat.Nome,
                                      Preço = prod.PrecoVenda,
                                      Estoque = prod.GerenciarEstoque
                                  }).OrderBy(c => c.Nome).ToList();
                dgv.EsconderColuna("ID");

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

        public void SelectProdutoPeloNomeEstoque(DataGridView dgv, string nome)
        {
            try
            {
                InstanciarDbContext();
                InstanciarTipoCadastroRepositorio();
                int IDTipoCadastro = _tipoCadastroRepositorio.GetIDPeloNome("Unidade");
                dgv.DataSource = (from prod in _banco.Produto
                                  join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                  where prod.TipoCadastro == IDTipoCadastro && prod.Nome.Contains(nome)
                                  select new
                                  {
                                      ID = prod.ID,
                                      Código = prod.Codigo,
                                      Nome = prod.Nome,
                                      Categoria = cat.Nome,
                                      Preço = prod.PrecoVenda,
                                      Estoque = prod.GerenciarEstoque
                                  }).OrderBy(c => c.Nome).ToList();
                dgv.EsconderColuna("ID");


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
        public void SelectProdutoPeloCategoriaEstoque(DataGridView dgv, string categoria)
        {
            try
            {
                InstanciarDbContext();
                InstanciarTipoCadastroRepositorio();
                int IDTipoCadastro = _tipoCadastroRepositorio.GetIDPeloNome("Unidade");
                dgv.DataSource = (from prod in _banco.Produto
                                  join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                  where prod.TipoCadastro == IDTipoCadastro && cat.Nome.Contains(categoria)
                                  select new
                                  {
                                      ID = prod.ID,
                                      Código = prod.Codigo,
                                      Nome = prod.Nome,
                                      Categoria = cat.Nome,
                                      Preço = prod.PrecoVenda,
                                      Estoque = prod.GerenciarEstoque
                                  }).OrderBy(c => c.Nome).ToList();
                dgv.EsconderColuna("ID");


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
        public void SelectProdutoPeloCodigoEstoque(DataGridView dgv, string codigo)
        {

            try
            {
                InstanciarDbContext();
                InstanciarTipoCadastroRepositorio();
                int IDTipoCadastro = _tipoCadastroRepositorio.GetIDPeloNome("Unidade");
                dgv.DataSource = ((from prod in _banco.Produto
                                   join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                   where prod.TipoCadastro == IDTipoCadastro
                                   select new
                                   {
                                       ID = prod.ID,
                                       Codigo = prod.Codigo,
                                       Nome = prod.Nome,
                                       Categoria = cat.Nome,
                                       Preço = prod.PrecoVenda,
                                       Estoque = prod.GerenciarEstoque
                                   }).Where(c => c.Codigo == codigo).OrderBy(c => c.Nome).ToList());

                if (dgv.Rows.Count == 0)
                {
                    dgv.DataSource = ((from prod in _banco.Produto
                                       join cat in _banco.Categoria on prod.Categoria equals cat.ID
                                       where prod.TipoCadastro == IDTipoCadastro
                                       select new
                                       {
                                           ID = prod.ID,
                                           Código = prod.Codigo,
                                           Nome = prod.Nome,
                                           Categoria = cat.Nome,
                                           Preço = prod.PrecoVenda,
                                           Estoque = prod.GerenciarEstoque
                                       }).OrderBy(c => c.Nome).ToList());
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
    }
}
