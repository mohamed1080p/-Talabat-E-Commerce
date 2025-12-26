using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Abstraction.Contracts;
using Shared.Dtos;

namespace Services.Implementations
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var brands= await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
            var BrandsResult = _mapper.Map<IEnumerable<BrandResultDto>>(brands);
            return BrandsResult;
        }

        public async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync()
        {
            var Products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var ProductsResult = _mapper.Map<IEnumerable<ProductResultDto>>(Products);
            return ProductsResult;
        }

        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var Products = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var ProductsResult = _mapper.Map<IEnumerable<TypeResultDto>>(Products);
            return ProductsResult;
        }

        public async Task<ProductResultDto> GetProductByIdAsync(int Id)
        {
            var Product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(Id);
            var ProductResult=_mapper.Map<ProductResultDto>(Product);
            return ProductResult;
        }
    }
}
