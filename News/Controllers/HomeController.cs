using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News.BL.Interfaces;
using News.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class HomeController : Controller { 



    private readonly IMapper mapper;
    private readonly INewssRep news;
    private readonly ICategoriesRep categories;

    public HomeController(IMapper mapper, INewssRep news, ICategoriesRep categories)
    {
        this.mapper = mapper;
        this.news = news;
        this.categories = categories;
    }
    public IActionResult Index()
        {

            var data = mapper.Map<IEnumerable<NewssVM>>(news.Get());
            return View(data);
        }
    }
}
