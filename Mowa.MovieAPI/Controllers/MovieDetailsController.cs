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
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using Mowa.MovieAPI.Model.Movie;

    using Newtonsoft.Json;

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

            this.movieDbApiKey = this.configuration.GetSection("MovieDB").GetChildren().FirstOrDefault()?.Value;
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
            var queryUrl = MovieDbApiUrl + id + "?api_key=" + this.movieDbApiKey;
            this.logger.LogDebug("queryUrl=" + queryUrl);

            var client = new HttpClient() { BaseAddress = new Uri(MovieDbApiUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.logger.LogInformation("Performing a GET request to the endpoint.");

            var response = await client.GetAsync(queryUrl);

            if (!response.IsSuccessStatusCode)
            {
                this.logger.LogError("response status is not successful. " + response.StatusCode);
                return null;
            }

            var responseData = await response.Content.ReadAsStringAsync();

            var searchResult = JsonConvert.DeserializeObject<MovieDetail>(responseData);

            return searchResult;
        }
    }
}
