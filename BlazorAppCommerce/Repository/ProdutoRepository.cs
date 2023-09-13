using BlazorAppCommerce.Models;
using System.Data;
using Dapper;
using BlazorAppCommerce.Interfaces;

namespace BlazorAppCommerce.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;
        private readonly IDapperService _dapperDao;

        public ProdutoRepository(IDapperService dapperDao)
        {
            this._dapperDao = dapperDao;
        }

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CadastrarProduto(Produto produto)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@nome", produto.Nome);
                dbPara.Add("@valor", produto.Valor);
                dbPara.Add("@estoque", produto.Estoque);

                _dapperDao.InsertAsync<int>("PR_INSERE_PRODUTO", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", id);

                var produto = _dapperDao.GetByIdAsync<Produto>("PR_BUSCA_PRODUTO_BYID", dbPara, commandType: CommandType.StoredProcedure);
                return produto;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            var dbPara = new DynamicParameters();
            var produtos = _dapperDao.GetAllAsync<Produto>("PR_BUSCA_TODOS_PRODUTOS", dbPara, commandType: CommandType.StoredProcedure);
            return produtos.ToList();
        }

        public async Task<int> AtualizarProduto(Produto produto)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", produto.Id);
                dbPara.Add("@nome", produto.Nome);
                dbPara.Add("@valor", produto.Valor);
                dbPara.Add("@estoque", produto.Estoque);

                var result = _dapperDao.UpdateAsync<int>("PR_ATUALIZA_PRODUTO", dbPara, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeletarProduto(int id)
        {
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@id", id);

                _dapperDao.Execute<int>("PR_DELETA_PRODUTO", dbPara, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
