using SimpleCMS.Data;
using SimpleCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCMS.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("post")]
    public class PostController : Controller
    {
        private readonly IPostRepository _repository;

        public PostController (IPostRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create ()
        {
            var model = new Post();

            return View(model);
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Post model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit (string id)
        {
            var post = _repository.Get(id);

            if (post == null) {
                return HttpNotFound();
            }

            return View(post);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Post model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }

            return RedirectToAction("index");
        }
    }
}