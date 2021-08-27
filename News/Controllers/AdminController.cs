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
    public class AdminController : Controller
    {
        private readonly IAdminRep admin;
        private readonly IMapper mapper;

        public AdminController(IAdminRep admin , IMapper mapper)
        {
            this.admin = admin;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            var data = mapper.Map<IEnumerable<AdminVM>>(admin.Get());
            return View(data);

        }

        public IActionResult Details(int id)
        {
            var data = mapper.Map<AdminVM>(admin.GetById(id));
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Admin>(model);
                    admin.Create(data);
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
            var data = mapper.Map<AdminVM>(admin.GetById(id));
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AdminVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Admin>(model);
                    admin.Update(data);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        public IActionResult Delete(int id)
        {
            var data = mapper.Map<AdminVM>(admin.GetById(id));
            return View(data);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {

            try
            {
                var oldData = admin.GetById(id);
                admin.Delete(oldData);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                var data = mapper.Map<CategoriesVM>(admin.GetById(id));
                return View(data);
            }

        }

    }
}
