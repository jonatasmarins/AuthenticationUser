using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationUser.Domain.Entities;
using AuthenticationUser.Domain.Entities.Validators;
using AuthenticationUser.Domain.Models.Generic;
using AuthenticationUser.Domain.Models.Request.Category;
using AuthenticationUser.Domain.Models.Response.Category;
using AuthenticationUser.Domain.Repositories.UnitOfWork;
using AuthenticationUser.Domain.Services;
using AutoMapper;
using FluentValidation.Results;

namespace AuthenticationUser.ApplicationService
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryApplicationService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultResponse> Create(string title)
        {
            Category category = new Category(title);

            CategoryValidator validations = new CategoryValidator();
            ValidationResult resultValidator = validations.Validate(category);
            ResultResponse resultResponse = new ResultResponse(resultValidator);
            
            if (resultValidator.IsValid)
            {
                await _unitOfWork.categoryRepository.Create(category);
            }

            return resultResponse;
        }

        public async Task<ResultResponse> Delete(CategoryModelRequest request)
        {            
            Category category = new Category(request.Title);
            category.Id = request.Id;

            CategoryValidator validations = new CategoryValidator();
            ValidationResult resultValidator = validations.Validate(category);
            ResultResponse resultResponse = new ResultResponse(resultValidator);

            if (resultValidator.IsValid)
            {
                await _unitOfWork.categoryRepository.Delete(category);
            }            

            return resultResponse;
        }

        public async Task<ResultResponseObject<IEnumerable<CategoryModelResponse>>> GetAll()
        {
            ResultResponseObject<IEnumerable<CategoryModelResponse>> resultResponse = new ResultResponseObject<IEnumerable<CategoryModelResponse>>();

            IEnumerable<Category> resultService = await _unitOfWork.categoryRepository.Get();
            resultService = resultService.OrderBy(x => x.Title);

            resultResponse.Value = _mapper.Map<IEnumerable<CategoryModelResponse>>(resultService);

            return resultResponse;
        }

        public async Task<ResultResponse> Update(CategoryModelRequest request)
        {            
            Category category = new Category(request.Title);
            category.Id = request.Id;

            CategoryValidator validations = new CategoryValidator();
            ValidationResult resultValidator = validations.Validate(category);
            ResultResponse resultResponse = new ResultResponse(resultValidator);

            if (resultValidator.IsValid)
            {
                await _unitOfWork.categoryRepository.Update(category);
            }            

            return resultResponse;
        }
    }
}
