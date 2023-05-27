using AutoMapper;
using WebAPI.Model.Request.CartDTOs;
using WebAPI.Model.Request.CategoryDTOs;
using WebAPI.Model.Request.OrderDetailDTOs;
using WebAPI.Model.Request.OrderDTOs;
using WebAPI.Model.Request.ProductDTOs;
using WebAPI.Model.Request.UserDTOs;
using WebAPI.Model.Response.CartDTOs;
using WebAPI.Model.Response.CategoryDTOs;
using WebAPI.Model.Response.OrderDetailDTOs;
using WebAPI.Model.Response.OrderDTOs;
using WebAPI.Model.Response.ProductDTOs;
using WebAPI.Model.Response.UserDTOs;
using WebAPI.Repository.Entities;

namespace WebAPI.Model.AutoMapper
{
    public class MapperConfig : Profile
    {
        //Config AutoMapper
        public MapperConfig()
        {
            #region Category
            //Config Category mapper 
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryEditDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDetailDTO>().ReverseMap();
            #endregion
            //Config Product mapper 
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductEditDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductDetailDTO>().ReverseMap();
            //Config Order mapper 
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<Order, OrderEditDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            //Config OrderDetail mapper 
            CreateMap<OrderDetail, OrderDetailCreateDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailEditDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            //Config Cart mapper 
            CreateMap<Cart, CartCreateDTO>().ReverseMap();
            CreateMap<Cart, CartEditDTO>().ReverseMap();
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<Cart, CartDetailDTO>().ReverseMap();
            //Config User mapper 
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserEditDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}