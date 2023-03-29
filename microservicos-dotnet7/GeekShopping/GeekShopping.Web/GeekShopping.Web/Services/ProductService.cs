using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Reflection;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public const string BasePath = "api/v1/Product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            return response.IsSuccessStatusCode ? await response.ReadContentAs<ProductModel>() : throw new Exception("Algo de errado ocorreu ao chamar a API (createProduct)");
        }
        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            return response.IsSuccessStatusCode ? await response.ReadContentAs<ProductModel>() : throw new Exception("Algo de errado ocorreu ao chamar a API (createProduct)");
        }
        public async Task<bool> DeleteProduct(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            return response.IsSuccessStatusCode ? await response.ReadContentAs<bool>() : throw new Exception("Algo de errado ocorreu ao chamar a API (createProduct)");
        }   

        
    }
}
