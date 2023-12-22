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
            CreateMap<Order, OrderDTODetails>().ReverseMap(); ;

            CreateMap<Book, BookDTODetails>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Authors.First().AuthorId))
                .ReverseMap();

            CreateMap<Author, AuthorDTODetails>().ReverseMap(); ;
        }

    }
}
