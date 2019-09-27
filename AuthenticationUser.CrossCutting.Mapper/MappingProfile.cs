using AuthenticationUser.Domain.Entities;
using AuthenticationUser.Domain.Models.Request.Product;
using AuthenticationUser.Domain.Models.Response.Category;
using AuthenticationUser.Domain.Models.Response.Product;
using AutoMapper;

namespace AuthenticationUser.CrossCutting.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Command -> Entity

            CreateMap<ProductModelRequest, Product>();

            #endregion

            #region Entity -> Command

            CreateMap<Product, ProductModelResponse>();
            CreateMap<Category, CategoryModelResponse>();

            #endregion
        }
    }
}
