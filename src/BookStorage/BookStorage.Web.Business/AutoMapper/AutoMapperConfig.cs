using AutoMapper;
using BookStorage.Business.DTO;
using BookStorage.Data.Model;

namespace BookStorage.Web.Business.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<BookDTO, Book>();
            Mapper.CreateMap<Book, BookDTO>();
        }
    }
}