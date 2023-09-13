using BlazorAppCommerce.Models;

namespace BlazorAppCommerce.Interfaces
{
    public interface IProdutoRepository
    {
        Task CadastrarProduto(Produto produto);
        Task<Produto> GetProdutoById(int id);
        Task<List<Produto>> BuscarTodosProdutos();
        Task<int> AtualizarProduto(Produto produto);
        Task DeletarProduto(int id);
    }
}
