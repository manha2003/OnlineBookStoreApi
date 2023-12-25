using AutoMapper;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs.AuthorDTO;
using BusinessLogicLayer.DTOs.BookDTO;
using BusinessLogicLayer.DTOs.CartDTO;
using BusinessLogicLayer.DTOs.OrderDTO;
using BusinessLogicLayer.DTOs.UserDTO;

namespace BusinessLogicLayer.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTODetails>().ReverseMap();

            CreateMap<User, UserDTOTemp>().ReverseMap();
              

            CreateMap<CartDTODetails, Cart>().ReverseMap();

            CreateMap<Cart, CartAdditionalDetails>().ReverseMap()

                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                 
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books))
            ;

            CreateMap<Cart, UpdateCartDTO>().ReverseMap()

                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));


            CreateMap<Order, OrderDTODetails>().ReverseMap()
                 .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart));
            CreateMap<Order, OrderDTOTemp>().ReverseMap()
                .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart));

            /* CreateMap<Cart, PlaceOrderRequestDTO>().ReverseMap()
                 .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId));
             CreateMap<User, PlaceOrderRequestDTO>().ReverseMap()
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));*/
            CreateMap<PlaceOrderRequestDTO, Order>().ReverseMap();

              
            
            CreateMap<PlaceOrderRequestDTO, User>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId)) ;
            CreateMap<Book, BookDTOTemp>().ReverseMap();
            CreateMap<Book, BookDTODetails>().ReverseMap();

            CreateMap<Author, AuthorDTODetails>().ReverseMap(); ;
        }

    }
}
