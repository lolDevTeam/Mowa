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
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    using Mowa.MovieAPI.Model.Search;

    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    /// The movie search controller.
    /// </summary>
    [Route("api/[controller]")]
    public class MovieSearchController : Controller
    {
        /// <summary>
        /// The movie db api url.
        /// </summary>
        private const string MovieDbApiUrl = "https://api.themoviedb.org/3/";

        /// <summary>
        /// The configuration.
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// The movie db api key.
        /// </summary>
        private string movieDbApiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieSearchController"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public MovieSearchController(IConfiguration configuration)
        {
            this.configuration = configuration;

            this.movieDbApiKey = this.configuration.GetSection("MovieDB").GetChildren().FirstOrDefault()?.Value;
        }

        /// <summary>
        /// The index. // GET: /api/MovieSearch?searchString=pulp%20fiction
        /// </summary>
        /// <param name="searchString">
        /// The search String.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet("{searchString}")]
        public async Task<SearchResult> Get(string searchString)
        {
            searchString = searchString.Replace(" ", "%20");
            var queryUrl = MovieDbApiUrl + "search/movie?query=" + searchString + "&api_key=" + this.movieDbApiKey;

            var client = new HttpClient() { BaseAddress = new Uri(MovieDbApiUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(queryUrl);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseData = await response.Content.ReadAsStringAsync();

            var searchResult = JsonConvert.DeserializeObject<SearchResult>(responseData);

            return searchResult;
        }
    }
}