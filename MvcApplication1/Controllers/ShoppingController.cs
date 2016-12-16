using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ShoppingController : Controller
    {
        //
        // GET: /Shopping/

        public ActionResult Index()
        {
            return View();
        }


        //Product
        [HttpGet]
        public ActionResult Products(int ProductID)
        {

            MVCTestEntities _entity = new MVCTestEntities();
            List<Product> hh = _entity.Products.Where(x => x.CategoryID == ProductID).ToList();

            return View(hh);
        }


        [HttpGet]
        public ActionResult ProductDetails(int ProductID)
        {

            MVCTestEntities _entity = new MVCTestEntities();
            Product hh = _entity.Products.Where(x => x.ProductID == ProductID).First();

            return View(hh);
        }


        public ActionResult MyCart()
        {
            MVCTestEntities _entity = new MVCTestEntities();

            if (Session["UserID"] != null) // check user is loged in
            {
                int userid = Convert.ToInt32(Session["UserID"]);

                var lst1
                 = (from mc in _entity.Carts
                    join pr in _entity.Products on mc.ProductID equals pr.ProductID
                    join ur in _entity.Users on mc.UserID equals ur.UserID
                    where mc.UserID == userid
                    select new
                    {
                        ProductName = pr.Name,
                        ProductImage = pr.ImagePath,
                        ProductQnt = mc.ProductQnt,
                        TotalPrice = mc.TotalPrice,

                        CartID = mc.CartID
                    }).ToList();


                List<MyCart> mcrt = new List<MyCart>();
                for (int j = 0; j < lst1.Count; j++)
                {
                    MyCart mct = new MyCart();
                    mct.ProductName = lst1[j].ProductName;
                    mct.ProductQnt = lst1[j].ProductQnt;
                    mct.TotalPrice = lst1[j].TotalPrice;
                    mct.CartID = lst1[j].CartID;
                    mct.ProductImage = lst1[j].ProductImage;
                    mcrt.Add(mct);
                }

                Session["Result"] = mcrt;
                ViewBag.Myorder = mcrt;
                return View(mcrt);
            }
            else
                return RedirectToAction("Index", "Account");  // redirect when user is not login
        }
        [HttpPost]
        public ActionResult AddtoCart(FormCollection collection)
        {

            if (Session["UserID"] != null) // check user is loged in
            {
                if (Convert.ToString(collection["Quantity"]) != "")
                {
                    int qnt = Convert.ToInt32(collection["Quantity"]);
                    int price = Convert.ToInt32(collection["Price"]);
                    int productid = Convert.ToInt32(collection["ProductID"]);
                    MVCTestEntities _entity = new MVCTestEntities();
                    Cart crt = new Cart();
                    crt.ProductID = productid;
                    crt.UserID = Convert.ToInt32(Session["UserID"]);
                    crt.ProductQnt = qnt;
                    crt.TotalPrice = qnt * price;

                    _entity.Carts.Add(crt);
                    _entity.SaveChanges();

                    Cart ct = new Cart();
                    List<Cart> lst = _entity.Carts.Where(x => x.UserID == crt.UserID).ToList();
                    var lst1 = (from mc in _entity.Carts
                                join pr in _entity.Products on mc.ProductID equals pr.ProductID
                                join ur in _entity.Users on mc.UserID equals ur.UserID
                                where mc.UserID == crt.UserID
                                select new
                                {
                                    ProductName = pr.Name,
                                    ProductImage = pr.ImagePath,
                                    ProductQnt = mc.ProductQnt,
                                    TotalPrice = mc.TotalPrice,
                                    CartID = mc.CartID
                                }).ToList();



                    List<MyCart> mcrt = new List<MyCart>();
                    for (int j = 0; j < lst1.Count; j++)
                    {
                        MyCart mct = new MyCart();
                        mct.ProductName = lst1[j].ProductName;
                        mct.ProductQnt = lst1[j].ProductQnt;
                        mct.ProductImage = lst1[j].ProductImage;
                        mct.TotalPrice = lst1[j].TotalPrice;
                        mct.CartID = lst1[j].CartID;
                        mcrt.Add(mct);
                    }
                    return View("MyCart", mcrt);

                }
                else
                    return View();
            }
            else
            {
                return RedirectToAction("Index", "Account");  // redirect when user is not login
            }

        }


        public ActionResult EditCart(int id)
        {


            MVCTestEntities _entity = new MVCTestEntities();
            var lst1
               = (from mc in _entity.Carts
                  join pr in _entity.Products on mc.ProductID equals pr.ProductID
                  join ur in _entity.Users on mc.UserID equals ur.UserID
                  where mc.CartID == id
                  select new
                  {
                      ProductName = pr.Name,
                      ProductImage = pr.ImagePath,
                      ProductQnt = mc.ProductQnt,
                      TotalPrice = mc.TotalPrice,

                      CartID = mc.CartID
                  }).ToList();


            List<MyCart> mcrt = new List<MyCart>();
            for (int j = 0; j < lst1.Count; j++)
            {
                MyCart mct = new MyCart();
                mct.ProductName = lst1[j].ProductName;
                mct.ProductQnt = lst1[j].ProductQnt;
                mct.TotalPrice = lst1[j].TotalPrice;
                mct.CartID = lst1[j].CartID;
                mct.ProductImage = lst1[j].ProductImage;
                mcrt.Add(mct);
            }
            return View(mcrt[0]);
        }


        [HttpPost]
        public ActionResult EditCart(FormCollection collection)
        {





            MVCTestEntities _entity = new MVCTestEntities();

            Cart ct = new Cart();
            ct.CartID = Convert.ToInt32(collection["CartID"]);
            ct.ProductQnt = Convert.ToInt32(collection["ProductQnt"]);
            ct.TotalPrice = Convert.ToInt32(collection["ProductQnt"]) * Convert.ToInt32(collection["UnitPrice"]);

            // update cart 
            _entity.Carts.Attach(ct);
            var et = _entity.Entry(ct);
            et.Property(e => e.ProductQnt).IsModified = true;
            et.Property(e => e.TotalPrice).IsModified = true;
            _entity.SaveChanges();

            var lst1
                           = (from mc in _entity.Carts
                              join pr in _entity.Products on mc.ProductID equals pr.ProductID
                              join ur in _entity.Users on mc.UserID equals ur.UserID
                              where mc.CartID == ct.CartID
                              select new
                              {
                                  ProductName = pr.Name,
                                  ProductImage = pr.ImagePath,
                                  ProductQnt = mc.ProductQnt,
                                  TotalPrice = mc.TotalPrice,

                                  CartID = mc.CartID
                              }).ToList();


            List<MyCart> mcrt = new List<MyCart>();
            for (int j = 0; j < lst1.Count; j++)
            {
                MyCart mct = new MyCart();
                mct.ProductName = lst1[j].ProductName;
                mct.ProductQnt = lst1[j].ProductQnt;
                mct.TotalPrice = lst1[j].TotalPrice;
                mct.CartID = lst1[j].CartID;
                mct.ProductImage = lst1[j].ProductImage;
                mcrt.Add(mct);
            }
            Session["Result"] = mcrt;
            ViewBag.Myorder = mcrt;
            return View("MyCart", mcrt);



        }


        public ActionResult Checkout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Checkout(FormCollection collection)
        {

            ViewBag.AddressA = Convert.ToString(collection["Address"]);

            List<MyCart> crt = (List<MyCart>)ViewBag.Myorder;

            MVCTestEntities _entity = new MVCTestEntities();

            int userid= Convert.ToInt32(Session["UserID"]);
            _entity.Carts.Where(x => x.UserID == userid).ToList().ForEach(p => _entity.Carts.Remove(p));
            _entity.SaveChanges();

            ViewBag.Myorder = null;



            return View("Thankyou");
        }


        //DeleteCart
        public ActionResult DeleteCart(int id)
        {
            MVCTestEntities _entity = new MVCTestEntities();

            var crt = _entity.Carts.Where(x => x.CartID == id).First();
            _entity.Carts.Remove(crt);
            _entity.SaveChanges();

            int userid = Convert.ToInt32(Session["UserID"]);
            var lst1
                        = (from mc in _entity.Carts
                           join pr in _entity.Products on mc.ProductID equals pr.ProductID
                           join ur in _entity.Users on mc.UserID equals ur.UserID
                           where mc.UserID == userid
                           select new
                           {
                               ProductName = pr.Name,
                               ProductImage = pr.ImagePath,
                               ProductQnt = mc.ProductQnt,
                               TotalPrice = mc.TotalPrice,

                               CartID = mc.CartID
                           }).ToList();


            List<MyCart> mcrt = new List<MyCart>();
            for (int j = 0; j < lst1.Count; j++)
            {
                MyCart mct = new MyCart();
                mct.ProductName = lst1[j].ProductName;
                mct.ProductQnt = lst1[j].ProductQnt;
                mct.TotalPrice = lst1[j].TotalPrice;
                mct.CartID = lst1[j].CartID;
                mct.ProductImage = lst1[j].ProductImage;
                mcrt.Add(mct);
            }
            Session["Result"] = mcrt;
            ViewBag.Myorder = mcrt;
            return View("MyCart", mcrt);

            
        }
    }
}
