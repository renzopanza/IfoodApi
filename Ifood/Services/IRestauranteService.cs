using Ifood.Models;

namespace Ifood.Services
{
    public interface IRestauranteService
    {
        Task<List<RestauranteModel>> ListarRestaurantes();
        Task<RestauranteModel> RestaurantePorId(int idRestaurante);
        Task<RestauranteModel> AddRestaurante(RestauranteModel restaurante, string caminhoDiretorio);
        Task<RestauranteModel> Update(int id, RestauranteModel request);
        Task<bool> DeleteRestaurante(int id);
        void AtualizarProdutos(int idRestaurante);


        //Criar Listar Pedidos
    }
}
