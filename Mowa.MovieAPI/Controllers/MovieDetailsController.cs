// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieDetailsController.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the MovieDetailsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Mowa.MovieAPI.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using Mowa.MovieAPI.Model.Movie;

    /// <inheritdoc />
    /// <summary>
    /// The movie details controller.
    /// </summary>
    [Route("api/[controller]")]
    public class MovieDetailsController : Controller
    {
        /// <summary>
        /// The movie db api url.
        /// </summary>
        private const string MovieDbApiUrl = "https://api.themoviedb.org/3/movie/";

        /// <summary>
        /// The movie db api key.
        /// </summary>
        private readonly string movieDbApiKey;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The configuration.
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieDetailsController"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public MovieDetailsController(IConfiguration configuration, ILogger<MovieDetailsController> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<MovieDetail> Get(int id)
        {
            var queryUrl = string.Concat(MovieDbApiUrl + "movie/{id}?api_key={api_key}", id, this.movieDbApiKey);
        }
    }
}
