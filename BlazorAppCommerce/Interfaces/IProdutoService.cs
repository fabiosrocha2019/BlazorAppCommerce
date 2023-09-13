using BlazorAppCommerce.Models;

namespace BlazorAppCommerce.Interfaces
{
    public interface IProdutoService
    {
        Task CadastrarProduto(Produto produto);
        Task<int> AtualizarProduto(Produto produto);

        Task<Produto> GetProdutoById(int id);
        Task<List<Produto>> BuscarTodosProdutos();
        Task DeletarProduto(int id);
    }
}
