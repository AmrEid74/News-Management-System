using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using News.BL.Interfaces;
using News.BL.Models;
using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRep categories;
        private readonly IMapper mapper;

        public CategoriesController(ICategoriesRep categories, IMapper mapper)
        {
            this.categories = categories;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            var data = mapper.Map<IEnumerable<CategoriesVM>>(categories.Get());
            return View(data);

        }

        public IActionResult Details(int id)
        {
            var data = mapper.Map<CategoriesVM>(categories.GetById(id));
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoriesVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Categories>(model);
                    categories.Create(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = mapper.Map<CategoriesVM>(categories.GetById(id));
            return View(data);
        }

        //[HttpPost]
        //public IActionResult Edit(CategoriesVM model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            var data = mapper.Map<Categories>(model);
        //            categories.Update(data);
        //            return RedirectToAction("Index");
        //        }   

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(model);
        //    }

        //}

    }
}

