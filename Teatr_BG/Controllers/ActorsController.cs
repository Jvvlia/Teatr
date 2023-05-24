
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
    /// <summary>   A controller for handling actors. </summary>
    ///
    /// <remarks>   Julia, 20.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ActorsController : Controller
    {
        /// <summary>   The database. </summary>
        private DatabaseContext db = new DatabaseContext();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Actors. </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Index View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Index()
        {
            return View(db.Actors.ToList());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Actors/Details/5. </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
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
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Actors/Create. </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Create View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Create()
        {
            return View(new Actor());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// POST: Actors/Create Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu
        /// dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania. Aby
        /// uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
        ///
        /// <param name="actor">    The actor. </param>
        ///
        /// <returns>   A response stream to send to the Create View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorID,FName,LName,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Actors/Edit/5. </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
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
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// POST: Actors/Edit/5 Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu
        /// dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania. Aby
        /// uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
        ///
        /// <param name="actor">    The actor. </param>
        ///
        /// <returns>   A response stream to send to the Edit View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorID,FName,LName,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: Actors/Delete/5. </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
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
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   POST: Actors/Delete/5. </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   A response stream to send to the DeleteConfirmed View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Releases unmanaged resources and optionally releases managed resources. </summary>
        ///
        /// <remarks>   Julia, 20.05.2023. </remarks>
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
