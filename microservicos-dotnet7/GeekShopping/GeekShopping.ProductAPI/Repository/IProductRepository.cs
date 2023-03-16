using GeekShopping.ProductAPI.Data.DTO;

namespace GeekShopping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> FindAll();
        Task<ProductDto> FindById(long id);
        Task<ProductDto> FindByName(string name);
        Task<ProductDto> Create(ProductDto dto);
        Task<ProductDto> Update(ProductDto dto);
        Task<ProductDto> DeleteById(long id);
        Task<ProductDto> DeleteByName(string name);
        
    }
}
