// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchController.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the MovieSearchController type.
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

    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    /// The movie search controller.
    /// </summary>
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        /// <summary>
        /// The movie db api url.
        /// </summary>
        private const string MovieDbApiUrl = "https://api.themoviedb.org/3/search/";

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
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public SearchController(IConfiguration configuration, ILogger<SearchController> logger)
        {
            this.configuration = configuration;
            this.logger = logger;

            this.movieDbApiKey = this.configuration.GetSection("MovieDB").GetChildren().FirstOrDefault()?.Value;
        }

        /// <summary>
        /// The index. // GET: /api/Search/Movie/{movie}
        /// </summary>
        /// <param name="searchString">
        /// The search String.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet("movie/{searchString}")]
        public async Task<MovieSearchResult> Movie(string searchString)
        {
            searchString = searchString.Replace(" ", "%20");
            var queryUrl = MovieDbApiUrl + "movie?query=" + searchString + "&api_key=" + this.movieDbApiKey;

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

            var searchResult = JsonConvert.DeserializeObject<MovieSearchResult>(responseData);

            return searchResult;
        }

        /// <summary>
        /// The tv show.
        /// </summary>
        /// <param name="searchString">
        /// The search string.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("tv/{searchString}")]
        public async Task<TvShowSearchResult> Tv(string searchString)
        {
            searchString = searchString.Replace(" ", "%20");
            var queryUrl = MovieDbApiUrl + "tv?query=" + searchString + "&api_key=" + this.movieDbApiKey;

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

            var searchResult = JsonConvert.DeserializeObject<TvShowSearchResult>(responseData);

            return searchResult;
        }
    }
}