using Ifood.Data;
using Ifood.Models;
using Microsoft.EntityFrameworkCore;

namespace Ifood.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly RobinContext context;
        public string Diretorio { get; set; }
        private IRestauranteService restauranteService;

        public ProdutoService(RobinContext context, IRestauranteService restauranteService)
        {
            this.context = context;
            this.restauranteService = restauranteService;
        }

        public async Task<ProdutoModel> AddProduto(int idRestaurante ,ProdutoModel produto, string caminhoDiretorio)
        {
            string caminhoParaSalvarImagem = caminhoDiretorio + "\\images_produtos\\";
            Diretorio = Guid.NewGuid().ToString() + "_" + produto.Imagem.FileName;

            if (!Directory.Exists(caminhoParaSalvarImagem))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagem);
            }

            using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + Diretorio))
            {
                await produto.Imagem.CopyToAsync(stream);
            }

            RestauranteModel restaurante = await context.Restaurantes.FirstOrDefaultAsync(x => x.IdRestaurante == idRestaurante);

            if (restaurante != null)
            {
                produto.Restaurante = restaurante;
                produto.CaminhoImagem = Diretorio;
                context.Produtos.Add(produto);
                await context.SaveChangesAsync();
                return produto;
            }
            return null;
        }

        public Task<ProdutoModel> DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
