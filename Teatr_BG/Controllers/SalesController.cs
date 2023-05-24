
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teatr_BG.Models;
using Teatr_BG.Models.DbModels;

namespace Teatr_BG.Controllers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A controller for handling sales. </summary>
    ///
    /// <remarks>   Julia, 24.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SalesController : Controller
    {
        /// <summary>   The database. </summary>
        private DatabaseContext db = new DatabaseContext();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Sales. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Index View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Client).Include(s => s.Play);
            return View(sales.ToList());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Sales/Details/5. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   A response stream to send to the Details View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Sales/Create. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Create View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PhoneNumber");
            ViewBag.PlayID = new SelectList(db.Plays, "PlayID", "NameP");
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// POST: Sales/Create Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych
        /// danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania. Aby uzyskać więcej
        /// szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="sale"> The sale. </param>
        ///
        /// <returns>   A response stream to send to the Create View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleID,NumberTickets,ClientID,PlayID")] Sale sale)
        {
            if (sale.NumberTickets > 0)
            {
                if (ModelState.IsValid)
                {
                    db.Sales.Add(sale);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PhoneNumber", sale.ClientID);
                ViewBag.PlayID = new SelectList(db.Plays, "PlayID", "NameP", sale.PlayID);
                return View(sale);
            }
            else
            {
                ModelState.AddModelError("NumberTickets", "Liczba biletow nie moze byc ujemna.");
                ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PhoneNumber", sale.ClientID);
                ViewBag.PlayID = new SelectList(db.Plays, "PlayID", "NameP", sale.PlayID);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Liczba biletow nie moze byc ujemna.");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Sales/Edit/5. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   A response stream to send to the Edit View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PhoneNumber", sale.ClientID);
            ViewBag.PlayID = new SelectList(db.Plays, "PlayID", "NameP", sale.PlayID);
            return View(sale);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// POST: Sales/Edit/5 Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych
        /// danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania. Aby uzyskać więcej
        /// szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="sale"> The sale. </param>
        ///
        /// <returns>   A response stream to send to the Edit View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,NumberTickets,ClientID,PlayID")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "PhoneNumber", sale.ClientID);
            ViewBag.PlayID = new SelectList(db.Plays, "PlayID", "NameP", sale.PlayID);
            return View(sale);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Sales/Delete/5. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   A response stream to send to the Delete View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   POST: Sales/Delete/5. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   A response stream to send to the DeleteConfirmed View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Releases unmanaged resources and optionally releases managed resources. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="disposing">    true to release both managed and unmanaged resources; false to
        ///                             release only unmanaged resources. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
