// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TvShowSearchResult.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the TvShowSearchResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.Search
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The tv show search result.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class TvShowSearchResult
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the movie resultss.
        /// </summary>
        public ICollection<TvShow> Results { get; set; }

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
