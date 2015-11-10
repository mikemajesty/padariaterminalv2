using Mike.Utilities.Desktop;
using Model.Data;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controller.Repositorio
{
    public class ComandaRepositorio
    {
        private _DbContext _banco;
        private const bool Existe = true, NaoExiste = false;
        private void InstanciarBanco()
        {

            _banco = new _DbContext();
        }
        public List<Comanda> Inserir(List<Comanda> comandList, Comanda comanda)
        {
            try
            {
                InstanciarBanco();

                Comanda com = new Comanda();
                if ((com = _banco.Comanda.FirstOrDefault(c => c.ID == comanda.ID)) != null)
                {
                    if (!comandList.Any(c => c.ID == com.ID))
                    {
                        comandList.Add(com);
                    }
                    else
                    {
                        MyErro.MyCustomException("Comanda já foi adicionada");
                    }
                }

                return comandList;

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

        public void PesquisarPorCodigoPesquisar(DataGridView dgv, string codigoComanda)
        {

            try
            {
                InstanciarBanco();
                dgv.DataSource = (from com in _banco.Comanda where com.Codigo.Contains(codigoComanda) select new { ID = com.ID, Código = com.Codigo }).ToList();

            }
            catch (CustomException error)
            {
                throw new CustomException(error.Message);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }

        public bool SeExiste(Comanda comanda)
        {
            try
            {
                InstanciarBanco();
                return _banco.Comanda.FirstOrDefault(c => c.ID == comanda.ID) != null ? Existe : NaoExiste;

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
        public int GetQuantidade()
        {

            try
            {
                InstanciarBanco();
                return _banco.Comanda.Count();

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

        /*public void PesquisarPorCodigoSelecionar(DataGridView dgv, string codigoComanda)
        {
            try
            {
                InstanciarBanco();
                dgv.DataSource = _banco.Comanda.ToList(); (from ven in _banco.VendaComComandaAtiva
                                  join com in _banco.Comanda
                                  on ven.IDComanda equals com.ID
                                  select new
                                  {
                                      ID = com.ID,
                                      Código = com.Codigo,
                                      Valor = ven.PrecoTotal
                                  }).ToList();

            }
            catch (CustomException erro)
            {
                throw new CustomException(erro.Message);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }*/
    }
}
