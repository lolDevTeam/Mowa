// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TvShowsController.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the TvShowsController type.
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

    using Mowa.MovieAPI.Model.Search;
    using Mowa.MovieAPI.Model.TV;

    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    /// The tv shows controller.
    /// </summary>
    [Route("api/[controller]")]
    public class TvShowsController : Controller
    {
        /// <summary>
        /// The movie db api url.
        /// </summary>
        private const string MovieDbApiUrl = "https://api.themoviedb.org/3/tv/";

        /// <summary>
        /// The movie db api key.
        /// </summary>
        private readonly string movieDbApiKey;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TvShowsController"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public TvShowsController(IConfiguration configuration, ILogger<TvShowsController> logger)
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
        public async Task<TvShowDetail> Get(int id)
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

            var searchResult = JsonConvert.DeserializeObject<TvShowDetail>(responseData);

            return searchResult;
        }
    }
}
