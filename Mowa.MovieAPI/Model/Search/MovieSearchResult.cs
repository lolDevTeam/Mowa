// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieSearchResult.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the SearchResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.Search
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The search result.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class MovieSearchResult
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the movie resultss.
        /// </summary>
        public ICollection<Movie> Results { get; set; }

        /// <summary>
        /// Gets or sets the total_ results.
        /// </summary>
        public int Total_Results { get; set; }

        /// <summary>
        /// Gets or sets the total_ pages.
        /// </summary>
        public int Total_Pages { get; set; }
    }
}
