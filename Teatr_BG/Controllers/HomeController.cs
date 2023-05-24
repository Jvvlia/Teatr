
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teatr_BG.Controllers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A controller for handling homes. </summary>
    ///
    /// <remarks>   Julia, 24.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HomeController : Controller
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the index. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Index View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Index()
        {
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the about. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the About View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the contact. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Contact View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}