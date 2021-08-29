using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using News.BL.Interfaces;
using News.BL.Models;
using News.DAL.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using News.BL.Helper;

namespace News.Controllers
{
    public class NewssController : Controller
    {
        private readonly IMapper mapper;
        private readonly INewssRep news;
        private readonly ICategoriesRep categories;

        public NewssController(IMapper mapper , INewssRep news , ICategoriesRep categories)
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
        public IActionResult Details(int id)
        {
            var data = mapper.Map<NewssVM>(news.GetById(id));
             ViewBag.CategoriesList = new SelectList(categories.Get(), "Id", "CategoryName", data.CategoryId);

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoriesList = new SelectList(categories.Get(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewssVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var PhotoName = FileUploader.UploadFile("/Files/Photos/", model.PhotoUrl);
                    var data = mapper.Map<Newss>(model);
                    data.Photo = PhotoName;
                    news.Create(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.CategoriesList = new SelectList(categories.Get(), "Id", "CategoryName");
                return View(model);
            }

        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = mapper.Map<NewssVM>(news.GetById(id));
            ViewBag.CategoriesList = new SelectList(categories.Get(), "Id", "CategoryName", data.CategoryId);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(NewssVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Newss>(model);
                    news.Update(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                ViewBag.CategoriesList = new SelectList(categories.Get(), "Id", "CategoryName", model.CategoryId);

                return View(model);
            }

        }

        public IActionResult Delete(int id)
        {
            var data = mapper.Map<NewssVM>(news.GetById(id));

            ViewBag.CategoriesList = new SelectList(categories.Get(), "Id", "CategoryName", data.CategoryId);

            return View(data);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {

            try
            {
                var oldData = news.GetById(id);
                news.Delete(oldData);
                FileUploader.RemoveFile("/File/Photos/", oldData.Photo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                var data = mapper.Map<CategoriesVM>(news.GetById(id));
                return View(data);
            }

        }

    }
}

