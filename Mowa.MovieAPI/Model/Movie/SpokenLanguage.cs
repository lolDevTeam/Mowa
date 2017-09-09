// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpokenLanguage.cs" company="jayDev">
//   Jan Jalinski
// </copyright>
// <summary>
//   Defines the SpokenLanguage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mowa.MovieAPI.Model.Movie
{
    /// <summary>
    /// The spoken language.
    /// </summary>
    public class SpokenLanguage
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the is o_639_1.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string ISO_639_1 { get; set; }
    }
}
