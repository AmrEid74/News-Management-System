using AutoMapper;
using News.BL.Models;
using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Mapper
{
  public  class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Categories, CategoriesVM>();
            CreateMap<CategoriesVM, Categories>();

            CreateMap<Newss, NewssVM>();
            CreateMap<NewssVM, Newss>();


        }
    }
}
