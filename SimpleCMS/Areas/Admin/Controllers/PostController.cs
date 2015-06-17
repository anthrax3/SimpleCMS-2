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
            var posts = _repository.GetAll();

            return View(posts);
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

            _repository.Create(model);

            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("edit/{postId}")]
        public ActionResult Edit (string postId)
        {
            var post = _repository.Get(postId);

            if (post == null) {
                return HttpNotFound();
            }

            return View(post);
        }

        [HttpPost]
        [Route("edit/{postId}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (string postId, Post model)
        {
            var post = _repository.Get(postId);

            if (post == null) {
                return HttpNotFound();
            }
            
            if (!ModelState.IsValid) {
                return View(model);
            }

            _repository.Edit(postId, model);

            return RedirectToAction("index");
        }
    }
}