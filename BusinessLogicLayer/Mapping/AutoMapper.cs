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
        
           
                

            CreateMap<Cart, CartDTODetails>().ReverseMap();
            CreateMap<Cart, CartDTOAdditionalDetails>().ReverseMap()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books)); ;

            CreateMap<Order, OrderDTODetails>().ReverseMap(); ;

            CreateMap<Book, BookDTODetails>().ReverseMap();

            CreateMap<Author, AuthorDTODetails>().ReverseMap(); ;
        }

    }
}
