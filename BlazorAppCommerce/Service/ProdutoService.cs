using BlazorAppCommerce.Interfaces;
using BlazorAppCommerce.Models;

namespace BlazorAppCommerce.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IDapperService _dapperDao;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IDapperService dapperDao, IProdutoRepository produtoRepository)
        {
            _dapperDao = dapperDao;
            _produtoRepository = produtoRepository;
        }

        public async Task CadastrarProduto(Produto produto)
        {
            try
            {
                await _produtoRepository.CadastrarProduto(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletarProduto(int id)
        {
            try
            {
                await _produtoRepository.DeletarProduto(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            try
            {
                return await _produtoRepository.GetProdutoById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            try
            {
                return await _produtoRepository.BuscarTodosProdutos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AtualizarProduto(Produto produto)
        {
            try
            {
                return await _produtoRepository.AtualizarProduto(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}
