using Mike.Utilities.Desktop;
using Model.Data;
using Model.Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Controller.Repositorio
{
    public class CategoriaRepositotio
    {
        private readonly _DbContext _banco;
        private const int Sucesso = 1, Insucesso = 0;
        private const bool NaoExiste = false;
        public CategoriaRepositotio()
        {
            _banco = new _DbContext();
        }
        public int GetIdDaCategoriaPeloNome(string nome)
        {
            try
            {
                Categoria categoria = _banco.Categoria.FirstOrDefault(c => c.Nome == nome);
                return categoria != null ? categoria.ID : 0;
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

        public string GetCategoriaNomePeloID(int CategoriID)
        {
            try
            {
                Categoria categoria = _banco.Categoria.Find(CategoriID);
                return categoria.Nome;
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

        public void CarregaCategoria(ComboBox cbb)
        {
            try
            {
                cbb.DisplayMember = "Nome";
                cbb.DataSource = _banco.Categoria.ToList();

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
