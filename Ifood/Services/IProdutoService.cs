using Ifood.Models;

namespace Ifood.Services
{
    public interface IProdutoService
    {
        //Fazer igual restaurante para adicionar imagem

        Task<ProdutoModel> AddProduto(int idRestaurante, ProdutoModel produto, string caminhoDiretorio);
        Task<ProdutoModel> DeleteProduto(int id);
    }
}
