// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieTest.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the UnitTest for the Movie API
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.UnitTest
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using Mowa.MovieAPI.Model.Movie;
    using Mowa.MovieAPI.Model.Search;

    using Newtonsoft.Json;

    using Xunit;

    /// <summary>
    /// The movie test.
    /// </summary>
    public class MovieTest
    {
        /// <summary>
        /// The moviedb API key
        /// </summary>
        private const string ApiKey = "insert your apikey here";

        /// <summary>
        /// The api url.
        /// </summary>
        private const string ApiUrl = "https://api.themoviedb.org/3/search/movie?";

        /// <summary>
        /// The base url.
        /// </summary>
        private const string BaseUrl = "https://api.themoviedb.org/3/";

        /// <summary>
        /// The search for movie pulp fiction should get wanted result.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task SearchForMoviePulpFictionShouldGetWantedResult()
        {
            // arrange
            var queryUrl = ApiUrl + "query=pulp%20fiction&api_key=" + ApiKey;
            var client = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // act
            var response = await client.GetAsync(queryUrl);

            // assert
            Assert.True(response.IsSuccessStatusCode);

            var responseData = response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// The search for movie and deserialize json to search result object.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task SearchForMovieAndDeserializeJsonToSearchResultObject()
        {
            // arrange
            var searchString = "query=pulp%20fiction";
            var queryUrl = ApiUrl + searchString + "&api_key=" + ApiKey;
            var client = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // act
            var response = await client.GetAsync(queryUrl);

            Assert.True(response.IsSuccessStatusCode);

            var responseData = await response.Content.ReadAsStringAsync();

            var searchResult = JsonConvert.DeserializeObject<MovieSearchResult>(responseData);

            // assert
            Assert.IsAssignableFrom<MovieSearchResult>(searchResult);
        }

        /// <summary>
        /// The search for pulp fiction movie id and get detailed information for the id.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task GetDetailedMovieInformationForPulpFiction()
        {
            // arrange
            var movieApiUrl = "https://api.themoviedb.org/3/movie/";
            var queryUrl = movieApiUrl + "680"
                       + "?api_key=" + ApiKey;
            var client = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // act
            var response = await client.GetAsync(queryUrl);

            Assert.True(response.IsSuccessStatusCode);

            var responseData = await response.Content.ReadAsStringAsync();

            // assert
            var searchResult = JsonConvert.DeserializeObject<MovieDetail>(responseData);
        }

        /// <summary>
        /// test to get todays popular movies.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Fact]
        public async Task GetTodaysPopularMovies()
        {
            var apiUrl = "https://api.themoviedb.org/3/movie/popular?api_key=";
            var language = "de-DE";
            var queryUrl = apiUrl + ApiKey + "&language=" + language + "&page=1";

            var client = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // act
            var response = await client.GetAsync(queryUrl);

            Assert.True(response.IsSuccessStatusCode);

            var responseData = await response.Content.ReadAsStringAsync();

            var searchResult = JsonConvert.DeserializeObject<MovieSearchResult>(responseData);

            Assert.IsAssignableFrom<MovieSearchResult>(searchResult);

            Assert.NotNull(searchResult);
        }
    }
}
