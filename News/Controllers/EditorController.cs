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
    public class EditorController : Controller
    {
        private readonly IEditorRep editor;
        private readonly IMapper mapper;

        public EditorController(IEditorRep editor, IMapper mapper)
        {
            this.editor = editor;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            var data = mapper.Map<IEnumerable<EditorVM>>(editor.Get());
            return View(data);

        }

        public IActionResult Details(int id)
        {
            var data = mapper.Map<EditorVM>(editor.GetById(id));
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EditorVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Editor>(model);
                    editor.Create(data);
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
            var data = mapper.Map<EditorVM>(editor.GetById(id));
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EditorVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Editor>(model);
                    editor.Update(data);
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
            var data = mapper.Map<EditorVM>(editor.GetById(id));
            return View(data);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {

            try
            {
                var oldData = editor.GetById(id);
                editor.Delete(oldData);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                var data = mapper.Map<EditorVM>(editor.GetById(id));
                return View(data);
            }

        }

    }
}
