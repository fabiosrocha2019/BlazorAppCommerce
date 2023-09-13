using BlazorAppCommerce.Interfaces;
using BlazorAppCommerce.Interfaces;
using BlazorAppCommerce.Models;
using Blazorise.Extensions;

namespace BlazorAppCommerce.Validations
{
    public class ProdutoValidacoes : IProdutoValidacoes
    {
        private readonly IProdutoService _produtoService;
        public ProdutoValidacoes(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public bool ValidaIdSolicitacao(int id)
        {
            return id > 0;
        }

        public bool ValidaRegistroExistente(int id)
        {
            var produtoExistente = _produtoService.GetProdutoById(id);

            return produtoExistente != null;
        }

        public bool ValidaCamposProduto(Produto produto)
        {

            if (string.IsNullOrEmpty(produto.Nome))
            {
                return false;
            }

            if (produto.Estoque <= 0)
            {
                return false;
            }

            if (produto.Valor <= 0)
            {
                return false;
            }
            return true;
        }
    }

}
