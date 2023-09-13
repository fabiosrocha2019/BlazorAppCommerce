using BlazorAppCommerce.Interfaces;
using BlazorAppCommerce.Models;
using BlazorAppCommerce.Service;
using Moq;

namespace BlazorAppCommerce.UnitTests
{
    public class ProdutoServiceTests
    {

        [Fact]
        public async Task CadastrarProduto_ChamaMetodoCadastrarProdutoDoRepository()
        {

            var dapperServiceMock = new Mock<IDapperService>();
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(dapperServiceMock.Object, produtoRepositoryMock.Object);
            var produto = new Produto();


            await produtoService.CadastrarProduto(produto);


            produtoRepositoryMock.Verify(repo => repo.CadastrarProduto(produto), Times.Once);
        }

        [Fact]
        public async Task DeletarProduto_ChamaMetodoDeletarProdutoDoRepository()
        {

            var dapperServiceMock = new Mock<IDapperService>();
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(dapperServiceMock.Object, produtoRepositoryMock.Object);
            int id = 1;


            await produtoService.DeletarProduto(id);


            produtoRepositoryMock.Verify(repo => repo.DeletarProduto(id), Times.Once);
        }

        [Fact]
        public async Task GetProdutoById_ChamaMetodoGetProdutoByIdDoRepository()
        {

            var dapperServiceMock = new Mock<IDapperService>();
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(dapperServiceMock.Object, produtoRepositoryMock.Object);
            int id = 1;


            await produtoService.GetProdutoById(id);


            produtoRepositoryMock.Verify(repo => repo.GetProdutoById(id), Times.Once);
        }

        [Fact]
        public async Task BuscarTodosProdutos_DeveChamarMetodoBuscarTodosProdutosDoRepository()
        {
            var dapperServiceMock = new Mock<IDapperService>();
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(dapperServiceMock.Object, produtoRepositoryMock.Object);

            await produtoService.BuscarTodosProdutos();

            produtoRepositoryMock.Verify(repo => repo.BuscarTodosProdutos(), Times.Once);
        }

        [Fact]
        public async Task AtualizarProduto_DeveChamarMetodoAtualizarProdutoDoRepository()
        {
            var dapperServiceMock = new Mock<IDapperService>();
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(dapperServiceMock.Object, produtoRepositoryMock.Object);
            var produto = new Produto();

            await produtoService.AtualizarProduto(produto);

            produtoRepositoryMock.Verify(repo => repo.AtualizarProduto(produto), Times.Once);
        }

        [Fact]
        public async Task CadastrarProduto_DeveCapturarExceptionEPropagar()
        {

            var dapperServiceMock = new Mock<IDapperService>();
            var produtoRepositoryMock = new Mock<IProdutoRepository>();
            produtoRepositoryMock.Setup(repo => repo.CadastrarProduto(It.IsAny<Produto>())).Throws<Exception>();
            var produtoService = new ProdutoService(dapperServiceMock.Object, produtoRepositoryMock.Object);
            var produto = new Produto();

            await Assert.ThrowsAsync<Exception>(async () => await produtoService.CadastrarProduto(produto));
        }
    }
}
