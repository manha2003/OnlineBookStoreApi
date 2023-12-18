using AutoMapper;
using DataAccessLayer.Models;
using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
           
                

            CreateMap<Cart, CartDTO>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
      

            CreateMap<Order, OrderDTO>();

            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors));

            CreateMap<Author, AuthorDTO>();
        }

    }
}
