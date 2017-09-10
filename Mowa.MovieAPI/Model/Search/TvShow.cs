// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TvShow.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the TvShow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Mowa.MovieAPI.Model.Search
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The tv show.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class TvShow
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
        /// Gets or sets the popularity.
        /// </summary>
        public double Popularity { get; set; }

        /// <summary>
        /// Gets or sets the backdrop_ path.
        /// </summary>
        public string Backdrop_Path { get; set; }

        /// <summary>
        /// Gets or sets the vote_ average.
        /// </summary>
        public double Vote_Average { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// Gets or sets the first_ air_ date.
        /// </summary>
        public DateTime First_Air_Date { get; set; }

        /// <summary>
        /// Gets or sets the origin_ countries.
        /// </summary>
        public string[] Origin_Countries { get; set; }

        /// <summary>
        /// Gets or sets the genre_ ids.
        /// </summary>
        public int[] Genre_Ids { get; set; }

        /// <summary>
        /// Gets or sets the original_ language.
        /// </summary>
        public string Original_Language { get; set; }

        /// <summary>
        /// Gets or sets the vote_ count.
        /// </summary>
        public int Vote_Count { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the original_ name.
        /// </summary>
        public string Original_Name { get; set; }
    }
}
