// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductionCountry.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the ProductionCountries type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.Movie
{
    /// <summary>
    /// The production country.
    /// </summary>
    public class ProductionCountry
    {
        /// <summary>
        /// Gets or sets the iso_3166_1.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string ISO_3166_1 { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
