using BlazorAppCommerce.Interfaces;
using BlazorAppCommerce.Models;
using BlazorAppCommerce.Validations;
using Moq;



namespace BlazorAppCommerce.UnitTests
{

    public class ProdutoValidacoesTests
    {
        [Fact]
        public void ValidaIdSolicitacao_DeveRetornarTrueParaIdPositivo()
        {
            
            var validacoes = new ProdutoValidacoes(Mock.Of<IProdutoService>());
            int id = 1;

            
            bool result = validacoes.ValidaIdSolicitacao(id);

            
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ValidaIdSolicitacao_DeveRetornarFalseParaIdNegativoOuZero(int id)
        {
            
            var validacoes = new ProdutoValidacoes(Mock.Of<IProdutoService>());
            
            bool result = validacoes.ValidaIdSolicitacao(id);

            
            Assert.False(result);
        }

        [Fact]
        public void ValidaCamposProduto_DeveRetornarTrueParaCamposValidos()
        {
            
            var validacoes = new ProdutoValidacoes(Mock.Of<IProdutoService>());
            var produto = new Produto
            {
                Nome = "Produto",
                Estoque = 10,
                Valor = 50.00
            };

            
            bool result = validacoes.ValidaCamposProduto(produto);

            
            Assert.True(result);
        }

        [Fact]
        public void ValidaCamposProduto_DeveRetornarFalseParaNomeVazio()
        {
            
            var validacoes = new ProdutoValidacoes(Mock.Of<IProdutoService>());
            var produto = new Produto
            {
                Nome = "",
                Estoque = 10,
                Valor = 50.0
            };

            
            bool result = validacoes.ValidaCamposProduto(produto);

            
            Assert.False(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ValidaCamposProduto_DeveRetornarFalseParaEstoqueNegativoOuZero(int estoque)
        {
            
            var validacoes = new ProdutoValidacoes(Mock.Of<IProdutoService>());
            var produto = new Produto
            {
                Nome = "Produto",
                Estoque = estoque,
                Valor = 50.0
            };

            
            bool result = validacoes.ValidaCamposProduto(produto);

            
            Assert.False(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ValidaCamposProduto_DeveRetornarFalseParaValorNegativoOuZero(double valor)
        {
            
            var validacoes = new ProdutoValidacoes(Mock.Of<IProdutoService>());
            var produto = new Produto
            {
                Nome = "Produto",
                Estoque = 10,
                Valor = valor
            };

            
            bool result = validacoes.ValidaCamposProduto(produto);

            
            Assert.False(result);
        }
    }
}
