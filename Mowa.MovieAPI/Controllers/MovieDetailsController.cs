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
    using Mowa.MovieAPI.Model.Search;

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
        /// get detail of a specific movie.
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

        /// <summary>
        /// get popular movies.
        /// </summary>
        /// <param name="region">
        /// The region. For example: "de" "en" "us"
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("popular/{region}")]
        public async Task<SearchResult> Popular(string region)
        {
            var queryUrl = MovieDbApiUrl + "popular" + "?api_key=" + this.movieDbApiKey + "&region=" + region;
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

            var searchResult = JsonConvert.DeserializeObject<SearchResult>(responseData);

            return searchResult;
        }

        /// <summary>
        /// get latest movies. note: unstable for now
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("latest")]
        public async Task<MovieDetail> Latest()
        {
            var language = "de-DE";
            var queryUrl = MovieDbApiUrl + "latest?api_key=" + this.movieDbApiKey;

            var client = new HttpClient() { BaseAddress = new Uri(MovieDbApiUrl + "/latest") };
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

        /// <summary>
        /// get upcoming movies for a region.
        /// </summary>
        /// <param name="region">
        /// The region. For example: "de" "en" "us"
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("upcoming/{region}")]
        public async Task<SearchResult> Upcoming(string region)
        {
            var queryUrl = MovieDbApiUrl + "upcoming" + "?api_key=" + this.movieDbApiKey + "&region=" + region;
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

            var searchResult = JsonConvert.DeserializeObject<SearchResult>(responseData);

            return searchResult;
        }

        /// <summary>
        /// get a list of movies in theatres for a specific region.
        /// </summary>
        /// <param name="region">
        /// The region. For example: "de" "en" "us"
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("now_playing/{region}")]
        public async Task<SearchResult> NowPlaying(string region)
        {
            var queryUrl = MovieDbApiUrl + "now_playing" + "?api_key=" + this.movieDbApiKey + "&region=" + region;
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

            var searchResult = JsonConvert.DeserializeObject<SearchResult>(responseData);

            return searchResult;
        }
    }
}
