// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Season.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the Season type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.TV
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The season.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "moviedb api is using underlines, so it's ok here")]
    public class Season
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the air_ date.
        /// </summary>
        public DateTime Air_Date { get; set; }

        /// <summary>
        /// Gets or sets the episode_ count.
        /// </summary>
        public int Episode_Count { get; set; }

        /// <summary>
        /// Gets or sets the poster_ path.
        /// </summary>
        public string Poster_Path { get; set; }

        /// <summary>
        /// Gets or sets the season_ number.
        /// </summary>
        public int Season_Number { get; set; }
    }
}
