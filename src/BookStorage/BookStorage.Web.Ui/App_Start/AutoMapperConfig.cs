using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookStorage.Business.DTO;
using BookStorage.Web.Ui.Models;

namespace BookStorage.Web.Ui.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<BookViewModel, BookDTO>();
            Mapper.CreateMap<BookDTO, BookViewModel>();
        }
    }
}