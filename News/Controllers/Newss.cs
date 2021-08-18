using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using News.BL.Interfaces;
using News.BL.Models;

namespace News.Controllers
{
    public class Newss : Controller
    {
        private readonly IMapper mapper;
        private readonly INewssRep newssRep;
        private readonly ICategoriesRep categoriesRep;

        public Newss(IMapper mapper , INewssRep newssRep , ICategoriesRep categoriesRep)
        {
            this.mapper = mapper;
            this.newssRep = newssRep;
            this.categoriesRep = categoriesRep;
        }
        public IActionResult Index()

        {
            var data = mapper.Map<IEnumerable<NewssVM>>(newssRep.Get());
            return View(data);
        }
    }
}
