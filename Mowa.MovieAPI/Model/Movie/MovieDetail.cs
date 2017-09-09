// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieDetail.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the MovieDetail type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.Movie
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The movie detail.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class MovieDetail
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether adult.
        /// </summary>
        public bool Adult { get; set; }

        /// <summary>
        /// Gets or sets the backdrop_ path.
        /// </summary>
        public string Backdrop_Path { get; set; }

        /// <summary>
        /// Gets or sets the budget.
        /// </summary>
        public int Budget { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public ICollection<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the homepage.
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// Gets or sets the imdb_ id. 
        /// minLength: 9 maxLength: 9 pattern: ^tt[0 - 9]{7}
        /// </summary>
        public string Imdb_Id { get; set; }

        /// <summary>
        /// Gets or sets the original_ language.
        /// </summary>
        public string Original_Language { get; set; }

        /// <summary>
        /// Gets or sets the original_ title.
        /// </summary>
        public string Original_Title { get; set; }

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
        /// Gets or sets the production companies.
        /// </summary>
        public ICollection<ProductionCompany> ProductionCompanies { get; set; }

        /// <summary>
        /// Gets or sets the production countries.
        /// </summary>
        public ICollection<ProductionCountry> ProductionCountries { get; set; }

        /// <summary>
        /// Gets or sets the release_ date.
        /// </summary>
        public DateTime Release_Date { get; set; }

        /// <summary>
        /// Gets or sets the revenue.
        /// </summary>
        public int Revenue { get; set; }

        /// <summary>
        /// Gets or sets the runtime.
        /// </summary>
        public int Runtime { get; set; }

        /// <summary>
        /// Gets or sets the spoken languages.
        /// </summary>
        public ICollection<SpokenLanguage> SpokenLanguages { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the tagline.
        /// </summary>
        public string Tagline { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether video.
        /// </summary>
        public bool Video { get; set; }

        /// <summary>
        /// Gets or sets the vote_ average.
        /// </summary>
        public double Vote_Average { get; set; }

        /// <summary>
        /// Gets or sets the vote_ count.
        /// </summary>
        public int Vote_Count { get; set; }
    }
}
