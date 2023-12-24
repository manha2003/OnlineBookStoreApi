using AutoMapper;
using DataAccessLayer.Models;
<<<<<<< Updated upstream
using BusinessLogicLayer.DTOs;
=======
using BusinessLogicLayer.DTOs.AuthorDTO;
using BusinessLogicLayer.DTOs.BookDTO;
using BusinessLogicLayer.DTOs.CartDTO;

using BusinessLogicLayer.DTOs.OrderDTO;
using BusinessLogicLayer.DTOs.UserDTO;
>>>>>>> Stashed changes

namespace BusinessLogicLayer.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
<<<<<<< Updated upstream
            CreateMap<User, UserDTO>().ReverseMap();
           
                

            CreateMap<Cart, CartDTO>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
      

            CreateMap<Order, OrderDTO>();

            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors));

            CreateMap<Author, AuthorDTO>();
=======
            CreateMap<User, UserDTODetails>().ReverseMap();

            CreateMap<User, UserDTOTemp>().ReverseMap();





            CreateMap<Cart, CartDTODetails>().ReverseMap();

            // Additional mappings for User and Cart

            CreateMap<Cart, CartDTOAdditionalDetails>().ReverseMap()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserId))
                 .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
             

            ;


            // Additional mapping for AddToCartDto to CartItem
            CreateMap<Cart, UpdateCartDTO>().ReverseMap()
             .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
            


            CreateMap<Order, OrderDTODetails>().ReverseMap(); 

            CreateMap<Book, BookDTODetails>().ReverseMap()
               

            ;


            CreateMap<Author, AuthorDTODetails>().ReverseMap(); 
>>>>>>> Stashed changes
        }

    }
}
