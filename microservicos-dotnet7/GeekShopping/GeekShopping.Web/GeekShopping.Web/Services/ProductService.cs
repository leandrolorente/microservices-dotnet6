using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public const string BasePath = "api/v1/product";

        public Task<IEnumerable<ProductModel>> FindAllProducts()
        {
           // var response = new 
        }

        public Task<ProductModel> FindById(long id)
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> CreateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> UpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteProduct(long id)
        {
            throw new NotImplementedException();
        }   

        
    }
}
