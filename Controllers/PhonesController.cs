using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AMobile.DAL;
using AMobile.Models;
using AMobile.ViewModels;

namespace AMobile.Controllers
{
    public class PhonesController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Phones
        public ActionResult Index(string category, string search)
        {
            PhoneViewModel viewModel = new PhoneViewModel();
            var phones = db.Phones.Include(p => p.Category);
            if (!String.IsNullOrEmpty(search))
            {
                phones = phones.Where(p => p.Name.Contains(search) ||
                                        p.Description.Contains(search) ||
                                        p.Category.Name.Contains(search) ||
                                        p.Capacity.Contains(search));
                viewModel.Search = search;
            }
            viewModel.CategoriesWithCount = from matchingProducts in phones
                                            where
                                            matchingProducts.CategoryID != null
                                            group matchingProducts by
                                            matchingProducts.Category.Name into
                                            categoryGroup
                                            select new CategoryWithCount()
                                            {
                                                CategoryName = categoryGroup.Key,
                                                PhoneCount = categoryGroup.Count()
                                            };

            if (!String.IsNullOrEmpty(category))
            {
                phones = phones.Where(p => p.Category.Name == category);
            }

            viewModel.Phones = phones;
            return View(viewModel);
        }

        // GET: Phones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // GET: Phones/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Description,Capacity,Colour,Specs,CategoryID")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", phone.CategoryID);
            return View(phone);
        }

        // GET: Phones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", phone.CategoryID);
            return View(phone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Description,Capacity,Colour,Specs,CategoryID")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", phone.CategoryID);
            return View(phone);
        }

        // GET: Phones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phones.Find(id);
            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}



