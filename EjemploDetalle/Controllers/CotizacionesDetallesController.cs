using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjemploDetalle.DAL;
using EjemploDetalle.Models;

namespace EjemploDetalle.Controllers
{
    public class CotizacionesDetallesController : Controller
    {
        private EjemploDetalleDb db = new EjemploDetalleDb();

        // GET: CotizacionesDetalles
        public ActionResult Index()
        {
            var cotizacionDetalle = db.CotizacionDetalle.Include(c => c.Cotizaciones).Include(c => c.Producto);
            return View(cotizacionDetalle.ToList());
        }

        // GET: CotizacionesDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionDetalle.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Create
        public ActionResult Create()
        {
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId");
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Descripcion");
            return View();
        }

        // POST: CotizacionesDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetalleId,CotizacionId,ProductoId,Descripcion,Cantidad,Precio")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (ModelState.IsValid)
            {
                db.CotizacionDetalle.Add(cotizacionesDetalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId", cotizacionesDetalles.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Descripcion", cotizacionesDetalles.ProductoId);
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionDetalle.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId", cotizacionesDetalles.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Descripcion", cotizacionesDetalles.ProductoId);
            return View(cotizacionesDetalles);
        }

        // POST: CotizacionesDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetalleId,CotizacionId,ProductoId,Descripcion,Cantidad,Precio")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacionesDetalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "CotizacionId", cotizacionesDetalles.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.Producto, "ProductoId", "Descripcion", cotizacionesDetalles.ProductoId);
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionDetalle.Find(id);
            if (cotizacionesDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalles);
        }

        // POST: CotizacionesDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionesDetalles cotizacionesDetalles = db.CotizacionDetalle.Find(id);
            db.CotizacionDetalle.Remove(cotizacionesDetalles);
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
