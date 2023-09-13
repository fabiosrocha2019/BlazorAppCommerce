using BlazorAppCommerce.Models;

namespace BlazorAppCommerce.Interfaces
{
    public interface IProdutoValidacoes
    {
        bool ValidaIdSolicitacao(int id);
        bool ValidaRegistroExistente(int id);
        bool ValidaCamposProduto(Produto produto);
    }
}
