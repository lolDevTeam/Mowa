// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Movie.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the Movie type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.Search
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The movie.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class Movie
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the poster_ path.
        /// </summary>
        public string Poster_Path { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether adult.
        /// </summary>
        public bool Adult { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// Gets or sets the release_ date.
        /// </summary>
        public DateTime? Release_Date { get; set; }

        /// <summary>
        /// Gets or sets the genre_ ids.
        /// </summary>
        public int[] Genre_Ids { get; set; }

        /// <summary>
        /// Gets or sets the original_ title.
        /// </summary>
        public string Original_Title { get; set; }

        /// <summary>
        /// Gets or sets the original_ language.
        /// </summary>
        public string Original_Language { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the backdrop_ path.
        /// </summary>
        public string Backdrop_Path { get; set; }

        /// <summary>
        /// Gets or sets the popularity.
        /// </summary>
        public double Popularity { get; set; }

        /// <summary>
        /// Gets or sets the vote_ count.
        /// </summary>
        public int Vote_Count { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether video.
        /// </summary>
        public bool Video { get; set; }

        /// <summary>
        /// Gets or sets the vote_ average.
        /// </summary>
        public double Vote_Average { get; set; }
    }
}
