using Ifood.Data;
using Ifood.Models;
using Microsoft.EntityFrameworkCore;

namespace Ifood.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly RobinContext context;
        public string Diretorio { get; set; }

        public RestauranteService(RobinContext context)
        {
            this.context = context;
        }

        public async Task<List<RestauranteModel>> ListarRestaurantes()
        {
            var restaurantes = await context.Restaurantes.ToListAsync();
            return restaurantes;
        }

        public async Task<RestauranteModel> RestaurantePorId(int id)
        {
            return await context.Restaurantes.FindAsync(id);
        }

        public async void AtualizarProdutos(int idRestaurante)
        {
            var restaurante = await RestaurantePorId(idRestaurante);

            if (restaurante == null) throw new Exception("Restaurante não encotrado!");

            restaurante.addProdutos(context.Produtos);
        }

        public async Task<RestauranteModel> AddRestaurante(RestauranteModel restaurante, string caminhoDiretorio)
        {
            string caminhoParaSalvarImagem = caminhoDiretorio + "\\images_restaurantes\\";
            Diretorio = Guid.NewGuid().ToString() + "_" + restaurante.Imagem.FileName;

            if (!Directory.Exists(caminhoParaSalvarImagem))
            {
                Directory.CreateDirectory(caminhoParaSalvarImagem);
            }

            using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + Diretorio))
            {
                await restaurante.Imagem.CopyToAsync(stream);
            }

            restaurante.CaminhoImagem = Diretorio;
            context.Restaurantes.Add(restaurante);
            await context.SaveChangesAsync();
            return restaurante;
        }

        public async Task<RestauranteModel> Update(int id, RestauranteModel request)
        {
            var restauranteDB = await context.Restaurantes.FindAsync(id);

            if (request == null)
            {
                throw new Exception("Não foi possivel encontrar o restaurante, tente novamente!");
            }

            restauranteDB.Nome = request.Nome;
            restauranteDB.Categoria = request.Categoria;
            restauranteDB.Endereco = request.Endereco;

            await context.SaveChangesAsync();
            return restauranteDB;
        }

        public async Task<bool> DeleteRestaurante(int id)
        {
            var dbRestaurante = await context.Restaurantes.FindAsync(id);

            if (dbRestaurante == null)
            {
                throw new Exception("Não foi possivel encontrar o restaurante, tente novamente!");
            }


            foreach (var produto in context.Produtos)
            {

                if (produto.IdRestaurante == dbRestaurante.IdRestaurante)
                {
                    context.Remove(produto);
                }
            }
            await context.SaveChangesAsync();
            return true;
        }

       
    }
}
