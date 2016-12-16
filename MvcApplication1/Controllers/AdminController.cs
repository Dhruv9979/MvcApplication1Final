using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {

            MVCTestEntities _entity = new MVCTestEntities();

            _entity.Categories.Add(category);
            _entity.SaveChanges();

           // return View();
            return RedirectToAction("Index");
        }

        public ActionResult AddProduct()
        {


            MVCTestEntities _entity = new MVCTestEntities();

            Product product = new Product();

            product.CategoryList = new SelectList (_entity.Categories.AsEnumerable(), "CategoryID","Name");
            return View(product);
        }
        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase file)
        {

            MVCTestEntities _entity = new MVCTestEntities();


            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    file.SaveAs(Path.Combine(Server.MapPath("~/Assets/Images/"), fileName));
                    product.ImagePath = fileName;
                }

                _entity.Products.Add(product);
                _entity.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                product.CategoryList = new SelectList(_entity.Categories.AsEnumerable(), "CategoryID", "Name");
                return View(product);
            }
        }

    }
}
