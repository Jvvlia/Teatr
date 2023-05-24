
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teatr_BG.Models;
using Teatr_BG.Models.DbModels;

namespace Teatr_BG.Controllers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A controller for handling view models. </summary>
    ///
    /// <remarks>   Julia, 24.05.2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ViewModelsController : Controller
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   GET: ViewModels. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   A response stream to send to the Summary View. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Summary()
        {
            // Pobierz dane sprzedaży z bazy danych lub innego źródła
            List<Sale> salesData = GetSalesData();

            // Oblicz podsumowanie sprzedaży
            int totalClients = salesData.Select(s => s.ClientID).Distinct().Count();
            int totalTicketsSold = salesData.Sum(s => s.NumberTickets);

            // Tworzenie instancji view modelu i przypisanie wartości podsumowania sprzedaży
            ViewModel viewModel = new ViewModel
            {
                TotalClients = totalClients,
                TotalTicketsSold = totalTicketsSold
            };

            return View(viewModel);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets sales data. </summary>
        ///
        /// <remarks>   Julia, 24.05.2023. </remarks>
        ///
        /// <returns>   The sales data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private List<Sale> GetSalesData()
        {
            using (var context = new DatabaseContext())
            {
                return context.Sales.ToList();
            }
        }
        
    }
}
