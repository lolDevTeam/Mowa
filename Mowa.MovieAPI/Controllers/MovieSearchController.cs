// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieSearchController.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the MovieSearchController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The movie search controller.
    /// </summary>
    public class MovieSearchController : Controller
    {
        /// <summary>
        /// The index. // GET: /api/MovieSearch
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}