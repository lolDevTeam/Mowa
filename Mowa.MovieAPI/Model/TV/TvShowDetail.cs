// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TvShowDetail.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the TvShowDetail type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.TV
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Mowa.MovieAPI.Model.Shared;

    /// <summary>
    /// The tv show detail.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class TvShowDetail
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the backdrop_ path.
        /// </summary>
        public string Backdrop_Path { get; set; }

        /// <summary>
        /// Gets or sets the created_ by.
        /// </summary>
        public ICollection<Creator> Created_By { get; set; }

        /// <summary>
        /// Gets or sets the episode_ run_ time.
        /// </summary>
        public int[] Episode_Run_Time { get; set; }

        /// <summary>
        /// Gets or sets the first_ air_ date.
        /// </summary>
        public DateTime First_Air_Date { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public ICollection<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the homepage.
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether in_ production.
        /// </summary>
        public bool In_Production { get; set; }

        /// <summary>
        /// Gets or sets the languages.
        /// </summary>
        public string[] Languages { get; set; }

        /// <summary>
        /// Gets or sets the last_ air_ date.
        /// </summary>
        public DateTime Last_Air_Date { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the networks.
        /// </summary>
        public ICollection<Network> Networks { get; set; }

        /// <summary>
        /// Gets or sets the number_ of_ episodes.
        /// </summary>
        public int Number_Of_Episodes { get; set; }

        /// <summary>
        /// Gets or sets the number_ of_ seasons.
        /// </summary>
        public int Number_Of_Seasons { get; set; }

        /// <summary>
        /// Gets or sets the origin_ country.
        /// </summary>
        public string[] Origin_Country { get; set; }

        /// <summary>
        /// Gets or sets the original_ language.
        /// </summary>
        public string Original_Language { get; set; }

        /// <summary>
        /// Gets or sets the original_ name.
        /// </summary>
        public string Original_Name { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// Gets or sets the popularity.
        /// </summary>
        public double Popularity { get; set; }

        /// <summary>
        /// Gets or sets the poster_ path.
        /// </summary>
        public string Poster_Path { get; set; }

        /// <summary>
        /// Gets or sets the production_ companies.
        /// </summary>
        public ICollection<ProductionCompany> Production_Companies { get; set; }

        /// <summary>
        /// Gets or sets the seasons.
        /// </summary>
        public ICollection<Season> Seasons { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the vote_ average.
        /// </summary>
        public int Vote_Average { get; set; }

        /// <summary>
        /// Gets or sets the vote_ count.
        /// </summary>
        public int Vote_Count { get; set; }
    }
}
