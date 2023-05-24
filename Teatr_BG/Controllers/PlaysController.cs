
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
    /// <summary>   A controller for handling plays. </summary>
    ///
    /// <remarks>   Julia, 24.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PlaysController : Controller
    {
        /// <summary>   The database. </summary>
        private DatabaseContext db = new DatabaseContext();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Plays. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Index View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Index()
        {
            return View(db.Plays.ToList());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Plays/Details/5. </summary>
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
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            return View(play);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Plays/Create. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Create View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Create()
        {
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// POST: Plays/Create Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych
        /// danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania. Aby uzyskać więcej
        /// szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="play"> The play. </param>
        ///
        /// <returns>   A response stream to send to the Create View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayID,NameP,DateP,Price")] Play play)
        {
            if (ModelState.IsValid)
            {
                db.Plays.Add(play);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(play);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Plays/Edit/5. </summary>
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
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            return View(play);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// POST: Plays/Edit/5 Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych
        /// danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania. Aby uzyskać więcej
        /// szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <param name="play"> The play. </param>
        ///
        /// <returns>   A response stream to send to the Edit View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayID,NameP,DateP,Price")] Play play)
        {
            if (ModelState.IsValid)
            {
                db.Entry(play).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(play);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Plays/Delete/5. </summary>
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
            Play play = db.Plays.Find(id);
            if (play == null)
            {
                return HttpNotFound();
            }
            return View(play);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   POST: Plays/Delete/5. </summary>
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
            Play play = db.Plays.Find(id);
            db.Plays.Remove(play);
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
