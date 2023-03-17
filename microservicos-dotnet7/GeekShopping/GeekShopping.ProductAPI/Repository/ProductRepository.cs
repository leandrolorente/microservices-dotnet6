using AutoMapper;
using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<ProductDto>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);

        }

        public async Task<ProductDto> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.id == id)
                                                     .FirstOrDefaultAsync() ?? new Product();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> FindByName(string name)
        {
            Product product = await _context.Products.Where(p => p.Name == name)
                                         .FirstOrDefaultAsync() ?? new Product();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Create(ProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Update(ProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product); ;
        }

        public async Task<bool> DeleteById(long id)
        {
            try
            {
                Product product = await _context.Products.Where(p => p.id == id)
                                                     .FirstOrDefaultAsync() ?? new Product();

                if (product.id <= 0) 
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteByName(string name)
        {
            try
            {
                Product product = await _context.Products.Where(p => p.Name == name)
                                                     .FirstOrDefaultAsync() ?? new Product();

                if (product.id <= 0)
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    
      
    }
}
