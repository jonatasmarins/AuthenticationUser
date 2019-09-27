using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationUser.Domain.Entities;
using AuthenticationUser.Domain.Entities.Validators;
using AuthenticationUser.Domain.Models.Generic;
using AuthenticationUser.Domain.Models.Request.Product;
using AuthenticationUser.Domain.Models.Response.Product;
using AuthenticationUser.Domain.Repositories.UnitOfWork;
using AuthenticationUser.Domain.Services;
using AutoMapper;
using FluentValidation.Results;

namespace AuthenticationUser.ApplicationService
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductApplicationService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultResponse> Create(ProductModelRequest request)
        {
            Product product = _mapper.Map<Product>(request);

            ProductValidator validations = new ProductValidator();
            ValidationResult resultValidator = validations.Validate(product);

            ResultResponse result = new ResultResponse(resultValidator);

            if (resultValidator.IsValid)
            {
                await _unitOfWork.productRepository.Create(product);
            }

            return result;
        }

        public async Task<ResultResponse> Delete(ProductModelRequest request)
        {
            Product product = _mapper.Map<Product>(request);
            ProductValidator validations = new ProductValidator();
            ValidationResult resultValidator = validations.Validate(product);

            ResultResponse result = new ResultResponse(resultValidator);

            if (resultValidator.IsValid)
            {
                await _unitOfWork.productRepository.Delete(product);
            }

            return result;
        }

        public async Task<ResultResponseObject<IEnumerable<ProductModelResponse>>> GetAll()
        {
            ResultResponseObject<IEnumerable<ProductModelResponse>> result = new ResultResponseObject<IEnumerable<ProductModelResponse>>();

            IEnumerable<Product> resultService = await _unitOfWork.productRepository.Get();
            result.Value = _mapper.Map<IEnumerable<ProductModelResponse>>(resultService);

            return result;
        }

        public async Task<ResultResponseObject<IEnumerable<ProductModelResponse>>> GetProductsFilter(string title)
        {
            ResultResponseObject<IEnumerable<ProductModelResponse>> result = new ResultResponseObject<IEnumerable<ProductModelResponse>>();

            IEnumerable<Product> resultService = await _unitOfWork.productRepository.GetProductsFilter(title);
            result.Value = _mapper.Map<IEnumerable<ProductModelResponse>>(resultService);

            return result;
        }

        public async Task<ResultResponse> Update(ProductModelRequest request)
        {            
            Product product = _mapper.Map<Product>(request);
            ProductValidator validations = new ProductValidator();
            ValidationResult resultValidator = validations.Validate(product);

            ResultResponse result = new ResultResponse(resultValidator);

            if (resultValidator.IsValid)
            {
                await _unitOfWork.productRepository.Update(product);
            }

            return result;
        }
    }
}
